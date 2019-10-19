using System.Collections.Generic;
using EthereumApi.Framework.DTO;

namespace EthereumApi.Tests.TheoryData
{
    public abstract class BaseTheoryData
    {
        public string Address { get; set; }
        public int BlockNumber { get; set; }
    }
}