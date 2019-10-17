using System.Collections.Generic;
using Newtonsoft.Json;

namespace EthereumApi.Framework.DTO
{
    public class Result
    {
        [JsonProperty("transactions")]
        public List<Transaction> Transactions { get; set; }
    }
}