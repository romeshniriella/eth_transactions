using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using EthereumApi.Framework.DTO;
using EthereumApi.Tests.Framework;
using Newtonsoft.Json;
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
        }

        private void AddTransactionContainsFromAddress()
        {
            string fromAddress = RandomBuilder.NextHexString();
            string toAddress = RandomBuilder.NextHexString();
            string blockNumberHex = "0x859687";

            Add("block search result from API with valid From address", new BlockSearchTheoryData
            {
                BlockNumber = 8754823,
                Address = fromAddress,
                BlockSearchResponses = new Queue<HttpResponseMessage>(new[]
                {
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent(JsonConvert.SerializeObject(new GetBlockByNumberResult
                        {
                            Result = new Result
                            {
                                Transactions = new List<Transaction>
                                {
                                    new TransactionBuilder()
                                        .WithBlockNumber(blockNumberHex)
                                        .WithFromAddress(fromAddress)
                                        .WithToAddress(toAddress),
                                    new TransactionBuilder(),
                                    new TransactionBuilder()
                                }
                            }
                        }), Encoding.UTF8, "application/json")
                    },
                }),
                ExpectedBlockNumberRequests = new List<HttpRequestMessage>
                {
                    new HttpRequestMessage(HttpMethod.Post, "http://localhost.test.svr/")
                    {
                        Content = new StringContent(JsonConvert.SerializeObject(new ApiRequest
                        {
                            Id = 1,
                            Method = "eth_getBlockByNumber",
                            Params = new object[]
                            {
                                blockNumberHex
                                , true
                            }
                        }))
                    }
                },
                ExpectedTransactions = new List<Transaction>
                {
                    new TransactionBuilder()
                        .WithBlockNumber(blockNumberHex)
                        .WithFromAddress(fromAddress)
                        .WithToAddress(toAddress)
                }
            });
        }

        private void AddTransactionContainsToAddress()
        {
            string fromAddress = RandomBuilder.NextHexString();
            string toAddress = RandomBuilder.NextHexString();
            string blockNumberHex = "0x859687";

            Add("block search result from API with valid From address", new BlockSearchTheoryData
            {
                BlockNumber = 8754823,
                Address = toAddress,
                BlockSearchResponses = new Queue<HttpResponseMessage>(new[]
                {
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent(JsonConvert.SerializeObject(new GetBlockByNumberResult
                        {
                            Result = new Result
                            {
                                Transactions = new List<Transaction>
                                {
                                    new TransactionBuilder()
                                        .WithBlockNumber(blockNumberHex)
                                        .WithFromAddress(fromAddress)
                                        .WithToAddress(toAddress),
                                    new TransactionBuilder(),
                                    new TransactionBuilder()
                                }
                            }
                        }), Encoding.UTF8, "application/json")
                    },
                }),
                ExpectedBlockNumberRequests = new List<HttpRequestMessage>
                {
                    new HttpRequestMessage(HttpMethod.Post, "http://localhost.test.svr/")
                    {
                        Content = new StringContent(JsonConvert.SerializeObject(new ApiRequest
                        {
                            Id = 1,
                            Method = "eth_getBlockByNumber",
                            Params = new object[]
                            {
                                blockNumberHex
                                , true
                            }
                        }))
                    }
                },
                ExpectedTransactions = new List<Transaction>
                {
                    new TransactionBuilder()
                        .WithBlockNumber(blockNumberHex)
                        .WithFromAddress(fromAddress)
                        .WithToAddress(toAddress)
                }
            });
        }

        private void AddTransactionDoesNoContainAddress()
        {
            Add("block search result from API with address does not exist", new BlockSearchTheoryData
            {
                BlockNumber = 8754823,
                Address = "0xdummy",
                BlockSearchResponses = new Queue<HttpResponseMessage>(new[]
                {
                    new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent(JsonConvert.SerializeObject(new GetBlockByNumberResult
                        {
                            Result = new Result
                            {
                                Transactions = new List<Transaction>
                                {
                                    new TransactionBuilder(),
                                    new TransactionBuilder(),
                                    new TransactionBuilder()
                                }
                            }
                        }), Encoding.UTF8, "application/json")
                    },
                }),
                ExpectedBlockNumberRequests = new List<HttpRequestMessage>
                {
                    new HttpRequestMessage(HttpMethod.Post, "http://localhost.test.svr/")
                    {
                        Content = new StringContent(JsonConvert.SerializeObject(new ApiRequest
                        {
                            Id = 1,
                            Method = "eth_getBlockByNumber",
                            Params = new object[]
                            {
                                "0x859687"
                                , true
                            }
                        }))
                    }
                },
                ExpectedTransactions = new List<Transaction>()
            });
        }
    }
}