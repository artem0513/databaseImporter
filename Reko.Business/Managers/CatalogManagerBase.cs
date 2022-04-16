using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Reko.Contracts.Containers;
using Reko.Contracts.Managers;
using Reko.Contracts.Repositories;
using Reko.Data;
using Reko.Models.Dto;
using Serilog;

namespace Reko.Business.Managers
{
    public abstract class CatalogManagerBase<TEntity, TContainer, TDto, TRepository, TId> : CRUDManager<TEntity, TDto, TRepository, TId>, ICatalogManager<TDto>
        where TRepository : class, ILinkRepository<TContainer, TDto, TId>, ICRUDRepository<TDto, TId>
        where TDto : BaseDto<TId>
        where TEntity : class, IMappableEntity<TEntity, TDto, TId>
        where TContainer : IUniqueDataContainer<TDto, TId>
    {
        protected TContainer Container { get; }
        protected ILogger Logger { get; }

        protected CatalogManagerBase(TRepository repository, TContainer container, ILogger logger) : base(repository)
        {
            Container = container;
            Logger = logger;
        }

        protected abstract Task SaveChildObjects(TContainer container, CancellationToken cancellationToken);

        public async Task SaveData(IEnumerable<TDto> data, CancellationToken cancellationToken)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            var materializedData = data.Distinct().ToArray();
            var ids = (await Repository.AddIfNotExistentAndGetIds(materializedData, cancellationToken)).ToArray();
            if (ids.Length != 0)
            {
                Logger.Information("Saving ids of " + typeof(TDto).Name + " " + string.Join(',', ids));
                Container.SetData(materializedData.Where(x => ids.Contains(x.Id)));
                await SaveChildObjects(Container, cancellationToken);
                await LinkData(Container, cancellationToken);
                Logger.Information("Saving was successful.");
            }
        }

        public async Task LinkData(TContainer container, CancellationToken cancellationToken)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            Logger.Information("Linking data...");
            await Repository.LinkData(container, cancellationToken);
            Logger.Information("Data was linked successfully...");
        }
    }
}