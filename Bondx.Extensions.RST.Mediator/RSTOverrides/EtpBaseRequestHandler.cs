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
    public class RstBaseRequestHandler
    {

        protected RstBaseRequestHandler() { }

       
    }

    [ExcludeFromCodeCoverage]
    public abstract class RstRequestHandler : RstBaseRequestHandler
    {
        protected RstRequestHandler() : base() { }

 

        protected virtual RSTActionResult<T> RstOk<T>(T data)
        {
            return new RSTActionResult<T>(HttpStatusCode.OK, data);
        }

        protected virtual RSTActionResult RstOk()
        {
            return new RSTActionResult(HttpStatusCode.OK);
        }

        protected virtual RSTActionResult RstNoContent()
        {
            return new RSTActionResult(HttpStatusCode.NoContent);
        }

        protected virtual RSTActionResult RstUnauthorized()
        {
            return new RSTActionResult(HttpStatusCode.Unauthorized);
        }

        protected virtual RSTActionResult RstNotFoundObject(string errorMessage)
        {
            return new RSTActionResult(HttpStatusCode.NotFound, errorMessage);
        }

        protected virtual RSTActionResult<T> RstNotFoundObject<T>(T notFoundObject)
        {
            return new RSTActionResult<T>(HttpStatusCode.NotFound, notFoundObject);
        }

        protected virtual RSTActionResult RstCreated()
        {
            return new RSTActionResult(HttpStatusCode.Created);
        }

        protected virtual RSTActionResult RstBadRequest(IList<RSTActionError> errors)
        {
            return new RSTActionResult(HttpStatusCode.BadRequest, errors);
        }

        protected virtual RSTActionResult RstBadRequest(string error)
        {
            return new RSTActionResult(HttpStatusCode.BadRequest, new List<RSTActionError>() { new RSTActionError((int)HttpStatusCode.BadRequest, error) });
        }

        protected virtual RSTActionResult<T> RstCreated<T>(T value)
        {
            return new RSTActionResult<T>(HttpStatusCode.Created, value);
        }

        protected virtual RSTActionResult<T> RstAccepted<T>(T value)
        {
            return new RSTActionResult<T>(HttpStatusCode.Accepted, value);
        }

        protected virtual RSTActionResult RstAccepted()
        {
            return new RSTActionResult(HttpStatusCode.Accepted);
        }

        protected virtual RSTActionResult RstServiceResponse<T>(RSTActionResult<T> response)
        {
            return new RSTActionResult(response.Status, response.AsError());
        }
    }

    [ExcludeFromCodeCoverage]
    public abstract class RstRequestHandler<TRequest, TResponse> : RstRequestHandler, IRequestHandler<TRequest, RSTActionResult<TResponse>>
        where TRequest : RSTRequest<TResponse>
    {

        public RstRequestHandler() : base() { }

        async Task<RSTActionResult<TResponse>> IRequestHandler<TRequest, RSTActionResult<TResponse>>.Handle(TRequest request, CancellationToken cancellationToken)
        {
            return await HandleAsync(request, cancellationToken);
        }

        protected abstract Task<RSTActionResult<TResponse>> HandleAsync(TRequest request, CancellationToken cancellationToken);
    }

    [ExcludeFromCodeCoverage]
    public abstract class RstRequestHandler<TRequest> : RstRequestHandler, IRequestHandler<TRequest, RSTActionResult> where TRequest : RSTRequest
    {
        public RstRequestHandler() : base() { }

        async Task<RSTActionResult> IRequestHandler<TRequest, RSTActionResult>.Handle(TRequest request, CancellationToken cancellationToken)
        {
            return await HandleAsync(request, cancellationToken);
        }

        protected abstract Task<RSTActionResult> HandleAsync(TRequest request, CancellationToken cancellationToken);
    }
}
