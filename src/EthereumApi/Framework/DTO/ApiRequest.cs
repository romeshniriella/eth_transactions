using Newtonsoft.Json;

namespace EthereumApi.Framework.DTO
{
    public class ApiRequest : BaseApiDto
    {
        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("params")]
        public object[] Params { get; set; }
    }
}