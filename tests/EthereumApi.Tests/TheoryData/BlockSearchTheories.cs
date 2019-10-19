using System;
using System.Collections.Generic;
using EthereumApi.Framework.DTO;
using Xunit;

namespace EthereumApi.Tests.TheoryData
{
    public class BlockSearchTheories : TheoryData<string, BlockSearchTheoryData>
    {
        public BlockSearchTheories()
        {
            AddTransactionContainsFromAddress();
            AddTransactionContainsToAddress();
            AddTransactionDoesNoContainAddress();
            AddNoTransactionResults();
        }

        private void AddNoTransactionResults()
        {
            Add("block search result from API with no transactions", new BlockSearchTheoryData
            {
                BlockNumber = 8754823,
                Address = "0xdummy",
                BlockSearchResponses = new Queue<BlockResult>(new BlockResult[]
                {
                    new BlockResult
                    {
                        ResultStatus = ResultStatus.Success,
                        Transactions = new List<Transaction>()
                    },
                }),
                ExpectedBlockNumberRequests = new List<string>
                {
                    "0x859687"
                },
                ExpectedTransactions = new List<Transaction>()
            });
        }

        private void AddTransactionContainsFromAddress()
        {
            Add("block search result from API with valid From address", new BlockSearchTheoryData
            {
                BlockNumber = 8754823,
                Address = "0xdummy",
                BlockSearchResponses = new Queue<BlockResult>(new BlockResult[]
                {
                    new BlockResult
                    {
                        ResultStatus = ResultStatus.Success,
                        Transactions = new List<Transaction>
                        {
                            new Transaction
                            {
                                BlockHash = "0x599e122c8f70686f70a1aee81558c61f0ec37ba943c05827e13b6b7028d7d3ba",
                                HexBlockNumber = "0x859687",
                                From = "0xc55eddadee",
                                Gas = "0x53a0",
                                To = "0x9fd8dabe3706a572c5c62c973518bb55182d097b",
                                Hash = "0xa811eee3c5d2ac931a4db47b0abaee840bd9f3b7edc6e9667e4b38adcaa13a88",
                                HexValue = "0x2a51071c1b000"
                            }
                        }
                    },
                }),
                ExpectedBlockNumberRequests = new List<string>
                {
                    "0x859687"
                },
                ExpectedTransactions = new List<Transaction>
                {
                }
            });
        }

        private void AddTransactionContainsToAddress()
        {
            Add("block search result from API with valid To address", new BlockSearchTheoryData
            {
                BlockNumber = 8754823,
                Address = "0xc55eddadee",
                BlockSearchResponses = new Queue<BlockResult>(new BlockResult[]
                {
                    new BlockResult
                    {
                        ResultStatus = ResultStatus.Success,
                        Transactions = new List<Transaction>
                        {
                            new Transaction
                            {
                                BlockHash = "0x599e122c8f70686f70a1aee81558c61f0ec37ba943c05827e13b6b7028d7d3ba",
                                HexBlockNumber = "0x859687",
                                From = "0xfrom",
                                Gas = "0x53a0",
                                To = "0xc55eddadee",
                                Hash = "0xa811eee3c5d2ac931a4db47b0abaee840bd9f3b7edc6e9667e4b38adcaa13a88",
                                HexValue = "0x2a51071c1b000"
                            }
                        }
                    },
                }),
                ExpectedBlockNumberRequests = new List<string>
                {
                    "0x859687"
                },
                ExpectedTransactions = new List<Transaction>
                {
                    new Transaction
                    {
                        BlockHash = "0x599e122c8f70686f70a1aee81558c61f0ec37ba943c05827e13b6b7028d7d3ba",
                        HexBlockNumber = "0x859687",
                        From = "0xfrom",
                        Gas = "0x53a0",
                        To = "0xc55eddadee",
                        Hash = "0xa811eee3c5d2ac931a4db47b0abaee840bd9f3b7edc6e9667e4b38adcaa13a88",
                        HexValue = "0x2a51071c1b000"
                    }
                }
            });
        }

        private void AddTransactionDoesNoContainAddress()
        {
            Add("block search result from API with address does not exist", new BlockSearchTheoryData
            {
                BlockNumber = 8754823,
                Address = "0xc55eddadee",
                BlockSearchResponses = new Queue<BlockResult>(new BlockResult[]
                {
                    new BlockResult
                    {
                        ResultStatus = ResultStatus.Success,
                        Transactions = new List<Transaction>
                        {
                            new Transaction
                            {
                                BlockHash = "0x599e122c8f70686f70a1aee81558c61f0ec37ba943c05827e13b6b7028d7d3ba",
                                HexBlockNumber = "0x859687",
                                From = "0xc55eddadee",
                                Gas = "0x53a0",
                                To = "0x9fd8dabe3706a572c5c62c973518bb55182d097b",
                                Hash = "0xa811eee3c5d2ac931a4db47b0abaee840bd9f3b7edc6e9667e4b38adcaa13a88",
                                HexValue = "0x2a51071c1b000"
                            }
                        }
                    },
                }),
                ExpectedBlockNumberRequests = new List<string>
                {
                    "0x859687"
                },
                ExpectedTransactions = new List<Transaction>
                {
                    new Transaction
                    {
                        BlockHash = "0x599e122c8f70686f70a1aee81558c61f0ec37ba943c05827e13b6b7028d7d3ba",
                        HexBlockNumber = "0x859687",
                        From = "0xc55eddadee",
                        Gas = "0x53a0",
                        To = "0x9fd8dabe3706a572c5c62c973518bb55182d097b",
                        Hash = "0xa811eee3c5d2ac931a4db47b0abaee840bd9f3b7edc6e9667e4b38adcaa13a88",
                        HexValue = "0x2a51071c1b000"
                    }
                }
            });
        }
    }
}