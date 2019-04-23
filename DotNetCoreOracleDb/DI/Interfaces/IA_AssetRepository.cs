using DotNetCoreOracleDb.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreOracleDb.DI.Interfaces
{
    public interface IA_AssetRepository
    {
        IEnumerable<A_ASSETS> A_ASSETs();
        A_ASSETS GetASSETS(string id);
    }
}
