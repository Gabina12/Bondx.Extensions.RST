using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace Bondx.Extensions.RST.Mediator.RSTOverrides
{
    public abstract class RST2RequestHandler
    {
        protected virtual ActionResult Ok<T>(T data)
        {
            return new OkObjectResult(data);
        }

        protected virtual ActionResult Ok()
        {
            return new OkResult();
        }

        protected virtual ActionResult NoContent()
        {
            return new NoContentResult();
        }

        protected virtual ActionResult Unauthorized()
        {
            return new UnauthorizedResult();
        }

        protected virtual ActionResult NotFoundObject(string errorMessage)
        {
            return new NotFoundObjectResult(errorMessage);
        }

        protected virtual ActionResult NotFoundObject(string errorMessage, string errorCode)
        {
            return new NotFoundObjectResult(new RSTActionError(404, errorMessage, errorCode));
        }

        protected virtual ActionResult NotFoundObject<T>(T notFoundObject)
        {
            return new NotFoundObjectResult(notFoundObject);
        }

        protected virtual ActionResult Created()
        {
            return new CreatedResult(string.Empty, null);
        }

        protected virtual ActionResult BadRequest(IList<RSTActionError> errors)
        {
            return new BadRequestObjectResult(errors);
        }

        protected virtual ActionResult BadRequest(string error)
        {
            return new BadRequestObjectResult(error);
        }

        protected virtual ActionResult BadRequest(string error, string errorCode)
        {
            return new BadRequestObjectResult(new RSTActionError(400, error, errorCode));
        }

        protected virtual ActionResult Created<T>(T value)
        {
            return new CreatedResult(string.Empty, value);
        }

        protected virtual ActionResult Accepted<T>(T value)
        {
            return new AcceptedResult(string.Empty, value);
        }

        protected virtual ActionResult Accepted()
        {
            return new AcceptedResult();
        }
    }

    public abstract class RST2RequestHandler<TRequest, TResponse> : RST2RequestHandler, IRequestHandler<TRequest, ActionResult<TResponse>>
        where TRequest : RST2Request<TResponse>
    {

        public RST2RequestHandler() : base() { }

        async Task<ActionResult<TResponse>> IRequestHandler<TRequest, ActionResult<TResponse>>.Handle(TRequest request, CancellationToken cancellationToken)
        {
            return await HandleAsync(request, cancellationToken);
        }

        protected abstract Task<ActionResult<TResponse>> HandleAsync(TRequest request, CancellationToken cancellationToken);
    }

    public abstract class RST2RequestHandler<TRequest> : RST2RequestHandler, IRequestHandler<TRequest, ActionResult> where TRequest : RST2Request
    {
        async Task<ActionResult> IRequestHandler<TRequest, ActionResult>.Handle(TRequest request, CancellationToken cancellationToken)
        {
            return await HandleAsync(request, cancellationToken);
        }

        protected abstract Task<ActionResult> HandleAsync(TRequest request, CancellationToken cancellationToken);
    }
}
