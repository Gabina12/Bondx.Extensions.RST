using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Bondx.Extensions.RST
{
    public interface IRST2ServiceBase
    {
    }

    [ExcludeFromCodeCoverage]
    public abstract class RST2ServiceBase :
         IRST2ServiceBase,
         IDisposable
    {
        public RST2ServiceBase()
        {
        }

        ~RST2ServiceBase()
        {
            Dispose(false);
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {

        }

        #region Helper Base methods to return status
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
        #endregion
    }
}
