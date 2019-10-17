using System;
using System.Collections.Generic;
using EthereumApi.Framework;
using EthereumApi.Framework.DTO;
using Xunit;

namespace EthereumApi.Tests.TheoryData
{
    public class InvalidInputTheories : TheoryData<string, InvalidInputTheoryData>
    {
        public InvalidInputTheories()
        {
            Add("invalid block number:0", new InvalidInputTheoryData
            {
                BlockNumber = 0,
                ExpectedExceptionType = typeof(ArgumentException)
            });
            Add("invalid block number:-1", new InvalidInputTheoryData
            {
                BlockNumber = -1,
                ExpectedExceptionType = typeof(ArgumentException)
            });
            Add("invalid address:null", new InvalidInputTheoryData
            {
                BlockNumber = 8754823,
                Address = null,
                ExpectedExceptionType = typeof(ArgumentException)
            });
            Add("invalid address:0", new InvalidInputTheoryData
            {
                BlockNumber = 8754823,
                Address = "0",
                ExpectedExceptionType = typeof(ArgumentException)
            });
            Add("invalid address:abc", new InvalidInputTheoryData
            {
                BlockNumber = 8754823,
                Address = "abc",
                ExpectedExceptionType = typeof(ArgumentException)
            });
            Add("invalid block result", new InvalidInputTheoryData
            {
                BlockNumber = 8754823,
                Address = "0xc55eddadee",
                BlockSearchResponses = new Queue<BlockResult>(new BlockResult[]
                {
                    BlockResult.Empty,
                }),
                ExpectedBlockNumberRequests = new List<string>
                {
                    "0x859687"
                },
                ExpectedExceptionType = typeof(InvalidBlockNumberException)
            });
        }
    }
}