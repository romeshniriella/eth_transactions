using System.Threading.Tasks;
using EthereumApi.Controllers;
using EthereumApi.Tests.Fixtures;
using EthereumApi.Tests.TestDoubles;
using EthereumApi.Tests.TheoryData;
using FluentAssertions;
using Xunit;

namespace EthereumApi.Tests
{
    public class When_Searching_For_A_Block
    {
        public class And_The_Data_Is_Invalid
        {
            [Theory]
            [ClassData(typeof(InvalidInputTheories))]
            public async Task It_Throws_Exceptions(string description, InvalidInputTheoryData theoryData)
            {
                InfuraApiClientSpy apiClientSpy = new InfuraApiClientSpy()
                    .WithResponses(theoryData.BlockSearchResponses);

                TransactionsController sut = new TransactionsControllerFixture()
                    .WithInfuraApiClient(apiClientSpy)
                    .CreateSut();

                await Assert.ThrowsAsync(
                    theoryData.ExpectedExceptionType,
                    () => sut.Get(theoryData.BlockNumber, theoryData.Address));

                apiClientSpy.BlockNumberRequests.Should()
                    .BeEquivalentTo(theoryData.ExpectedBlockNumberRequests, description);
            }
        }
    }
}