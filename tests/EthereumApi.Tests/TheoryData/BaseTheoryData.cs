using System.Collections.Generic;
using EthereumApi.Framework.DTO;

namespace EthereumApi.Tests.TheoryData
{
    public abstract class BaseTheoryData
    {
        protected BaseTheoryData()
        {
            ExpectedBlockNumberRequests = new List<string>();
        }

        public string Address { get; set; }
        public int BlockNumber { get; set; }
        public Queue<BlockResult> BlockSearchResponses { get; set; }
        public List<string> ExpectedBlockNumberRequests { get; set; }
    }
}