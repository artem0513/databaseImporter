using System.Collections.Generic;
using Reko.Data.ProfileData;
using Reko.Models.Dto;

namespace Reko.Data.Entities
{
    public sealed class ProductionCompany : IMappableEntity<ProductionCompany, ProductionCompanyDto, int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Headquarters { get; set; }
        public string Homepage { get; set; }
        public string LogoPath { get; set; }
        public string ParentCompanyName { get; set; }
        public string ParentCompanyLogoPath { get; set; }
        public ICollection<TvShow> TvShows { get; set; }
        public ICollection<Movie> Movies { get; set; }

        public ProductionCompany()
        {
            TvShows = new List<TvShow>();
            Movies = new List<Movie>();
        }

        public ProductionCompanyDto ToDto()
        {
            return RekoMapperProfile.Mapper.Map<ProductionCompanyDto>(this);
        }

        public ProductionCompany FromDto(ProductionCompanyDto dto)
        {
            RekoMapperProfile.Mapper.Map(dto, this);
            return this;
        }
    }
}