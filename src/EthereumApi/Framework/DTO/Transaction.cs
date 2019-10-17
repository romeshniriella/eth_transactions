using System;
using System.Globalization;
using Newtonsoft.Json;

namespace EthereumApi.Framework.DTO
{
    public class Transaction
    {
        [JsonProperty("blockHash")]
        public string BlockHash { get; set; }

        public long BlockNumberValue => Convert.ToInt64(HexBlockNumber, 16);

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("gas")]
        public string Gas { get; set; }

        public long GasValue => Convert.ToInt64(Gas, 16);

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("blockNumber")]
        public string HexBlockNumber { get; set; }

        [JsonProperty("value")]
        public string HexValue { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        public long TransactionValue => Convert.ToInt64(HexValue, 16);
    }
}