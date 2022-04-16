using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Reko.Data.ProfileData;
using Reko.Models.Dto;

namespace Reko.Data.Entities
{
    public sealed class ProductionCompany : IMappableEntity<ProductionCompany, ProductionCompanyDto, int>
    {
        public int Id { get; set; }

        [MaxLength(1200)]
        public string Name { get; set; }

        [MaxLength(6000)]
        public string Description { get; set; }

        [MaxLength(5000)]
        public string Headquarters { get; set; }

        [MaxLength(2048)]
        public string Homepage { get; set; }

        [MaxLength(2048)]
        public string LogoPath { get; set; }

        [MaxLength(1000)]
        public string ParentCompanyName { get; set; }

        [MaxLength(2048)]
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