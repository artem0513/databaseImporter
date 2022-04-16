using System;
using System.Collections.Generic;
using System.Linq;
using Reko.Contracts.Containers;
using Reko.Models.Dto;

namespace Reko.Business.Containers
{
    public sealed class UniqueMovieDataContainer : UniqueContainerBase<MovieDto>, IUniqueMovieDataContainer
    {
        public ICollection<CountryDto> ProductionCountries { get; private set; }
        public ICollection<LanguageDto> SpokenLanguages { get; private set; }
        public ICollection<CollectionInfoDto> CollectionInfos { get; private set; }

        protected override void RemoveDuplicatesForEachElements(ICollection<MovieDto> data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            foreach (var movieDto in data)
            {
                movieDto.Credit.CrewMembers = movieDto.Credit.CrewMembers.Distinct();
                movieDto.Credit.CastMembers = movieDto.Credit.CastMembers.Distinct();
                movieDto.Videos.Videos = movieDto.Videos.Videos.Distinct();
                movieDto.Genres = movieDto.Genres.Distinct();
                movieDto.ProductionCompanies = movieDto.ProductionCompanies.Distinct();
                movieDto.SpokenLanguages = movieDto.SpokenLanguages.Distinct();
                movieDto.Keywords = movieDto.Keywords.Distinct();
                movieDto.ProductionCountries = movieDto.ProductionCountries.Distinct();
            }
        }

        protected override void SetUniqueData(ICollection<MovieDto> data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            CollectionInfos = data.Select(x => x.MovieCollectionInfo).Where(x => x != null).Distinct().ToArray();
            ProductionCompanies = data.SelectMany(x => x.ProductionCompanies).Distinct().ToArray();
            CrewMembers = data.SelectMany(x => x.Credit?.CrewMembers).Distinct().ToArray();
            CastMembers = data.SelectMany(x => x.Credit?.CastMembers).Distinct().ToArray();
            SpokenLanguages = data.SelectMany(x => x.SpokenLanguages).Distinct().ToArray();
            Genres = data.SelectMany(x => x.Genres).Distinct().ToArray();
            Videos = data.SelectMany(x => x.Videos.Videos).Distinct().ToArray();
            Keywords = data.SelectMany(x => x.Keywords).Distinct().ToArray();
            ProductionCountries = data.SelectMany(x => x.ProductionCountries).Distinct().ToArray();
        }
    }
}