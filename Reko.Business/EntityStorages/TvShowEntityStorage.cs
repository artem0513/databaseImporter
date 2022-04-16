using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reko.Contracts.Containers;
using Reko.Contracts.EntityStorages;
using Reko.Data;
using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Business.EntityStorages
{
    public sealed class TvShowEntityStorage : EntityStorageBase<IUniqueTvShowDataContainer, TVShowDto, int>, ITvShowEntityStorage
    {
        private readonly Dictionary<SeasonDto, Season> _seasons;
        private readonly Dictionary<TVShowDto, TvShow> _tvShows;
        private readonly Dictionary<EpisodeDto, Episode> _episodes;
        private readonly Dictionary<int, TvShowCreator> _tvShowCreators;
        private readonly Dictionary<int, GuestStar> _guestStars;
        private readonly Dictionary<int, Network> _networks;

        public TvShowEntityStorage(RekoDbContext context) : base(context)
        {
            _networks = new Dictionary<int, Network>();
            _guestStars = new Dictionary<int, GuestStar>();
            _tvShowCreators = new Dictionary<int, TvShowCreator>();
            _seasons = new Dictionary<SeasonDto, Season>();
            _tvShows = new Dictionary<TVShowDto, TvShow>();
            _episodes = new Dictionary<EpisodeDto, Episode>();
        }

        protected override async Task SetEntityData(IUniqueTvShowDataContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            var tvShowIds = container.MainElements.Select(x => x.Id).ToArray();
            var seasonIds = container.Seasons.Select(x => x.Id).ToArray();
            var episodeIds = container.Episodes.Select(x => x.Id).ToArray();
            var guestStarsIds = container.GuestStars.Select(x => x.Id).ToArray();
            var tvShowCreatorIds = container.TVShowCreators.Select(x => x.Id).ToArray();
            var netWorkIds = container.Networks.Select(x => x.Id).ToArray();

            foreach (var (e, d) in (await RekoDb.TvShows.Where(x => tvShowIds.Contains(x.Id)).ToArrayAsync())
                .Join(container.MainElements, x => x.Id, x => x.Id, (e, d) => (e, d)))
            {
                _tvShows.Add(d, e);
            }

            foreach (var (e, d) in (await RekoDb.Seasons.Where(x => seasonIds.Contains(x.Id)).ToArrayAsync())
                .Join(container.Seasons, x => x.Id, x => x.Id, (e, d) => (e, d)))
            {
                _seasons.Add(d, e);
            }

            foreach (var (e, d) in (await RekoDb.Episodes.Where(x => episodeIds.Contains(x.Id)).ToArrayAsync())
                .Join(container.Episodes, x => x.Id, x => x.Id, (e, d) => (e, d)))
            {
                _episodes.Add(d, e);
            }

            foreach (var entity in await RekoDb.TvShowCreators.Where(x => tvShowCreatorIds.Contains(x.Id)).ToArrayAsync())
            {
                _tvShowCreators.Add(entity.Id, entity);
            }

            foreach (var entity in await RekoDb.Networks.Where(x => netWorkIds.Contains(x.Id)).ToArrayAsync())
            {
                _networks.Add(entity.Id, entity);
            }

            foreach (var entity in await RekoDb.GuestStars.Where(x => guestStarsIds.Contains(x.Id)).ToArrayAsync())
            {
                _guestStars.Add(entity.Id, entity);
            }
        }

        public IEnumerable<TvShowCreator> GetEntityTvShowCreators(IEnumerable<int> ids)
        {
            return ids == null ? Enumerable.Empty<TvShowCreator>() : ids.Select(x => _tvShowCreators[x]);
        }

        public IEnumerable<GuestStar> GetEntityGuestStars(IEnumerable<int> ids)
        {
            return ids == null ? Enumerable.Empty<GuestStar>() : ids.Select(x => _guestStars[x]);
        }

        public IEnumerable<Network> GetEntityNetworks(IEnumerable<int> ids)
        {
            return ids == null ? Enumerable.Empty<Network>() : ids.Select(x => _networks[x]);
        }

        public Dictionary<TVShowDto, TvShow> GetTvShows()
        {
            return _tvShows;
        }

        public Dictionary<SeasonDto, Season> GetSeasons()
        {
            return _seasons;
        }

        public Dictionary<EpisodeDto, Episode> GetEpisodes()
        {
            return _episodes;
        }

        protected override void ClearElements()
        {
            _tvShows.Clear();
            _episodes.Clear();
            _seasons.Clear();
            _tvShowCreators.Clear();
            _guestStars.Clear();
            _networks.Clear();
        }
    }
}