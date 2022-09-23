using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;

namespace Bondx.Extensions.RST.ApiEndpoints;

public static class RSTEndpointAsync
{
    public static class WithRequest<TRequest>
    {
        public abstract class WithResult<TResponse> : RSTEndpointBase
        {
            public abstract Task<TResponse> HandleAsync(
                TRequest request,
                CancellationToken cancellationToken = default
            );
        }

        public abstract class WithoutResult : RSTEndpointBase
        {
            public abstract Task HandleAsync(
                TRequest request,
                CancellationToken cancellationToken = default
            );
        }

        public abstract class WithActionResult<TResponse> : RSTEndpointBase
        {
            public abstract Task<ActionResult<TResponse>> HandleAsync(
                TRequest request,
                CancellationToken cancellationToken = default
            );
        }

        public abstract class WithActionResult : RSTEndpointBase
        {
            public abstract Task<ActionResult> HandleAsync(
                TRequest request,
                CancellationToken cancellationToken = default
            );
        }
    }

    public static class WithoutRequest
    {
        public abstract class WithResult<TResponse> : RSTEndpointBase
        {
            public abstract Task<TResponse> HandleAsync(
                CancellationToken cancellationToken = default
            );
        }

        public abstract class WithoutResult : RSTEndpointBase
        {
            public abstract Task HandleAsync(
                CancellationToken cancellationToken = default
            );
        }

        public abstract class WithActionResult<TResponse> : RSTEndpointBase
        {
            public abstract Task<ActionResult<TResponse>> HandleAsync(
                CancellationToken cancellationToken = default
            );
        }

        public abstract class WithActionResult : RSTEndpointBase
        {
            public abstract Task<ActionResult> HandleAsync(
                CancellationToken cancellationToken = default
            );
        }
    }
}
