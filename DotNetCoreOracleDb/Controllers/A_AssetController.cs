using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreOracleDb.Data.Models;
using DotNetCoreOracleDb.DI.Interfaces;
using DotNetCoreOracleDb.DI.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNetCoreOracleDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class A_AssetController : ControllerBase
    {
        private readonly A_AssetRepository _asset;
        public A_AssetController()
        {
            _asset = new A_AssetRepository();
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<A_ASSETS> assets = new List<A_ASSETS>();
            assets = await _asset.A_ASSETs();
            return Ok(assets);
        }
        [HttpGet("{assetid}")]
        public async Task<IActionResult> GetAsset(string assetid)
        {
            A_ASSETS aSSETS = new A_ASSETS();
            aSSETS = await _asset.GetASSETS(assetid);
            if (assetid == null)
                return BadRequest();
            if (aSSETS == null)
                return NotFound();

            return Ok(aSSETS);
        }
    }
}
