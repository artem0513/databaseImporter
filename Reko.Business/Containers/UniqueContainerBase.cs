using System;
using System.Collections.Generic;
using System.Linq;
using Reko.Models.Dto;

namespace Reko.Business.Containers
{
    public abstract class UniqueContainerBase<T> where T : BaseDto<int>
    {
        public void SetData(IEnumerable<T> data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            var materializedData = data as T[] ?? data.ToArray();
            MainElements = materializedData;
            RemoveDuplicatesForEachElements(materializedData);
            SetUniqueData(materializedData);
        }

        protected abstract void RemoveDuplicatesForEachElements(ICollection<T> data);
        protected abstract void SetUniqueData(ICollection<T> data);

        public ICollection<T> MainElements { get; protected set; }
        public ICollection<GenreDto> Genres { get; protected set; }
        public ICollection<ProductionCompanyDto> ProductionCompanies { get; protected set; }
        public ICollection<KeywordDto> Keywords { get; protected set; }
        public ICollection<CastMemberDto> CastMembers { get; protected set; }
        public ICollection<CrewMemberDto> CrewMembers { get; protected set; }
        public ICollection<VideoDto> Videos { get; protected set; }
    }
}