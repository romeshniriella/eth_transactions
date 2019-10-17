using System.Collections.Generic;

namespace EthereumApi.Framework.DTO
{
    public class BlockResult
    {
        public BlockResult()
        {
            Transactions = new List<Transaction>();
        }

        public static BlockResult Empty => new BlockResult { ResultStatus = ResultStatus.Failed };
        public ResultStatus ResultStatus { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}