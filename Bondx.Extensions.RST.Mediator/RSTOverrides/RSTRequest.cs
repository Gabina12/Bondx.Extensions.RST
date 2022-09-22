using MediatR;
using Microsoft.AspNetCore.Mvc;
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

    public class RST2Request : IRequest<ActionResult>
    {

    }

    public class RST2Request<TResponse> : IRequest<ActionResult<TResponse>>
    {

    }
}
