using System;
using Reko.Contracts.Repositories;
using Reko.Data;
using Reko.Data.Entities;
using Reko.Models.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reko.Contracts.Containers;
using Reko.Contracts.EntityStorages;

namespace Reko.Business.Repositories
{
    public sealed class MovieRepository : LinkRepositoryBase<Movie, MovieDto, IUniqueMovieDataContainer, IMovieEntityStorage, int>, IMovieRepository
    {
        public MovieRepository(RekoDbContext context, IMovieEntityStorage storage) : base(context, storage)
        {
        }

        public async Task<MovieDto> GetMovie(int id, CancellationToken cancellationToken)
        {
            var movie = await Context.Movies.Include(x => x.CollectionInfo).SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (movie != null)
            {
                var castMembers = await Context.CastMembers.Include(x => x.Movies).Where(m => m.Movies.Any(y => y.Id == id)).ToListAsync(cancellationToken);
                var crewMembers = await Context.CrewMembers.Include(x => x.Movies).Where(m => m.Movies.Any(y => y.Id == id)).ToListAsync(cancellationToken);
                var genres = await Context.Genres.Include(x => x.Movies).Where(m => m.Movies.Any(y => y.Id == id)).ToListAsync(cancellationToken);
                var productionCompanies = await Context.ProductionCompanies.Include(x => x.Movies).Where(m => m.Movies.Any(y => y.Id == id))
                    .ToListAsync(cancellationToken);
                var videos = await Context.Videos.Include(x => x.Movie).Where(m => m.MovieId == id).ToListAsync(cancellationToken);
                var countries = await Context.Countries.Include(x => x.Movies).Where(el => el.Movies.Any(m => m.Id == id)).ToListAsync(cancellationToken);
                var languages = await Context.Languages.Include(x => x.Movies).Where(el => el.Movies.Any(m => m.Id == id)).ToListAsync(cancellationToken);

                movie.CastMembers = castMembers;
                movie.Languages = languages;
                movie.CrewMembers = crewMembers;
                movie.Genres = genres;
                movie.ProductionCompanies = productionCompanies;
                movie.Videos = videos;
                movie.Countries = countries;

                return movie.ToDto();
            }

            return null;
        }

        public async Task AddCollectionInfos(IEnumerable<CollectionInfoDto> collectionInfos, CancellationToken cancellationToken)
        {
            if (collectionInfos == null)
            {
                throw new ArgumentNullException(nameof(collectionInfos));
            }

            var collectionInfoIds = await Context.Movies.Where(x => x.CollectionInfoId.HasValue).Select(x => x.CollectionInfoId)
                .ToArrayAsync(cancellationToken);
            await Context.Set<CollectionInfo>()
                .AddRangeAsync(collectionInfos.Where(x => !collectionInfoIds.Contains(x.Id)).Select(x => new CollectionInfo().FromDto(x)), cancellationToken);
            await Context.SaveChangesAsync(cancellationToken);
        }

        protected override async Task LinkEntities(IUniqueMovieDataContainer container, CancellationToken cancellationToken)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            await EntityStorage.SetData(container, cancellationToken);

            foreach (var (movieDto, movie) in EntityStorage.GetMovies())
            {
                if (movieDto.MovieCollectionInfo != null)
                {
                    movie.CollectionInfo = EntityStorage.GetEntityCollectionInfo(movieDto.MovieCollectionInfo.Id);
                }

                movie.ProductionCompanies.AddRange(EntityStorage.GetEntityProductionCompanies(movieDto.ProductionCompanies.Select(x => x.Id)));
                movie.CastMembers.AddRange(EntityStorage.GetEntityCastMembers(movieDto.Credit?.CastMembers.Select(x => x.Id)));
                movie.CrewMembers.AddRange(EntityStorage.GetEntityCrewMembers(movieDto.Credit?.CrewMembers.Select(x => x.Id)));
                movie.Languages.AddRange(EntityStorage.GetEntityLanguage(movieDto.SpokenLanguages.Select(x => x.Id)));
                movie.Genres.AddRange(EntityStorage.GetEntityGenres(movieDto.Genres.Select(x => x.Id)));
                movie.Videos.AddRange(EntityStorage.GetEntityVideos(movieDto.Videos?.Videos.Select(x => x.Id)));
                movie.KeyWords.AddRange(EntityStorage.GetEntityKeyWords(movieDto.Keywords.Select(x => x.Id)));
                movie.Countries.AddRange(EntityStorage.GetEntityCountry(movieDto.ProductionCountries.Select(x => x.Id)));
            }
        }
    }
}