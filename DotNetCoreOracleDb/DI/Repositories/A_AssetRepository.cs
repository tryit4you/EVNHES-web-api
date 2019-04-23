using DotNetCoreOracleDb.Data.Models;
using DotNetCoreOracleDb.DI.Interfaces;
using DotNetCoreOracleDb.Helper;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreOracleDb.DI.Repositories
{
    public class A_AssetRepository : IA_AssetRepository
    {
        private string query = string.Empty;
        private readonly AdoHelper _helper;
        private readonly IConfiguration configuration;
        public A_AssetRepository()
        {
            _helper = new AdoHelper(configuration);
        }
        public async Task<IEnumerable<A_ASSETS>> A_ASSETs()
        {
            List<A_ASSETS> a_assets = new List<A_ASSETS>();
            query = "select * from A_ASSET";
            OracleDataReader reader= _helper.ExecDataReader(query);
            while (await reader.ReadAsync())
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

        public bool Create(A_ASSETS a_ASSETS)
        {
            query = "insert into A_ASSET(ASSETID,ASSETDESC) VALUES(:ASSETID,:ASSETDESC)";
            object[] pars = new object[] {
                new OracleParameter("ASSETID", a_ASSETS.A_ASSETID),
                new OracleParameter("ASSETDESC", a_ASSETS.A_ASSETNAME)
            };
            int result= _helper.ExecNonQuery(query, pars);
            if (result != 0)
                return true;
            else
                return false;
        }

        public async Task<A_ASSETS> GetASSETS(string id)
        {
            A_ASSETS a_asset = null;
            query = "select * from A_ASSET where ASSETID=:ASSETID";
            object[] pars = new object[] { new OracleParameter("ASSETID", id) };
            OracleDataReader reader = _helper.ExecDataReader(query,pars);
            if(await reader.ReadAsync())
            {
                 a_asset = new A_ASSETS
                {
                    A_ASSETID = reader["ASSETID"].ToString(),
                    A_ASSETNAME = reader["ASSETDESC"].ToString()
                };
            }
            reader.Close();
            return a_asset;
        }

        public bool Remove(string id)
        {
            query = "delete from A_ASSET where ASSETID=:ASSETID";
            object[] pars = new object[] { new OracleParameter("ASSETID", id) };
            int result= _helper.ExecNonQuery(query, pars);
            if (result == 0)
                return false;
            else
                return true;
        }

        public bool Update(A_ASSETS aSSETS)
        {
            query = "UPDATE A_ASSET SET ASSETDESC=:ASSETDESC WHERE ASSETID=:ASSETID";
            object[] pars = new object[] {
                new OracleParameter("ASSETID", aSSETS.A_ASSETID),
                new OracleParameter("ASSETDESC", aSSETS.A_ASSETNAME)
            };
            int result = _helper.ExecNonQuery(query, pars);
            if (result == 0)
                return false;
            else
                return true;
        }
    }
}
