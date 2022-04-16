using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reko.Contracts.Containers;
using Reko.Contracts.EntityStorages;
using Reko.Data;
using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Business.EntityStorages
{
    public abstract class EntityStorageBase<TContainer, TDto, TId> : IEntityStorage<TContainer, TDto, TId>
        where TContainer : IUniqueDataContainer<TDto, TId>
        where TDto : BaseDto<TId>
    {
        protected readonly RekoDbContext RekoDb;

        protected readonly Dictionary<int, ProductionCompany> ProductionCompanies;
        protected readonly Dictionary<int, Genre> Genres;
        protected readonly Dictionary<int, KeyWord> KeyWords;
        protected readonly Dictionary<string, Video> Videos;
        protected readonly Dictionary<int, CastMember> CastMembers;
        protected readonly Dictionary<int, CrewMember> CrewMembers;


        protected EntityStorageBase(RekoDbContext rekoDb)
        {
            RekoDb = rekoDb;
            ProductionCompanies = new Dictionary<int, ProductionCompany>();
            Genres = new Dictionary<int, Genre>();
            KeyWords = new Dictionary<int, KeyWord>();
            Videos = new Dictionary<string, Video>();
            CastMembers = new Dictionary<int, CastMember>();
            CrewMembers = new Dictionary<int, CrewMember>();
        }

        public void Clear()
        {
            Genres.Clear();
            ProductionCompanies.Clear();
            KeyWords.Clear();
            Videos.Clear();
            CrewMembers.Clear();
            CastMembers.Clear();
            ClearElements();
        }

        protected abstract void ClearElements();

        public async Task SetData(TContainer container, CancellationToken cancellationToken)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            var genreIds = container.Genres.Select(x => x.Id).ToArray();
            var productionCompaniesIds = container.ProductionCompanies.Select(x => x.Id).ToArray();
            var videoIds = container.Videos.Select(x => x.Id).ToArray();
            var keyWordIds = container.Keywords.Select(x => x.Id).ToArray();
            var castMemberIds = container.CastMembers.Select(x => x.Id).ToArray();
            var crewMembersIds = container.CrewMembers.Select(x => x.Id).ToArray();

            foreach (var entity in await RekoDb.ProductionCompanies.Where(x => productionCompaniesIds.Contains(x.Id)).ToArrayAsync(cancellationToken))
            {
                ProductionCompanies.Add(entity.Id, entity);
            }

            foreach (var entity in await RekoDb.Genres.Where(x => genreIds.Contains(x.Id)).ToArrayAsync(cancellationToken))
            {
                Genres.Add(entity.Id, entity);
            }

            foreach (var entity in await RekoDb.KeyWords.Where(x => keyWordIds.Contains(x.Id)).ToArrayAsync(cancellationToken))
            {
                KeyWords.Add(entity.Id, entity);
            }

            foreach (var entity in await RekoDb.Videos.Where(x => videoIds.Contains(x.Id)).ToArrayAsync(cancellationToken))
            {
                Videos.Add(entity.Id, entity);
            }

            foreach (var entity in await RekoDb.CastMembers.Where(x => castMemberIds.Contains(x.Id)).ToArrayAsync(cancellationToken))
            {
                CastMembers.Add(entity.Id, entity);
            }

            foreach (var entity in await RekoDb.CrewMembers.Where(x => crewMembersIds.Contains(x.Id)).ToArrayAsync(cancellationToken))
            {
                CrewMembers.Add(entity.Id, entity);
            }

            await SetEntityData(container);
        }

        protected abstract Task SetEntityData(TContainer container);

        public IEnumerable<ProductionCompany> GetEntityProductionCompanies(IEnumerable<int> ids)
        {
            return ids == null ? Enumerable.Empty<ProductionCompany>() : ids.Select(x => ProductionCompanies[x]);
        }

        public IEnumerable<Genre> GetEntityGenres(IEnumerable<int> ids)
        {
            return ids == null ? Enumerable.Empty<Genre>() : ids.Select(x => Genres[x]);
        }

        public IEnumerable<KeyWord> GetEntityKeyWords(IEnumerable<int> ids)
        {
            return ids == null ? Enumerable.Empty<KeyWord>() : ids.Select(x => KeyWords[x]);
        }

        public IEnumerable<Video> GetEntityVideos(IEnumerable<string> ids)
        {
            return ids == null ? Enumerable.Empty<Video>() : ids.Select(x => Videos[x]);
        }

        public IEnumerable<CrewMember> GetEntityCrewMembers(IEnumerable<int> ids)
        {
            return ids == null ? Enumerable.Empty<CrewMember>() : ids.Select(x => CrewMembers[x]);
        }

        public IEnumerable<CastMember> GetEntityCastMembers(IEnumerable<int> ids)
        {
            return ids == null ? Enumerable.Empty<CastMember>() : ids.Select(x => CastMembers[x]);
        }
    }
}