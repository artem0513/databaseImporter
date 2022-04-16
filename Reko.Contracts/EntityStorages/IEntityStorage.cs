using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Reko.Contracts.Containers;
using Reko.Data.Entities;
using Reko.Models.Dto;

namespace Reko.Contracts.EntityStorages
{
    public interface IEntityStorage<in TContainer, TDto, TId> where TContainer : IUniqueDataContainer<TDto, TId> where TDto : BaseDto<TId>
    {
        Task SetData(TContainer container, CancellationToken cancellationToken);
        IEnumerable<CastMember> GetEntityCastMembers(IEnumerable<int> ids);
        IEnumerable<CrewMember> GetEntityCrewMembers(IEnumerable<int> ids);
        IEnumerable<Video> GetEntityVideos(IEnumerable<string> ids);
        IEnumerable<KeyWord> GetEntityKeyWords(IEnumerable<int> ids);
        IEnumerable<Genre> GetEntityGenres(IEnumerable<int> ids);
        IEnumerable<ProductionCompany> GetEntityProductionCompanies(IEnumerable<int> ids);
        void Clear();
    }
}