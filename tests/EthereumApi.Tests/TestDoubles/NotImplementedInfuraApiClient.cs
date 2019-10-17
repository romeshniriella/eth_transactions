using System;
using System.Threading.Tasks;
using EthereumApi.Framework.ApiClient;
using EthereumApi.Framework.DTO;

namespace EthereumApi.Tests.TestDoubles
{
    public class NotImplementedInfuraApiClient : IInfuraApiClient
    {
        public virtual Task<BlockResult> GetBlockByNumber(string hexBlockNumber)
        {
            throw new NotImplementedException();
        }
    }
}