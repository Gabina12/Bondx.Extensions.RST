using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Bondx.Extensions.RST
{
    public interface IRSTService { }

    public abstract class RSTServiceBase :
        IRSTService,
        IDisposable
    {
        public RSTServiceBase()
        {
        }

        ~RSTServiceBase()
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
        [NonAction]
        public virtual RSTActionResult<T> RSTOk<T>(T data)
        {
            return new RSTActionResult<T>(HttpStatusCode.OK, data);
        }

        [NonAction]
        public virtual RSTActionResult RSTOk()
        {
            return new RSTActionResult(HttpStatusCode.OK);
        }

        [NonAction]
        public virtual RSTActionResult RSTNoContent()
        {
            return new RSTActionResult(HttpStatusCode.NoContent);
        }

        [NonAction]
        public virtual RSTActionResult RSTUnauthorized()
        {
            return new RSTActionResult(HttpStatusCode.Unauthorized);
        }

        [NonAction]
        public virtual RSTActionResult RSTNotFound()
        {
            return new RSTActionResult(HttpStatusCode.NotFound);
        }

        [NonAction]
        public virtual RSTActionResult<T> RSTNotFoundObject<T>(T notFoundObject)
        {
            return new RSTActionResult<T>(HttpStatusCode.NotFound, notFoundObject);
        }

        [NonAction]
        public virtual RSTActionResult RSTNotFound(string errorMessage)
        {
            return new RSTActionResult(HttpStatusCode.NotFound, errorMessage);
        }

        [NonAction]
        public virtual RSTActionResult RSTNotFound(IList<RSTActionError> errors)
        {
            return new RSTActionResult(HttpStatusCode.NotFound, errors);
        }

        [NonAction]
        public virtual RSTActionResult RSTNotFound(IList<string> errorMessages)
        {
            return new RSTActionResult(HttpStatusCode.NotFound, errorMessages);
        }

        [NonAction]
        public virtual RSTActionResult RSTBadRequest()
        {
            return new RSTActionResult(HttpStatusCode.BadRequest);
        }

        [NonAction]
        public virtual RSTActionResult RSTBadRequest(string errorMessage)
        {
            return new RSTActionResult(HttpStatusCode.BadRequest, errorMessage);
        }

        [NonAction]
        public virtual RSTActionResult RSTBadRequest(IList<RSTActionError> errors)
        {
            return new RSTActionResult(HttpStatusCode.BadRequest, errors);
        }

        [NonAction]
        public virtual RSTActionResult RSTBadRequest(IList<string> errorMessages)
        {
            return new RSTActionResult(HttpStatusCode.BadRequest, errorMessages);
        }

        [NonAction]
        public virtual RSTActionResult RSTConflict()
        {
            return new RSTActionResult(HttpStatusCode.Conflict);
        }

        [NonAction]
        public virtual RSTActionResult RSTConflict(string errorMessage)
        {
            return new RSTActionResult(HttpStatusCode.Conflict, errorMessage);
        }

        [NonAction]
        public virtual RSTActionResult RSTConflict(IList<RSTActionError> errors)
        {
            return new RSTActionResult(HttpStatusCode.Conflict, errors);
        }

        [NonAction]
        public virtual RSTActionResult RSTConflict(IList<string> errorMessages)
        {
            return new RSTActionResult(HttpStatusCode.Conflict, errorMessages);
        }

        [NonAction]
        public virtual RSTActionResult RSTCreated()
        {
            return new RSTActionResult(HttpStatusCode.Created);
        }

        [NonAction]
        public virtual RSTActionResult<T> RSTCreated<T>(T value)
        {
            return new RSTActionResult<T>(HttpStatusCode.Created, value);
        }

        [NonAction]
        public virtual RSTActionResult<T> RSTAccepted<T>(T value)
        {
            return new RSTActionResult<T>(HttpStatusCode.Accepted, value);
        }

        [NonAction]
        public virtual RSTActionResult RSTAccepted()
        {
            return new RSTActionResult(HttpStatusCode.Accepted);
        }

        [NonAction]
        public virtual RSTActionResult RSTForbid()
        {
            return new RSTActionResult(HttpStatusCode.Forbidden);
        }

        [NonAction]
        public virtual RSTActionResult RSTForbid(string errorMessage)
        {
            return new RSTActionResult(HttpStatusCode.Forbidden, errorMessage);
        }

        [NonAction]
        public virtual RSTActionResult RSTForbid(IList<RSTActionError> errors)
        {
            return new RSTActionResult(HttpStatusCode.Forbidden, errors);
        }

        [NonAction]
        public virtual RSTActionResult RSTForbid(IList<string> errorMessages)
        {
            return new RSTActionResult(HttpStatusCode.Forbidden, errorMessages);
        }

        #endregion
    }
}
