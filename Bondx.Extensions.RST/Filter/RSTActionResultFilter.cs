using Bondx.Extensions.RST.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bondx.Extensions.RST.Filter
{
    public class RSTActionResultFilter : IActionFilter
    {
        private readonly IConfiguration _configuration;

        public RSTActionResultFilter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var objectResult = context.Result as ObjectResult;

            switch (objectResult?.Value)
            {
                case IRSTActionResult etpActionResult:
                    {
                        context.HttpContext.Response.StatusCode = etpActionResult.Status;

                        if (!StatusCanHaveBody(etpActionResult.Status))
                        {
                            context.Result = null;
                        }
                        break;
                    }
            }

            if (objectResult?.Value is IRSTActionResult actionResult)
            {
                actionResult.SetActionErrorService(_configuration);
            }
        }

        private bool StatusCanHaveBody(int statusCode)
        {
            return statusCode != StatusCodes.Status204NoContent &&
                   statusCode != StatusCodes.Status205ResetContent &&
                   statusCode != StatusCodes.Status304NotModified;
        }
    }
}
