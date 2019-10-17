using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EthereumApi.Framework.DTO;
using Newtonsoft.Json;

namespace EthereumApi.Framework.ApiClient
{
    public class InfuraApiApiClient : IInfuraApiClient
    {
        private readonly HttpClient _client;

        public InfuraApiApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<BlockResult> GetBlockByNumber(string hexBlockNumber)
        {
            //refer: https://infura.io/docs/ethereum/json-rpc/eth_getBlockByNumber
            var request = new ApiRequest
            {
                Id = 1,
                Method = "eth_getBlockByNumber",
                Params = new[]
                {
                    hexBlockNumber // BLOCK PARAMETER
                    , "true" // SHOW TRANSACTION DETAILS FLAG
                }
            };

            var response = await _client.PostAsync("", new StringContent(JsonConvert.SerializeObject(request)));

            var block = await response.Content.ReadAsAsync<GetBlockByNumberResult>();

            if (block.Result?.Transactions != null && block.Result.Transactions.Any())
            {
                return new BlockResult
                {
                    ResultStatus = ResultStatus.Success,
                    Transactions = block.Result.Transactions
                };
            }

            return BlockResult.Empty;
        }
    }
}