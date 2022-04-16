using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reko.Contracts.ApiRequestFramework
{
    public interface IDiscoveryApiRequest<T>
    {
        Task<IEnumerable<T>> GetIds(DateTime date);
    }
}