using System.Collections.Generic;
using System.Threading.Tasks;
using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Contracts.Repositories
{
    public interface IEntityKeeper
    {
        Dictionary<TVShowDto, TvShow> GetTvShows();
        Task SetMovieData(ICollection<MovieDto> movies);
        Task SaveTvShowData(ICollection<TVShowDto> tvShowDtos);
        IEnumerable<CastMember> GetEntityCastMembers(IEnumerable<int> ids);
        IEnumerable<CrewMember> GetEntityCrewMembers(IEnumerable<int> ids);
        IEnumerable<Video> GetEntityVideos(IEnumerable<string> ids);
        IEnumerable<KeyWord> GetEntityKeyWords(IEnumerable<int> ids);
        IEnumerable<Language> GetEntityLanguage(IEnumerable<string> ids);
        IEnumerable<Country> GetEntityCountry(IEnumerable<string> ids);
        IEnumerable<Genre> GetEntityGenres(IEnumerable<int> ids);
        IEnumerable<ProductionCompany> GetEntityProductionCompanies(IEnumerable<int> ids);
        Dictionary<MovieDto, Movie> GetMovies();
        Dictionary<SeasonDto, Season> GetSeasons();
        Dictionary<EpisodeDto, Episode> GetEpisodes();
        IEnumerable<TvShowCreator> GetEntityTvShowCreators(IEnumerable<int> ids);
        IEnumerable<Network> GetEntityNetworks(IEnumerable<int> ids);
        IEnumerable<GuestStar> GetEntityGuestStars(IEnumerable<int> ids);
        void Clear();
    }
}