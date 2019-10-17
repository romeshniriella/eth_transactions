using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using EthereumApi.Framework.DTO;
using Newtonsoft.Json;

namespace EthereumApi.Framework.ApiClient
{
    public class InfuraApiApiClient : IInfuraApiClient
    {
        private readonly HttpClient _client;
        private readonly ILogger<InfuraApiApiClient> _logger;

        public InfuraApiApiClient(HttpClient client, ILogger<InfuraApiApiClient> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<BlockResult> GetBlockByNumber(string hexBlockNumber)
        {
            //refer: https://infura.io/docs/ethereum/json-rpc/eth_getBlockByNumber
            var request = new ApiRequest
            {
                Id = 1,
                Method = "eth_getBlockByNumber",
                Params = new object[]
                {
                    hexBlockNumber // BLOCK PARAMETER
                    , true // SHOW TRANSACTION DETAILS FLAG
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

            _logger.LogError(block.Error?.Message ?? $"Could not find any results for {hexBlockNumber}");

            return BlockResult.Empty;
        }
    }
}