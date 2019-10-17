using System.Collections.Generic;
using System.Threading.Tasks;
using EthereumApi.Framework.DTO;

namespace EthereumApi.Tests.TestDoubles
{
    public class InfuraApiClientSpy : NotImplementedInfuraApiClient
    {
        public InfuraApiClientSpy()
        {
            BlockNumberRequests = new List<string>();
        }

        public List<string> BlockNumberRequests { get; }
        public Queue<BlockResult> ResponseQueue { get; private set; }

        public override Task<BlockResult> GetBlockByNumber(string hexBlockNumber)
        {
            BlockNumberRequests.Add(hexBlockNumber);

            return Task.FromResult(ResponseQueue.Dequeue());
        }

        public InfuraApiClientSpy WithResponses(Queue<BlockResult> responseQueue)
        {
            ResponseQueue = responseQueue;

            return this;
        }
    }
}