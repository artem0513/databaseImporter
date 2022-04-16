using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Data.ProfileData
{
    public partial class RekoMapperProfile
    {
        private static void ConfigureMovieFromDtoToEntity(IProfileExpression configuration)
        {
            configuration.CreateMap<MovieDto, Movie>().ForMember(x => x.CollectionInfo, x => x.Ignore())
                .ForMember(x => x.Genres, x => x.Ignore()).ForMember(x => x.ProductionCompanies, x => x.Ignore())
                .ForMember(x => x.Countries, x => x.Ignore()).ForMember(x => x.Languages, x => x.Ignore())
                .ForMember(x => x.KeyWords, x => x.Ignore()).ForMember(x => x.CrewMembers, x => x.Ignore())
                .ForMember(x => x.CastMembers, x => x.Ignore()).ForMember(x => x.Videos, x => x.Ignore());
        }

        private static void ConfigureMovieFromEntityToDto(IProfileExpression configuration)
        {
            configuration.CreateMap<Movie, MovieDto>().ForMember(x => x.MovieCollectionInfo, x => x.Ignore())
                .ForMember(x => x.Genres, x => x.Ignore()).ForMember(x => x.ProductionCompanies, x => x.Ignore())
                .ForMember(x => x.ProductionCountries, x => x.Ignore()).ForMember(x => x.SpokenLanguages, x => x.Ignore())
                .ForMember(x => x.Keywords, x => x.Ignore()).ForMember(x => x.Credit, x => x.Ignore())
                .ForMember(x => x.Videos, x => x.Ignore()).AfterMap((src, dst) =>
                {
                    dst.MovieCollectionInfo = src.CollectionInfo != null ? Mapper.Map<CollectionInfoDto>(src.CollectionInfo) : null;
                    dst.Genres = Mapper.Map<ICollection<GenreDto>>(src.Genres ?? new List<Genre>());
                    dst.ProductionCompanies =
                        Mapper.Map<ICollection<ProductionCompanyDto>>(src.ProductionCompanies ?? new List<ProductionCompany>());
                    dst.ProductionCountries = Mapper.Map<ICollection<CountryDto>>(src.Countries ?? new List<Country>());
                    dst.SpokenLanguages = Mapper.Map<ICollection<LanguageDto>>(src.Languages ?? new List<Language>());
                    dst.Keywords = Mapper.Map<ICollection<KeywordDto>>(src.KeyWords ?? new List<KeyWord>());
                    dst.Credit = new CreditDto
                    {
                        Id = src.Id,
                        CastMembers = Mapper.Map<ICollection<CastMemberDto>>(src.CastMembers ?? new List<CastMember>()),
                        CrewMembers = Mapper.Map<ICollection<CrewMemberDto>>(src.CrewMembers ?? new List<CrewMember>())
                    };

                    dst.Videos = new VideosDto
                    {
                        Id = src.Id,
                        Videos = Mapper.Map<ICollection<VideoDto>>(src.Videos),
                    };
                });
        }
    }
}