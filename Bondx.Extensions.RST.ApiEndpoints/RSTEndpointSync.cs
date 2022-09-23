using Microsoft.AspNetCore.Mvc;

namespace Bondx.Extensions.RST.ApiEndpoints;

public static class RSTEndpointSync
{
    public static class WithRequest<TRequest>
    {
        public abstract class WithResult<TResponse> : RSTEndpointBase
        {
            public abstract TResponse Handle(TRequest request);
        }

        public abstract class WithoutResult : RSTEndpointBase
        {
            public abstract void Handle(TRequest request);
        }

        public abstract class WithActionResult<TResponse> : RSTEndpointBase
        {
            public abstract ActionResult<TResponse> Handle(TRequest request);
        }

        public abstract class WithActionResult : RSTEndpointBase
        {
            public abstract ActionResult Handle(TRequest request);
        }
    }

    public static class WithoutRequest
    {
        public abstract class WithResult<TResponse> : RSTEndpointBase
        {
            public abstract TResponse Handle();
        }

        public abstract class WithoutResult : RSTEndpointBase
        {
            public abstract void Handle();
        }

        public abstract class WithActionResult<TResponse> : RSTEndpointBase
        {
            public abstract ActionResult<TResponse> Handle();
        }

        public abstract class WithActionResult : RSTEndpointBase
        {
            public abstract ActionResult Handle();
        }
    }
}
