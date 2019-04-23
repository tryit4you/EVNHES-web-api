using DotNetCoreOracleDb.Data.Models;
using DotNetCoreOracleDb.DI.Interfaces;
using DotNetCoreOracleDb.Helper;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreOracleDb.DI.Repositories
{
    public class A_AssetRepository : IA_AssetRepository
    {
        private readonly AdoHelper _helper;
        private readonly IConfiguration configuration;
        public A_AssetRepository()
        {
            _helper = new AdoHelper(configuration);
        }
        public IEnumerable<A_ASSETS> A_ASSETs()
        {
            List<A_ASSETS> a_assets = new List<A_ASSETS>();
            string query = "select * from A_ASSET";
            OracleDataReader reader= _helper.ExecDataReader(query);
            while (reader.Read())
            {
                A_ASSETS a_asset = new A_ASSETS
                {
                    A_ASSETID = reader["ASSETID"].ToString(),
                    A_ASSETNAME = reader["ASSETDESC"].ToString()
                };
                a_assets.Add(a_asset);
            }
            reader.Close();
            return a_assets;
        }

        public A_ASSETS GetASSETS(string id)
        {
            A_ASSETS a_asset = new A_ASSETS();
            string query = "select * from A_ASSET where";

        }
    }
}
