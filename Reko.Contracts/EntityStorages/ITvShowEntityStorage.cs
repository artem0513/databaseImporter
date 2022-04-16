using System.Collections.Generic;
using Reko.Contracts.Containers;
using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Contracts.EntityStorages
{
    public interface ITvShowEntityStorage : IEntityStorage<IUniqueTvShowDataContainer, TVShowDto, int>
    {
        Dictionary<TVShowDto, TvShow> GetTvShows();
        Dictionary<SeasonDto, Season> GetSeasons();
        Dictionary<EpisodeDto, Episode> GetEpisodes();
        IEnumerable<TvShowCreator> GetEntityTvShowCreators(IEnumerable<int> ids);
        IEnumerable<Network> GetEntityNetworks(IEnumerable<int> ids);
        IEnumerable<GuestStar> GetEntityGuestStars(IEnumerable<int> ids);
    }
}