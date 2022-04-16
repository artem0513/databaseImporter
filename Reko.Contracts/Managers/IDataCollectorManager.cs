using System;
using System.Threading.Tasks;
using Reko.Models.Models;

namespace Reko.Contracts.Managers
{
    public interface IDataCollectorManager
    {
        string Collect(DateTime from, DateTime to);
    }
}