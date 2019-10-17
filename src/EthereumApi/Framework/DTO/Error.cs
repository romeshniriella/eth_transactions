using Newtonsoft.Json;

namespace EthereumApi.Framework.DTO
{
    public class Error
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}