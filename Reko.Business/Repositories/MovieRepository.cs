using Reko.Contracts.Repositories;
using Reko.Data;
using Reko.Data.Entities;
using Reko.Models.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Reko.Business.Repositories
{
    public sealed class MovieRepository : CRUDRepository<Movie, MovieDto, RekoDbContext, int>, IMovieRepository
    {
        private readonly IEntityKeeper _entityKeeper;

        public MovieRepository(RekoDbContext context, IEntityKeeper entityKeeper) : base(context)
        {
            _entityKeeper = entityKeeper;
        }

        public async Task LinkData(ICollection<MovieDto> data)
        {
            await _entityKeeper.SetMovieData(data);

            foreach (var (movieDto, movie) in _entityKeeper.GetMovies())
            {
                movie.ProductionCompanies.AddRange(_entityKeeper.GetEntityProductionCompanies(movieDto.ProductionCompanies.Select(x => x.Id)));
                movie.CastMembers.AddRange(_entityKeeper.GetEntityCastMembers(movieDto.Credit?.CastMembers.Select(x => x.Id)));
                movie.CrewMembers.AddRange(_entityKeeper.GetEntityCrewMembers(movieDto.Credit?.CrewMembers.Select(x => x.Id)));
                movie.Languages.AddRange(_entityKeeper.GetEntityLanguage(movieDto.SpokenLanguages.Select(x => x.Id)));
                movie.Genres.AddRange(_entityKeeper.GetEntityGenres(movieDto.Genres.Select(x => x.Id)));
                movie.Videos.AddRange(_entityKeeper.GetEntityVideos(movieDto.Videos?.Videos.Select(x => x.Id)));
                movie.KeyWords.AddRange(_entityKeeper.GetEntityKeyWords(movieDto.Keywords.Select(x => x.Id)));
                movie.Countries.AddRange(_entityKeeper.GetEntityCountry(movieDto.ProductionCountries.Select(x => x.Id)));
            }

            await Context.SaveChangesAsync();
            _entityKeeper.Clear();
        }

        public async Task<MovieDto> GetMovie(int id)
        {
            var movie = await Context.Movies.Include(x => x.CastMembers).Include(x => x.CrewMembers).Include(x => x.CollectionInfo)
                .Include(x => x.Genres).Include(x => x.ProductionCompanies).Include(x => x.Videos).Include(x => x.Countries)
                .FirstOrDefaultAsync(x => x.Id == id);

            return movie?.ToDto();
        }
    }
}