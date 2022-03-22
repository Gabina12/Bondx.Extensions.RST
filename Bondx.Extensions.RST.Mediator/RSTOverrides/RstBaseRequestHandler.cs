using Bondx.Extensions.RST.Mediator.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bondx.Extensions.RST.Mediator
{
    [ExcludeFromCodeCoverage]
    public class BaseRequestHandler
    {
        protected BaseRequestHandler() { }
    }

    [ExcludeFromCodeCoverage]
    public abstract class RSTRequestHandler : BaseRequestHandler
    {
        protected RSTRequestHandler() : base() { }

        protected virtual RSTActionResult<T> Ok<T>(T data)
        {
            return new RSTActionResult<T>(HttpStatusCode.OK, data);
        }

        protected virtual RSTActionResult Ok()
        {
            return new RSTActionResult(HttpStatusCode.OK);
        }

        protected virtual RSTActionResult NoContent()
        {
            return new RSTActionResult(HttpStatusCode.NoContent);
        }

        protected virtual RSTActionResult Unauthorized()
        {
            return new RSTActionResult(HttpStatusCode.Unauthorized);
        }

        protected virtual RSTActionResult NotFoundObject(string errorMessage)
        {
            return new RSTActionResult(HttpStatusCode.NotFound, errorMessage);
        }

        protected virtual RSTActionResult<T> NotFoundObject<T>(T notFoundObject)
        {
            return new RSTActionResult<T>(HttpStatusCode.NotFound, notFoundObject);
        }

        protected virtual RSTActionResult Created()
        {
            return new RSTActionResult(HttpStatusCode.Created);
        }

        protected virtual RSTActionResult BadRequest(IList<RSTActionError> errors)
        {
            return new RSTActionResult(HttpStatusCode.BadRequest, errors);
        }

        protected virtual RSTActionResult BadRequest(string error)
        {
            return new RSTActionResult(HttpStatusCode.BadRequest, new List<RSTActionError>() { new RSTActionError((int)HttpStatusCode.BadRequest, error) });
        }

        protected virtual RSTActionResult<T> Created<T>(T value)
        {
            return new RSTActionResult<T>(HttpStatusCode.Created, value);
        }

        protected virtual RSTActionResult<T> Accepted<T>(T value)
        {
            return new RSTActionResult<T>(HttpStatusCode.Accepted, value);
        }

        protected virtual RSTActionResult Accepted()
        {
            return new RSTActionResult(HttpStatusCode.Accepted);
        }

        protected virtual RSTActionResult ServiceResponse<T>(RSTActionResult<T> response)
        {
            return new RSTActionResult(response.Status, response.AsError());
        }
    }

    [ExcludeFromCodeCoverage]
    public abstract class RSTRequestHandler<TRequest, TResponse> : RSTRequestHandler, IRequestHandler<TRequest, RSTActionResult<TResponse>>
        where TRequest : RSTRequest<TResponse>
    {

        public RSTRequestHandler() : base() { }

        async Task<RSTActionResult<TResponse>> IRequestHandler<TRequest, RSTActionResult<TResponse>>.Handle(TRequest request, CancellationToken cancellationToken)
        {
            return await HandleAsync(request, cancellationToken);
        }

        protected abstract Task<RSTActionResult<TResponse>> HandleAsync(TRequest request, CancellationToken cancellationToken);
    }

    [ExcludeFromCodeCoverage]
    public abstract class RSTRequestHandler<TRequest> : RSTRequestHandler, IRequestHandler<TRequest, RSTActionResult> where TRequest : RSTRequest
    {
        public RSTRequestHandler() : base() { }

        async Task<RSTActionResult> IRequestHandler<TRequest, RSTActionResult>.Handle(TRequest request, CancellationToken cancellationToken)
        {
            return await HandleAsync(request, cancellationToken);
        }

        protected abstract Task<RSTActionResult> HandleAsync(TRequest request, CancellationToken cancellationToken);
    }
}
