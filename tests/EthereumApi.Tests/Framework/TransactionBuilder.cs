using System;
using EthereumApi.Framework.DTO;

namespace EthereumApi.Tests.Framework
{
    public class RandomBuilder
    {
        private static Random _random = new Random();

        public static string NextHexString()
        {
            return "0x" + _random.Next().ToString("x");
        }
    }

    public class TransactionBuilder
    {
        private Action<Transaction> _setup;

        public TransactionBuilder()
        {
            _setup = c => { };

            WithFromAddress(RandomBuilder.NextHexString());
            WithToAddress(RandomBuilder.NextHexString());
            WithBlockNumber(RandomBuilder.NextHexString());
        }

        public static implicit operator Transaction(TransactionBuilder builder) => builder.Build();

        public Transaction Build()
        {
            var Transaction = new Transaction();
            _setup(Transaction);

            return Transaction;
        }

        public TransactionBuilder WithBlockNumber(string blockNumber)
        {
            _setup += c => c.HexBlockNumber = blockNumber;

            return this;
        }

        public TransactionBuilder WithFromAddress(string from)
        {
            _setup += c => c.From = from;

            return this;
        }

        public TransactionBuilder WithToAddress(string to)
        {
            _setup += c => c.To = to;

            return this;
        }
    }
}