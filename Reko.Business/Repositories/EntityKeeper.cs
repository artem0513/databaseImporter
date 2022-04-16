using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reko.Contracts.Repositories;
using Reko.Data;
using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Business.Repositories
{
    public sealed class EntityKeeper : IEntityKeeper
    {
        //TODO : Refactoring. Separate logic required.

        #region Dictionary storages

        private readonly RekoDbContext _rekoDb;
        private readonly Dictionary<MovieDto, Movie> _movies;
        private readonly Dictionary<SeasonDto, Season> _seasons;
        private readonly Dictionary<TVShowDto, TvShow> _tvShows;
        private readonly Dictionary<EpisodeDto, Episode> _episodes;
        private readonly Dictionary<int, ProductionCompany> _productionCompanies;
        private readonly Dictionary<int, Genre> _genres;
        private readonly Dictionary<string, Country> _countries;
        private readonly Dictionary<string, Language> _languages;
        private readonly Dictionary<int, KeyWord> _keyWords;
        private readonly Dictionary<string, Video> _videos;
        private readonly Dictionary<int, CastMember> _castMembers;
        private readonly Dictionary<int, CrewMember> _crewMembers;
        private readonly Dictionary<int, TvShowCreator> _tvShowCreators;
        private readonly Dictionary<int, GuestStar> _guestStars;
        private readonly Dictionary<int, Network> _networks;

        #endregion

        public EntityKeeper(RekoDbContext rekoDb)
        {
            _rekoDb = rekoDb;

            _networks = new Dictionary<int, Network>();
            _guestStars = new Dictionary<int, GuestStar>();
            _tvShowCreators = new Dictionary<int, TvShowCreator>();
            _seasons = new Dictionary<SeasonDto, Season>();
            _movies = new Dictionary<MovieDto, Movie>();
            _tvShows = new Dictionary<TVShowDto, TvShow>();
            _episodes = new Dictionary<EpisodeDto, Episode>();
            _productionCompanies = new Dictionary<int, ProductionCompany>();
            _genres = new Dictionary<int, Genre>();
            _countries = new Dictionary<string, Country>();
            _languages = new Dictionary<string, Language>();
            _keyWords = new Dictionary<int, KeyWord>();
            _videos = new Dictionary<string, Video>();
            _castMembers = new Dictionary<int, CastMember>();
            _crewMembers = new Dictionary<int, CrewMember>();
        }

        #region Clear

        public void Clear()
        {
            _episodes.Clear();
            _seasons.Clear();
            _tvShowCreators.Clear();
            _guestStars.Clear();
            _networks.Clear();
            _tvShows.Clear();
            _movies.Clear();
            _genres.Clear();
            _productionCompanies.Clear();
            _countries.Clear();
            _languages.Clear();
            _keyWords.Clear();
            _videos.Clear();
            _castMembers.Clear();
            _crewMembers.Clear();
        }

        #endregion

        #region GetEntityData

        public Dictionary<MovieDto, Movie> GetMovies()
        {
            return _movies;
        }

        public Dictionary<TVShowDto, TvShow> GetTvShows()
        {
            return _tvShows;
        }

        public Dictionary<SeasonDto, Season> GetSeasons()
        {
            return _seasons;
        }

        public Dictionary<EpisodeDto, Episode> GetEpisodes()
        {
            return _episodes;
        }

        public IEnumerable<ProductionCompany> GetEntityProductionCompanies(IEnumerable<int> ids)
        {
            return ids == null ? Enumerable.Empty<ProductionCompany>() : ids.Select(x => _productionCompanies[x]);
        }

        public IEnumerable<Genre> GetEntityGenres(IEnumerable<int> ids)
        {
            return ids == null ? Enumerable.Empty<Genre>() : ids.Select(x => _genres[x]);
        }

        public IEnumerable<Country> GetEntityCountry(IEnumerable<string> ids)
        {
            return ids == null ? Enumerable.Empty<Country>() : ids.Select(x => _countries[x]);
        }

        public IEnumerable<Language> GetEntityLanguage(IEnumerable<string> ids)
        {
            return ids == null ? Enumerable.Empty<Language>() : ids.Select(x => _languages[x]);
        }

        public IEnumerable<KeyWord> GetEntityKeyWords(IEnumerable<int> ids)
        {
            return ids == null ? Enumerable.Empty<KeyWord>() : ids.Select(x => _keyWords[x]);
        }

        public IEnumerable<Video> GetEntityVideos(IEnumerable<string> ids)
        {
            return ids == null ? Enumerable.Empty<Video>() : ids.Select(x => _videos[x]);
        }

        public IEnumerable<CrewMember> GetEntityCrewMembers(IEnumerable<int> ids)
        {
            return ids == null ? Enumerable.Empty<CrewMember>() : ids.Select(x => _crewMembers[x]);
        }

        public IEnumerable<TvShowCreator> GetEntityTvShowCreators(IEnumerable<int> ids)
        {
            return ids == null ? Enumerable.Empty<TvShowCreator>() : ids.Select(x => _tvShowCreators[x]);
        }

        public IEnumerable<GuestStar> GetEntityGuestStars(IEnumerable<int> ids)
        {
            return ids == null ? Enumerable.Empty<GuestStar>() : ids.Select(x => _guestStars[x]);
        }

        public IEnumerable<Network> GetEntityNetworks(IEnumerable<int> ids)
        {
            return ids == null ? Enumerable.Empty<Network>() : ids.Select(x => _networks[x]);
        }

        public IEnumerable<CastMember> GetEntityCastMembers(IEnumerable<int> ids)
        {
            return ids == null ? Enumerable.Empty<CastMember>() : ids.Select(x => _castMembers[x]);
        }

        #endregion

        #region SetTvShowData

        public async Task SaveTvShowData(ICollection<TVShowDto> tvShowDtos)
        {
            if (tvShowDtos == null)
            {
                throw new ArgumentNullException(nameof(tvShowDtos));
            }

            var seasons = tvShowDtos.SelectMany(x => x.Seasons).Distinct().ToArray();
            var episodes = seasons.SelectMany(x => x.Episodes).Distinct().ToArray();

            var tvShowIds = tvShowDtos.Select(x => x.Id).ToArray();
            var productionCompaniesIds = tvShowDtos.SelectMany(x => x.ProductionCompanies).Distinct().Select(x => x.Id).ToArray();
            var genreIds = tvShowDtos.SelectMany(x => x.Genres).Distinct().Select(x => x.Id).ToArray();
            var seasonIds = seasons.Distinct().Select(x => x.Id).ToArray();
            var netWorkIds = tvShowDtos.SelectMany(x => x.Networks).Distinct().Select(x => x.Id).ToArray();
            var episodesIds = episodes.Distinct().Select(x => x.Id).ToArray();
            var tvShowCreatorIds = tvShowDtos.SelectMany(x => x.CreatedBy).Distinct().Select(x => x.Id).ToArray();
            var guestStarsIds = episodes.SelectMany(x => x.GuestStars).Distinct().Select(x => x.Id).ToArray();
            var keyWordIds = tvShowDtos.SelectMany(x => x.Keywords).Distinct().Select(x => x.Id).ToArray();
            var videoIds = tvShowDtos.SelectMany(x => x.Videos?.Videos ?? Enumerable.Empty<VideoDto>()).Distinct().Select(x => x.Id).ToArray();
            var crewMemberIds = tvShowDtos.SelectMany(x => x.Credit?.CrewMembers ?? Enumerable.Empty<CrewMemberDto>())
                .Concat(episodes.SelectMany(x => x.CrewMembers)).Distinct().Select(x => x.Id)
                .ToArray();
            var castMemberIds = tvShowDtos.SelectMany(x => x.Credit?.CastMembers ?? Enumerable.Empty<CastMemberDto>()).Distinct().Select(x => x.Id)
                .ToArray();

            foreach (var (e, d) in (await _rekoDb.TvShows.Where(x => tvShowIds.Contains(x.Id)).ToArrayAsync())
                .Join(tvShowDtos, x => x.Id, x => x.Id, (e, d) => (e, d)))
            {
                _tvShows.Add(d, e);
            }

            foreach (var (e, d) in (await _rekoDb.Seasons.Where(x => seasonIds.Contains(x.Id)).ToArrayAsync())
                .Join(seasons, x => x.Id, x => x.Id, (e, d) => (e, d)))
            {
                _seasons.Add(d, e);
            }

            foreach (var (e, d) in (await _rekoDb.Episodes.Where(x => episodesIds.Contains(x.Id)).ToArrayAsync())
                .Join(episodes, x => x.Id, x => x.Id, (e, d) => (e, d)))
            {
                _episodes.Add(d, e);
            }

            foreach (var entity in await _rekoDb.TvShowCreators.Where(x => tvShowCreatorIds.Contains(x.Id)).ToArrayAsync())
            {
                _tvShowCreators.Add(entity.Id, entity);
            }

            foreach (var entity in await _rekoDb.Networks.Where(x => netWorkIds.Contains(x.Id)).ToArrayAsync())
            {
                _networks.Add(entity.Id, entity);
            }

            foreach (var entity in await _rekoDb.GuestStars.Where(x => guestStarsIds.Contains(x.Id)).ToArrayAsync())
            {
                _guestStars.Add(entity.Id, entity);
            }

            foreach (var entity in await _rekoDb.ProductionCompanies.Where(x => productionCompaniesIds.Contains(x.Id)).ToArrayAsync())
            {
                _productionCompanies.Add(entity.Id, entity);
            }

            foreach (var entity in await _rekoDb.Genres.Where(x => genreIds.Contains(x.Id)).ToArrayAsync())
            {
                _genres.Add(entity.Id, entity);
            }

            foreach (var entity in await _rekoDb.KeyWords.Where(x => keyWordIds.Contains(x.Id)).ToArrayAsync())
            {
                _keyWords.Add(entity.Id, entity);
            }

            foreach (var entity in await _rekoDb.Videos.Where(x => videoIds.Contains(x.Id)).ToArrayAsync())
            {
                _videos.Add(entity.Id, entity);
            }

            foreach (var entity in await _rekoDb.CrewMembers.Where(x => crewMemberIds.Contains(x.Id)).ToArrayAsync())
            {
                _crewMembers.Add(entity.Id, entity);
            }

            foreach (var entity in await _rekoDb.CastMembers.Where(x => castMemberIds.Contains(x.Id)).ToArrayAsync())
            {
                _castMembers.Add(entity.Id, entity);
            }
        }

        #endregion

        #region SetMovies


        public async Task SetMovieData(ICollection<MovieDto> movies)
        {
            if (movies == null)
            {
                throw new ArgumentNullException(nameof(movies));
            }

            var movieIds = movies.Select(x => x.Id).ToArray();
            var productionCompaniesIds = movies.SelectMany(x => x.ProductionCompanies).Distinct().Select(x => x.Id).ToArray();
            var genreIds = movies.SelectMany(x => x.Genres).Distinct().Select(x => x.Id).ToArray();
            var languageIds = movies.SelectMany(x => x.SpokenLanguages).Distinct().Select(x => x.Id).ToArray();
            var countryIds = movies.SelectMany(x => x.ProductionCountries).Distinct().Select(x => x.Id).ToArray();
            var keyWordIds = movies.SelectMany(x => x.Keywords).Distinct().Select(x => x.Id).ToArray();
            var videoIds = movies.SelectMany(x => x.Videos?.Videos ?? Enumerable.Empty<VideoDto>()).Distinct().Select(x => x.Id).ToArray();
            var crewMemberIds = movies.SelectMany(x => x.Credit?.CrewMembers ?? Enumerable.Empty<CrewMemberDto>()).Distinct().Select(x => x.Id)
                .ToArray();
            var castMemberIds = movies.SelectMany(x => x.Credit?.CastMembers ?? Enumerable.Empty<CastMemberDto>()).Distinct().Select(x => x.Id)
                .ToArray();

            foreach (var (e, d) in (await _rekoDb.Movies.Where(x => movieIds.Contains(x.Id)).ToArrayAsync())
                .Join(movies, x => x.Id, x => x.Id, (e, d) => (e, d)))
            {
                _movies.Add(d, e);
            }

            foreach (var entity in await _rekoDb.ProductionCompanies.Where(x => productionCompaniesIds.Contains(x.Id)).ToArrayAsync())
            {
                _productionCompanies.Add(entity.Id, entity);
            }

            foreach (var entity in await _rekoDb.Genres.Where(x => genreIds.Contains(x.Id)).ToArrayAsync())
            {
                _genres.Add(entity.Id, entity);
            }

            foreach (var entity in await _rekoDb.Languages.Where(x => languageIds.Contains(x.Id)).ToArrayAsync())
            {
                _languages.Add(entity.Id, entity);
            }

            foreach (var entity in await _rekoDb.Countries.Where(x => countryIds.Contains(x.Id)).ToArrayAsync())
            {
                _countries.Add(entity.Id, entity);
            }

            foreach (var entity in await _rekoDb.KeyWords.Where(x => keyWordIds.Contains(x.Id)).ToArrayAsync())
            {
                _keyWords.Add(entity.Id, entity);
            }

            foreach (var entity in await _rekoDb.Videos.Where(x => videoIds.Contains(x.Id)).ToArrayAsync())
            {
                _videos.Add(entity.Id, entity);
            }

            foreach (var entity in await _rekoDb.CrewMembers.Where(x => crewMemberIds.Contains(x.Id)).ToArrayAsync())
            {
                _crewMembers.Add(entity.Id, entity);
            }

            foreach (var entity in await _rekoDb.CastMembers.Where(x => castMemberIds.Contains(x.Id)).ToArrayAsync())
            {
                _castMembers.Add(entity.Id, entity);
            }
        }

        #endregion

    }
}