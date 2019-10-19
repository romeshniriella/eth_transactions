using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using EthereumApi.Framework.DTO;
using EthereumApi.Framework.Services;

namespace EthereumApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("{blockNumber}/{address}")]
        public async Task<ActionResult<List<Transaction>>> Get(int blockNumber, string address)
        {
            if (blockNumber <= 0)
            {
                throw new ArgumentException("Invalid block number");
            }

            if (string.IsNullOrEmpty(address))
            {
                throw new ArgumentException("Please provide the address");
            }

            if (!address.StartsWith("0x"))
            {
                throw new ArgumentException("Invalid address. Must start with 0x prefix");
            }

            return await _transactionService.SearchTransactions($"0x{blockNumber:x}", address);
        }
    }
}