using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EthereumApi.Framework.DTO
{
    public abstract class BaseApiDto
    {
        protected BaseApiDto()
        {
            JsonRpc = "2.0";
        }

        [JsonProperty("error")]
        public Error Error { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("jsonrpc")]
        public string JsonRpc { get; }
    }
}