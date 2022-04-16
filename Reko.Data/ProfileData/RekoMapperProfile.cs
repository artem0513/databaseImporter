using AutoMapper;

namespace Reko.Data.ProfileData
{
    public partial class RekoMapperProfile : Profile
    {
        private static readonly MapperConfiguration _mapperConfiguration;
        public static Mapper Mapper { get; }

        static RekoMapperProfile()
        {
            _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                ConfigureCollectionInfoFromDtoToEntity(cfg);
                ConfigureCollectionInfoFromEntityToDto(cfg);
                ConfigureMovieFromDtoToEntity(cfg);
                ConfigureMovieFromEntityToDto(cfg);
                ConfigureGenreFromDtoToEntity(cfg);
                ConfigureGenreFromEntityToDto(cfg);
                ConfigureCountryFromDtoToEntity(cfg);
                ConfigureCountryFromEntityToDto(cfg);
                ConfigureLanguageFromDtoToEntity(cfg);
                ConfigureLanguageFromEntityToDto(cfg);
                ConfigureKeyWordFromDtoToEntity(cfg);
                ConfigureKeyWordFromEntityToDto(cfg);
                ConfigureProductionCompanyFromDtoToEntity(cfg);
                ConfigureProductionCompanyInfoFromEntityToDto(cfg);
                ConfigureCrewMemberFromDtoToEntity(cfg);
                ConfigureCrewMemberFromEntityToDto(cfg);
                ConfigureCastMemberFromDtoToEntity(cfg);
                ConfigureCastMemberFromEntityToDto(cfg);
                ConfigureVideoFromDtoToEntity(cfg);
                ConfigureVideoFromEntityToDto(cfg);
                ConfigureTvShowFromDtoToEntity(cfg);
                ConfigureTvShowFromEntityToDto(cfg);
                ConfigureEpisodeFromDtoToEntity(cfg);
                ConfigureEpisodeFromEntityToDto(cfg);
                ConfigureSeasonFromDtoToEntity(cfg);
                ConfigureSeasonFromEntityToDto(cfg);
                ConfigureTVShowCreatorFromDtoToEntity(cfg);
                ConfigureTVShowCreatorFromEntityToDto(cfg);
                ConfigureNetworkFromDtoToEntity(cfg);
                ConfigureNetworkFromEntityToDto(cfg);
                ConfigureGuestStarFromDtoToEntity(cfg);
                ConfigureGuestStarFromEntityToDto(cfg);
            });

            Mapper = new Mapper(_mapperConfiguration);
        }
    }
}