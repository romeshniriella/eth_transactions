using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace EthereumApi.Tests.TestDoubles
{
    public class InfuraApiDelegatingHandler : DelegatingHandler
    {
        public InfuraApiDelegatingHandler()
        {
            BlockNumberRequests = new List<HttpRequestMessage>();
        }

        public List<HttpRequestMessage> BlockNumberRequests { get; }

        private Queue<HttpResponseMessage> ResponseQueue { get; set; }

        public InfuraApiDelegatingHandler WithResponses(Queue<HttpResponseMessage> responseQueue)
        {
            ResponseQueue = responseQueue;

            return this;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            BlockNumberRequests.Add(request);

            return Task.FromResult(ResponseQueue.Dequeue());
        }
    }
}