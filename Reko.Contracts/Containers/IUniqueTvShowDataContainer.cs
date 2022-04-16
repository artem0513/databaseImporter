using System.Collections.Generic;
using Reko.Models.Dto;

namespace Reko.Contracts.Containers
{
    public interface IUniqueTvShowDataContainer : IUniqueDataContainer<TVShowDto, int>
    {
        public ICollection<EpisodeDto> Episodes { get; }
        public ICollection<GuestStarDto> GuestStars { get; }
        public ICollection<TVShowCreatorDto> TVShowCreators { get; }
        public ICollection<TVShowCreatorDto> CreatedBy { get; }
        public ICollection<NetworkDto> Networks { get; }
        public ICollection<SeasonDto> Seasons { get; }
    }
}