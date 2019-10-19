using System.Collections.Generic;
using EthereumApi.Framework.DTO;

namespace EthereumApi.Tests.TheoryData
{
    public class BlockSearchTheoryData : BaseTheoryData
    {
        public List<Transaction> ExpectedTransactions { get; set; }
    }
}