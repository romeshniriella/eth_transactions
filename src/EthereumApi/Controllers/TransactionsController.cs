using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EthereumApi.Framework.Services;

namespace EthereumApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly IInfuraApiClient _infuraApiClient;

        public TransactionsController(IInfuraApiClient infuraApiClient)
        {
            _infuraApiClient = infuraApiClient;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<EthereumTransaction>>> Get(string id)
        {
            return await _infuraApiClient.SearchBlock(id);
        }
    }
}