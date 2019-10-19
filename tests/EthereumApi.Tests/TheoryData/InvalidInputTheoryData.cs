using System;
using System.Collections.Generic;
using EthereumApi.Framework.DTO;

namespace EthereumApi.Tests.TheoryData
{
    public class InvalidInputTheoryData : BaseTheoryData
    {
        public InvalidInputTheoryData()
        {
            ExpectedBlockNumberRequests = new List<string>();
        }

        public Queue<BlockResult> BlockSearchResponses { get; set; }
        public List<string> ExpectedBlockNumberRequests { get; set; }
        public Type ExpectedExceptionType { get; set; }
    }
}