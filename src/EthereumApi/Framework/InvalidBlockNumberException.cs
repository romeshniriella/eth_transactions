using System;

namespace EthereumApi.Framework
{
    public class InvalidBlockNumberException : Exception
    {
        public InvalidBlockNumberException(string blockNumber)
            : base($"Invalid block number: {blockNumber}")
        { }
    }
}