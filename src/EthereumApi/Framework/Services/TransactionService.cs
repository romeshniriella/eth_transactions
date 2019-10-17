using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EthereumApi.Framework.ApiClient;
using EthereumApi.Framework.DTO;

namespace EthereumApi.Framework.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IInfuraApiClient _apiClient;

        public TransactionService(IInfuraApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<Transaction>> SearchTransactions(string hexBlockNumber, string address)
        {
            var blockResult = await _apiClient.GetBlockByNumber(hexBlockNumber);

            if (blockResult.ResultStatus == ResultStatus.Failed)
            {
                throw new InvalidBlockNumberException(hexBlockNumber);
            }

            return blockResult.Transactions.Where(
                   t => t.From.Equals(address, StringComparison.OrdinalIgnoreCase)
                          || t.To.Equals(address, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}