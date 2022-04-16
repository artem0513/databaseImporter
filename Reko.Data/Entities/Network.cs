using System.Collections.Generic;
using Reko.Data.ProfileData;
using Reko.Models.Dto;

namespace Reko.Data.Entities
{
    public sealed class Network : IMappableEntity<Network, NetworkDto, int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TvShow> TvShows { get; set; }

        public Network()
        {
            TvShows = new List<TvShow>();
        }

        public NetworkDto ToDto()
        {
            return RekoMapperProfile.Mapper.Map<NetworkDto>(this);
        }

        public Network FromDto(NetworkDto dto)
        {
            RekoMapperProfile.Mapper.Map(dto, this);
            return this;
        }
    }
}