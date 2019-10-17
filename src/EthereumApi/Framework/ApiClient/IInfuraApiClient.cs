using System.Threading.Tasks;
using EthereumApi.Framework.DTO;

namespace EthereumApi.Framework.ApiClient
{
    public interface IInfuraApiClient
    {
        Task<BlockResult> GetBlockByNumber(string hexBlockNumber);
    }
}