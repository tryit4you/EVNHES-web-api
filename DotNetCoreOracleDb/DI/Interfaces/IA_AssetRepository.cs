using DotNetCoreOracleDb.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreOracleDb.DI.Interfaces
{
    public interface IA_AssetRepository
    {
        Task<IEnumerable<A_ASSETS>> A_ASSETs();
        Task<A_ASSETS> GetASSETS(string id);
        bool Remove(string id);
        bool Update(A_ASSETS a_ASSETS);
        bool Create(A_ASSETS a_ASSETS);
    }
}
