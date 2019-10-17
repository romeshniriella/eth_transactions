using System.Collections.Generic;
using System.Threading.Tasks;
using EthereumApi.Framework.DTO;

namespace EthereumApi.Framework.Services
{
    public interface ITransactionService
    {
        Task<List<Transaction>> SearchTransactions(string hexBlockNumber, string address);
    }
}