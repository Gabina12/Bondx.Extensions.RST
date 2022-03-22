using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bondx.Extensions.RST.Mediator
{
    public class HttpContextMediator : IMediator
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly ILinkedCancellationTokenFactory _linkedCancellationTokenFactory;

        private readonly IMediator _native;

        public HttpContextMediator(IMediator native, IHttpContextAccessor httpContextAccessor, ILinkedCancellationTokenFactory linkedCancellationTokenFactory)
        {
            _httpContextAccessor = httpContextAccessor;
            _linkedCancellationTokenFactory = linkedCancellationTokenFactory;
            _native = native;
        }

        public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = new CancellationToken())
        {
            return _native.Send(request, CreateLinkedToken(cancellationToken));
        }

        public Task<object> Send(object request, CancellationToken cancellationToken = new CancellationToken())
        {
            return _native.Send(request, CreateLinkedToken(cancellationToken));
        }

        public Task Publish(object notification, CancellationToken cancellationToken = new CancellationToken())
        {
            return _native.Publish(notification, CreateLinkedToken(cancellationToken));
        }

        public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = new CancellationToken())
            where TNotification : INotification
        {
            return _native.Publish(notification, CreateLinkedToken(cancellationToken));
        }

        public IAsyncEnumerable<TResponse> CreateStream<TResponse>(IStreamRequest<TResponse> request, CancellationToken cancellationToken = new CancellationToken())
        {
            return _native.CreateStream(request, CreateLinkedToken(cancellationToken));
        }

        public IAsyncEnumerable<object> CreateStream(object request, CancellationToken cancellationToken = new CancellationToken())
        {
            return _native.CreateStream(request, CreateLinkedToken(cancellationToken));
        }

        private CancellationToken CreateLinkedToken(CancellationToken cancellationToken)
        {
            var httpContext = _httpContextAccessor.HttpContext;

            return httpContext != null ? _linkedCancellationTokenFactory.Create(cancellationToken, httpContext.RequestAborted) : cancellationToken;
        }
    }
}
