using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using EthereumApi.Controllers;
using EthereumApi.Framework.ApiClient;
using EthereumApi.Tests.Framework;
using EthereumApi.Tests.TestDoubles;

namespace EthereumApi.Tests.Fixtures
{
    public class TransactionsControllerFixture
    {
        private Action<IServiceCollection> _setup;

        public TransactionsControllerFixture()
        {
            _setup = _ => { };
        }

        public TransactionsController CreateSut()
        {
            return TestServiceProvider
                .Build(_setup)
                .GetRequiredService<TransactionsController>();
        }

        public TransactionsControllerFixture WithInfuraApiClient(IInfuraApiClient apiClient)
        {
            _setup += services => services.Replace(ServiceDescriptor.Singleton(apiClient));

            return this;
        }

        public TransactionsControllerFixture WithInfuraApiClientHandler(InfuraApiDelegatingHandler apiClientHandler)
        {
            _setup += services => services
                .AddHttpClient<IInfuraApiClient, InfuraApiApiClient>(client => client.BaseAddress = new Uri("http://localhost.test.svr"))
                .AddHttpMessageHandler(() => apiClientHandler);

            return this;
        }
    }
}