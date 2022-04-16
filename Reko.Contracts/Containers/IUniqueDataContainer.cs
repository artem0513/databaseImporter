using System.Collections.Generic;
using Reko.Models.Dto;

namespace Reko.Contracts.Containers
{
    public interface IUniqueDataContainer<TDto, TId> where TDto : BaseDto<TId>
    {
        public void SetData(IEnumerable<TDto> data);
        public ICollection<TDto> MainElements { get; }
        public ICollection<GenreDto> Genres { get; }
        public ICollection<ProductionCompanyDto> ProductionCompanies { get; }
        public ICollection<KeywordDto> Keywords { get;  }
        public ICollection<CastMemberDto> CastMembers { get; }
        public ICollection<CrewMemberDto> CrewMembers { get; }
        public ICollection<VideoDto> Videos { get; }
    }
}