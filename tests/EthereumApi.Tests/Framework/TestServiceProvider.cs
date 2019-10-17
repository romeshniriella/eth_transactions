using System;
using Microsoft.Extensions.DependencyInjection;
using EthereumApi.Controllers;
using EthereumApi.Framework.ApiClient;
using EthereumApi.Framework.Services;
using EthereumApi.Tests.TestDoubles;

namespace EthereumApi.Tests.Framework
{
    public class TestServiceProvider
    {
        public static IServiceProvider Build(Action<IServiceCollection> setup)
        {
            IServiceCollection services = new ServiceCollection()
                .AddSingleton<IInfuraApiClient, NotImplementedInfuraApiClient>()
                .AddSingleton<ITransactionService, TransactionService>()
                .AddSingleton<TransactionsController>();

            setup(services);

            return services.BuildServiceProvider(true);
        }
    }
}