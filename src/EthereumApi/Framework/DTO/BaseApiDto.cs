using Newtonsoft.Json;

namespace EthereumApi.Framework.DTO
{
    public abstract class BaseApiDto
    {
        protected BaseApiDto()
        {
            JsonRpc = "2.0";
        }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("jsonrpc")]
        public string JsonRpc { get; }
    }
}