using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace EthereumApi.Framework.Services
{
    public enum ResultStatus
    {
        Success,
        Failed
    }

    public interface IInfuraApiClient
    {
        Task<List<EthereumTransaction>> SearchBlock(string blockAddress);
    }

    public class ApplicationSettings
    {
        public string ProjectId { get; set; }
    }

    public class Block
    {
        public string gasLimit { get; set; }
        public string hash { get; set; }
        public string number { get; set; }
        /*
         * number: the block number. Null when the returned block is the pending block.
            hash: 32 Bytes - hash of the block. Null when the returned block is the pending block.
            parentHash: 32 Bytes - hash of the parent block.
            nonce: 8 Bytes - hash of the generated proof-of-work. Null when the returned block is the pending block.
            sha3Uncles: 32 Bytes - SHA3 of the uncles data in the block.
            logsBloom: 256 Bytes - the bloom filter for the logs of the block. Null when the returned block is the pending block.
            transactionsRoot: 32 Bytes - the root of the transaction trie of the block.
            stateRoot: 32 Bytes - the root of the final state trie of the block.
            receiptsRoot: 32 Bytes - the root of the receipts trie of the block.
            miner: 20 Bytes - the address of the beneficiary to whom the mining rewards were given.
            difficulty: integer of the difficulty for this block.
            totalDifficulty: integer of the total difficulty of the chain until this block.
            extraData: the "extra data" field of this block.
            size: integer the size of this block in bytes.
            gasLimit: the maximum gas allowed in this block.
            gasUsed: the total used gas by all transactions in this block.
            timestamp: the unix timestamp for when the block was collated.
            transactions: Array - Array of transaction objects, or 32 Bytes transaction hashes depending on the last given parameter.
            uncles: an Array of uncle hashes.
         */
    }

    public class EthereumTransaction
    {
        public string BlockHash { get; set; }
        public string BlockNumber { get; set; }
        public string From { get; set; }
        public string Gas { get; set; }
        public string Hash { get; set; }
        public string To { get; set; }
        public string Value { get; set; }
    }

    public class InfuraApiApiClient : IInfuraApiClient
    {
        private readonly HttpClient _client;
        private readonly string _projectId;

        public InfuraApiApiClient(HttpClient client, IOptions<ApplicationSettings> settingsOptions)
        {
            _client = client;
            _projectId = settingsOptions.Value.ProjectId;
        }

        public async Task<List<EthereumTransaction>> SearchBlock(string blockAddress)
        {
            //eth_accounts -> get addresses
            // OR
            // what's an address look like? Is it the block number? can I directly use the following method?
            //      or is there another method to get a block by address?

            //eth_getBlockByNumber
            //eth_getTransactionByHash

            // POST https://<network>.infura.io/v3/YOUR-PROJECT-ID
            /*
             curl https://mainnet.infura.io/v3/YOUR-PROJECT-ID \
                -X POST \
                -H "Content-Type: application/json" \
                -d '{"jsonrpc":"2.0","method":"eth_getBlockByNumber","params": ["0x5BAD55",false],"id":1}'
             */
            var request = new Request
            {
                Id = 1,
                Method = "eth_getBlockByNumber",
                Params = new[]
                {
                    "0x5BAD55" // BLOCK PARAMETER
                    , "true" // SHOW TRANSACTION DETAILS FLAG
                }
            };

            var response = await _client.PostAsync("", new StringContent(JsonConvert.SerializeObject(request)));

            return await response.Content.ReadAsAsync<List<EthereumTransaction>>();
        }
    }

    public class Request : RequestBase
    {
        public string Method { get; set; }
        public string[] Params { get; set; }
    }

    public abstract class RequestBase
    {
        protected RequestBase()
        {
            JsonRpc = "2.0";
        }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("jsonrpc")]
        public string JsonRpc { get; }
    }

    public class SearchResult
    {
        public List<EthereumTransaction> EthereumTransactions { get; set; }
        public ResultStatus ResultStatus { get; set; }
    }
}