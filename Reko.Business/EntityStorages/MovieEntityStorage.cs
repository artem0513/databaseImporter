using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reko.Contracts.Containers;
using Reko.Contracts.EntityStorages;
using Reko.Data;
using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Business.EntityStorages
{
    public sealed class MovieEntityStorage : EntityStorageBase<IUniqueMovieDataContainer, MovieDto, int>, IMovieEntityStorage
    {
        private readonly Dictionary<MovieDto, Movie> _movies;
        private readonly Dictionary<string, Country> _countries;
        private readonly Dictionary<string, Language> _languages;
        private readonly Dictionary<int, CollectionInfo> _collectionInfos;

        public MovieEntityStorage(RekoDbContext context) : base(context)
        {
            _countries = new Dictionary<string, Country>();
            _languages = new Dictionary<string, Language>();
            _movies = new Dictionary<MovieDto, Movie>();
            _collectionInfos = new Dictionary<int, CollectionInfo>();
        }

        public IEnumerable<Country> GetEntityCountry(IEnumerable<string> ids)
        {
            return ids == null ? Enumerable.Empty<Country>() : ids.Select(x => _countries[x]);
        }

        public IEnumerable<Language> GetEntityLanguage(IEnumerable<string> ids)
        {
            return ids == null ? Enumerable.Empty<Language>() : ids.Select(x => _languages[x]);
        }

        public CollectionInfo GetEntityCollectionInfo(int id)
        {
            return _collectionInfos.TryGetValue(id, out var collectionInfo) ? collectionInfo : null;
        }

        public Dictionary<MovieDto, Movie> GetMovies()
        {
            return _movies;
        }

        protected override void ClearElements()
        {
            _countries.Clear();
            _languages.Clear();
            _movies.Clear();
            _collectionInfos.Clear();
        }

        protected override async Task SetEntityData(IUniqueMovieDataContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            var movieIds = container.MainElements.Select(x => x.Id).ToArray();
            var languageIds = container.SpokenLanguages.Select(x => x.Id).ToArray();
            var countryIds = container.ProductionCountries.Select(x => x.Id).ToArray();
            var collectionInfoIds = container.CollectionInfos.Select(x => x.Id).ToArray();

            foreach (var (e, d) in (await RekoDb.Movies.Where(x => movieIds.Contains(x.Id)).ToArrayAsync())
                .Join(container.MainElements, x => x.Id, x => x.Id, (e, d) => (e, d)))
            {
                _movies.Add(d, e);
            }

            foreach (var entity in await RekoDb.Languages.Where(x => languageIds.Contains(x.Id)).ToArrayAsync())
            {
                _languages.Add(entity.Id, entity);
            }

            foreach (var entity in await RekoDb.Countries.Where(x => countryIds.Contains(x.Id)).ToArrayAsync())
            {
                _countries.Add(entity.Id, entity);
            }

            foreach (var entity in await RekoDb.CollectionInfos.Where(x => collectionInfoIds.Contains(x.Id)).ToArrayAsync())
            {
                _collectionInfos.Add(entity.Id, entity);
            }
        }
    }
}