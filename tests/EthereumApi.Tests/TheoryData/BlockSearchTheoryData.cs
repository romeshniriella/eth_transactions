using System.Collections.Generic;
using System.Net.Http;
using EthereumApi.Framework.DTO;

namespace EthereumApi.Tests.TheoryData
{
    public class BlockSearchTheoryData : BaseTheoryData
    {
        public Queue<HttpResponseMessage> BlockSearchResponses { get; set; }
        public List<HttpRequestMessage> ExpectedBlockNumberRequests { get; set; }
        public List<Transaction> ExpectedTransactions { get; set; }
    }
}