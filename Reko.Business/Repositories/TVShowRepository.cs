using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reko.Contracts.Containers;
using Reko.Contracts.EntityStorages;
using Reko.Contracts.Repositories;
using Reko.Data;
using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Business.Repositories
{
    public sealed class TVShowRepository : LinkRepositoryBase<TvShow, TVShowDto, IUniqueTvShowDataContainer, ITvShowEntityStorage, int>, ITVShowRepository
    {
        public TVShowRepository(RekoDbContext context, ITvShowEntityStorage entityStorage) : base(context, entityStorage)
        {
        }

        public async Task<TVShowDto> GetTvShowInfo(int id, CancellationToken cancellationToken)
        {
            var tvShow = await Context.TvShows.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
            tvShow.Genres = await Context.Genres.Where(x => x.TvShows.Any(y => y.Id == id)).ToListAsync(cancellationToken);
            tvShow.TvShowCreators = await Context.TvShowCreators.Where(x => x.TvShows.Any(y => y.Id == id)).ToListAsync(cancellationToken);
            tvShow.ProductionCompanies = await Context.ProductionCompanies.Where(x => x.TvShows.Any(y => y.Id == id)).ToListAsync(cancellationToken);
            tvShow.Networks = await Context.Networks.Where(x => x.TvShows.Any(y => y.Id == id)).ToListAsync(cancellationToken);
            tvShow.CastMembers = await Context.CastMembers.Where(x => x.TvShows.Any(y => y.Id == id)).ToListAsync(cancellationToken);
            tvShow.CrewMembers = await Context.CrewMembers.Where(x => x.TvShows.Any(y => y.Id == id)).ToListAsync(cancellationToken);
            tvShow.Videos = await Context.Videos.Where(x => x.TvShowId == id).ToListAsync(cancellationToken);

            var seasons = await Context.Seasons.Where(x => x.TvShowId == id).ToListAsync(cancellationToken);
            var seasonIds = seasons.Select(x => x.Id).ToArray();
            var episodes = (await Context.Episodes.Where(x => x.SeasonId.HasValue && seasonIds.Any(y => x.SeasonId.Value == y)).ToArrayAsync(cancellationToken))
                .GroupBy(x => x.SeasonId)
                .ToDictionary(x => x.Key, x => x.Select(y => y.ToDto()).ToList());

            var result = tvShow.ToDto();

            foreach (var resultSeason in result.Seasons)
            {
                resultSeason.Episodes = episodes[resultSeason.Id];
            }

            return tvShow.ToDto();
        }

        protected override async Task LinkEntities(IUniqueTvShowDataContainer container, CancellationToken cancellationToken)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            await EntityStorage.SetData(container, cancellationToken);

            var episodes = EntityStorage.GetEpisodes();
            var seasons = EntityStorage.GetSeasons();

            foreach (var (tvShowDto, tvShow) in EntityStorage.GetTvShows())
            {
                tvShow.ProductionCompanies.AddRange(EntityStorage.GetEntityProductionCompanies(tvShowDto.ProductionCompanies.Select(x => x.Id)));
                tvShow.CastMembers.AddRange(EntityStorage.GetEntityCastMembers(tvShowDto.Credit?.CastMembers.Select(x => x.Id)));
                tvShow.CrewMembers.AddRange(EntityStorage.GetEntityCrewMembers(tvShowDto.Credit?.CrewMembers.Select(x => x.Id)));
                tvShow.Genres.AddRange(EntityStorage.GetEntityGenres(tvShowDto.Genres.Select(x => x.Id)));
                tvShow.Videos.AddRange(EntityStorage.GetEntityVideos(tvShowDto.Videos?.Videos.Select(x => x.Id)));
                tvShow.Networks.AddRange(EntityStorage.GetEntityNetworks(tvShowDto.Networks.Select(x => x.Id)));
                tvShow.TvShowCreators.AddRange(EntityStorage.GetEntityTvShowCreators(tvShowDto.CreatedBy.Select(x => x.Id)));
                tvShow.KeyWords.AddRange(EntityStorage.GetEntityKeyWords(tvShowDto.Keywords.Select(x => x.Id)));
                tvShow.Seasons.AddRange(tvShowDto.Seasons.Select(x => seasons[x]));
            }

            foreach (var (episodeDto, episode) in episodes)
            {
                episode.GuestStars.AddRange(EntityStorage.GetEntityGuestStars(episodeDto.GuestStars.Select(x => x.Id)));
                episode.CrewMembers.AddRange(EntityStorage.GetEntityCrewMembers(episodeDto.CrewMembers.Select(x => x.Id)));
            }

            foreach (var (seasonDto, season) in seasons)
            {
                season.Episodes.AddRange(seasonDto.Episodes.Select(x => episodes[x]));
            }
        }
    }
}