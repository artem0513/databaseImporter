using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reko.Contracts.Managers;
using Reko.Contracts.Repositories;
using Reko.Models.Dto;

namespace Reko.Business.Managers
{
    public abstract class CatalogManagerBase<TDto, TRepository> : ICatalogManager<TDto>
        where TRepository : class, ILinkRepository<TDto>, ICRUDRepository<TDto, int>
        where TDto : BaseDto<int>
    {
        protected TRepository Repository { get; }

        protected CatalogManagerBase(TRepository repository)
        {
            Repository = repository;
        }

        protected abstract void RemoveDuplicates(IEnumerable<TDto> data);

        public async Task SaveData(IEnumerable<TDto> data)
        {
            var materializedData = data.Distinct().ToArray();

            var ids = await Repository.AddIfNotExistent(materializedData);
            var dataToSave = materializedData.Where(x => ids.Contains(x.Id)).ToArray();

            RemoveDuplicates(dataToSave);
            await SaveChildObjects(dataToSave);
            await LinkData(dataToSave);
        }

        public async Task LinkData(ICollection<TDto> data)
        {
            await Repository.LinkData(data);
        }

        protected abstract Task SaveChildObjects(ICollection<TDto> data);
    }
}