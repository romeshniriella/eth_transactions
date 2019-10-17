using System.Threading.Tasks;
using Xunit;

namespace EthereumApi.Tests
{
    public class InvalidInputTheories : TheoryData<string, InvalidInputTheoryData>
    {
    }

    public class InvalidInputTheoryData
    {
    }

    public class TestServiceProvider
    {
    }

    public class When_Searching_For_A_Block
    {
        public class And_The_Data_Is_Invalid
        {
            [Theory]
            [ClassData(typeof(InvalidInputTheories))]
            public async Task It_Throws_Exceptions(string description, InvalidInputTheoryData theoryData)
            {
            }
        }
    }
}