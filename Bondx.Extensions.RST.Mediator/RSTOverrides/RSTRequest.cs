using MediatR;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Bondx.Extensions.RST.Mediator
{
    [ExcludeFromCodeCoverage]
    public class RSTRequest : IRequest<RSTActionResult>
    {

    }

    [ExcludeFromCodeCoverage]
    public class RSTRequest<TResponse> : IRequest<RSTActionResult<TResponse>>
    {

    }
}
