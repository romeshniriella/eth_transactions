using Newtonsoft.Json;

namespace EthereumApi.Framework.DTO
{
    public class GetBlockByNumberResult : BaseApiDto
    {
        [JsonProperty("result")]
        public Result Result { get; set; }
    }
}