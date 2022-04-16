using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reko.Business.Containers;
using Reko.Business.DataCollectors;
using Reko.Business.EntityStorages;
using Reko.Business.Managers;
using Reko.Business.Repositories;
using Reko.Contracts.Containers;
using Reko.Contracts.EntityStorages;
using Reko.Contracts.Managers;
using Reko.Contracts.Repositories;
using Reko.Data;
using Reko.Models.Dto;

namespace Reko
{
    public static class DependencyResolver
    {
        public static void Resolve(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RekoDbContext>(x => x.UseSqlServer(configuration.GetConnectionString("ConnectionString")));
            services.AddScoped<ICatalogDataCollector<MovieDto>, CatalogDataCollector<MovieDto>>();
            services.AddScoped<IDataCollectorManager, DataCollectorManager>();
            services.AddScoped<IUniqueMovieDataContainer, UniqueMovieDataContainer>();
            services.AddScoped<IUniqueTvShowDataContainer, UniqueTvShowDataContainer>();
            services.AddHostedService<SchedulerDataCollector>();
            services.AddScoped<ICatalogDataCollector<TVShowDto>, CatalogDataCollector<TVShowDto>>();

            services.AddScoped<IMovieEntityStorage, MovieEntityStorage>();
            services.AddScoped<ITvShowEntityStorage, TvShowEntityStorage>();

            services.ResolveManagers();
            services.ResolveRepositories();
        }

        private static void ResolveManagers(this IServiceCollection services)
        {
            services.AddScoped<IMovieManager, MovieManager>();
            services.AddScoped<ITVShowManager, TVShowManager>();
            services.AddScoped<ICatalogManager<MovieDto>, MovieManager>();
            services.AddScoped<ICatalogManager<TVShowDto>, TVShowManager>();
        }

        private static void ResolveRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<ICastMemberRepository, CastMemberRepository>();
            services.AddScoped<ICrewMemberRepository, CrewMemberRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IVideoRepository, VideoRepository>();
            services.AddScoped<IKeywordRepository, KeywordRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ITVShowRepository, TVShowRepository>();
            services.AddScoped<ITvShowCreatorRepository, TvShowCreatorRepository>();
            services.AddScoped<IGuestStarRepository, GuestStarRepository>();
            services.AddScoped<INetworkRepository, NetworkRepository>();
            services.AddScoped<ISeasonRepository, SeasonRepository>();
            services.AddScoped<IEpisodeRepository, EpisodeRepository>();
        }
    }
}