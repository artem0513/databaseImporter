using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using AutoMapper;
using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Data.ProfileData
{
    public partial class RekoMapperProfile
    {
        private static void ConfigureTvShowFromDtoToEntity(IProfileExpression configuration)
        {
            configuration.CreateMap<TVShowDto, TvShow>().ForMember(x => x.Genres, x => x.Ignore())
                .ForMember(x => x.ProductionCompanies, x => x.Ignore()).ForMember(x => x.Languages, x => x.Ignore())
                .ForMember(x => x.KeyWords, x => x.Ignore()).ForMember(x => x.TvShowCreators, x => x.Ignore())
                .ForMember(x => x.Networks, x => x.Ignore()).ForMember(x => x.Seasons, x => x.Ignore())
                .ForMember(x => x.OriginCountry, x => x.Ignore()).ForMember(x=>x.EpisodeRunTime, x=>x.Ignore())
                .ForMember(x => x.CrewMembers, x => x.Ignore()).ForMember(x => x.CastMembers, x => x.Ignore())
                .ForMember(x => x.Videos, x => x.Ignore()).AfterMap((src, dst) =>
                {
                    dst.Languages = src.Languages == null ? null : string.Join(',', src.Languages);
                    dst.OriginCountry = src.Languages == null ? null : string.Join(',', src.OriginCountry);
                    dst.EpisodeRunTime = src.EpisodeRunTime == null ? null : string.Join(',', src.EpisodeRunTime);
                });
        }

        private static void ConfigureTvShowFromEntityToDto(IProfileExpression configuration)
        {
            configuration.CreateMap<TvShow, TVShowDto>().ForMember(x => x.Genres, x => x.Ignore())
                .ForMember(x => x.ProductionCompanies, x => x.Ignore()).ForMember(x => x.Languages, x => x.Ignore())
                .ForMember(x => x.Keywords, x => x.Ignore()).ForMember(x => x.CreatedBy, x => x.Ignore())
                .ForMember(x => x.Networks, x => x.Ignore()).ForMember(x => x.Seasons, x => x.Ignore())
                .ForMember(x => x.OriginCountry, x => x.Ignore()).ForMember(x => x.EpisodeRunTime, x => x.Ignore())
                .ForMember(x => x.Credit, x => x.Ignore()).ForMember(x => x.Videos, x => x.Ignore()).AfterMap((src, dst) =>
                {
                    dst.EpisodeRunTime = string.IsNullOrWhiteSpace(src.EpisodeRunTime) ? null : src.EpisodeRunTime.Split(',').Select(int.Parse);
                    dst.Genres = Mapper.Map<ICollection<GenreDto>>(src.Genres ?? new List<Genre>());
                    dst.ProductionCompanies =
                        Mapper.Map<ICollection<ProductionCompanyDto>>(src.ProductionCompanies ?? new List<ProductionCompany>());
                    dst.Languages = string.IsNullOrWhiteSpace(src.Languages) ? null : src.Languages.Split(',');
                    dst.OriginCountry = string.IsNullOrWhiteSpace(src.OriginCountry) ? null : src.OriginCountry.Split(',');
                    dst.Keywords = Mapper.Map<ICollection<KeywordDto>>(src.KeyWords ?? new List<KeyWord>());
                    dst.CreatedBy = Mapper.Map<ICollection<TVShowCreatorDto>>(src.TvShowCreators ?? new List<TvShowCreator>());
                    dst.Networks = Mapper.Map<ICollection<NetworkDto>>(src.Networks ?? new List<Network>());
                    dst.Seasons = Mapper.Map<ICollection<SeasonDto>>(src.Seasons ?? new List<Season>());
                    dst.Credit = new CreditDto
                    {
                        Id = src.Id,
                        CastMembers = Mapper.Map<ICollection<CastMemberDto>>(src.CastMembers ?? new List<CastMember>()),
                        CrewMembers = Mapper.Map<ICollection<CrewMemberDto>>(src.CrewMembers ?? new List<CrewMember>())
                    };

                    dst.Videos = new VideosDto
                    {
                        Id = src.Id,
                        Videos = Mapper.Map<ICollection<VideoDto>>(src.Videos)
                    };
                });
        }
    }
}