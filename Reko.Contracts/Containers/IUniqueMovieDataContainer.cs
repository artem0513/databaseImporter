using System.Collections.Generic;
using Reko.Models.Dto;

namespace Reko.Contracts.Containers
{
    public interface IUniqueMovieDataContainer : IUniqueDataContainer<MovieDto, int>
    {
        public ICollection<CountryDto> ProductionCountries { get; }
        public ICollection<LanguageDto> SpokenLanguages { get; }
        public ICollection<CollectionInfoDto> CollectionInfos { get; }
    }
}