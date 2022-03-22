using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Bondx.Extensions.RST
{
    public class RSTActionResult<T> : IRSTActionResult
    {
        private HttpStatusCode _statusCode;

        public int Status
        {
            get => (int)_statusCode;
            set => _statusCode = (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), value.ToString());
        }

        public virtual bool IsSuccess => RSTActionResultHelper.CheckIfStatusSuccessful(Status);

        public T Data { get; set; }

        public IList<RSTActionError> Errors { get; set; }


        public RSTActionResult() { }

        public RSTActionResult(IRSTActionResult result)
        {
            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }
            Errors = result.Errors;
            Status = result.Status;
        }

        public RSTActionResult(HttpStatusCode statusCode, T data)
        {
            _statusCode = statusCode;
            Data = data;
        }

        public RSTActionResult(HttpStatusCode statusCode, RSTActionError error, T data)
         : this(statusCode, data)
        {
            Errors = new List<RSTActionError>() { error };
        }

        public RSTActionResult(HttpStatusCode statusCode, IList<RSTActionError> errors, T data)
            : this(statusCode, data)
        {
            Errors = errors;
        }

        public RSTActionResult(int status, IList<RSTActionError> errors, T data)
        {
            Status = status;
            Errors = errors;
            Data = data;
        }

        public RSTActionResult(HttpStatusCode statusCode, string errorMessage, T result)
            : this(statusCode, result)
        {
            Errors = new List<RSTActionError>() { new RSTActionError((int)statusCode, errorMessage) };
        }

        public RSTActionResult(HttpStatusCode statusCode, IList<string> errorMessages, T data)
        {
            Errors = errorMessages.Select(x => new RSTActionError(400, x)).ToList();
            Data = data;
            _statusCode = statusCode;
        }

        public RSTActionResult(int status, IList<string> errorMessages, T data)
        {
            Errors = errorMessages.Select(x => new RSTActionError(400, x)).ToList();
            Data = data;
            _statusCode = (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), status.ToString());
        }

        public static implicit operator RSTActionResult<T>(RSTActionResult result)
        {
            return new RSTActionResult<T>(result);
        }
    }

    public class RSTActionResult : IRSTActionResult
    {
        private HttpStatusCode _statusCode;

        public int Status
        {
            get => (int)_statusCode;
            set => _statusCode = (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), value.ToString());
        }

        public virtual bool IsSuccess => RSTActionResultHelper.CheckIfStatusSuccessful(Status);

        public IList<RSTActionError> Errors { get; set; }

        public RSTActionResult() { }

        public RSTActionResult(IRSTActionResult result)
        {
            Errors = result.Errors;
            Status = result.Status;
        }

        public RSTActionResult(HttpStatusCode statusCode)
        {
            _statusCode = statusCode;
        }

        public RSTActionResult(HttpStatusCode statusCode, RSTActionError error)
            : this(statusCode)
        {
            Errors = new List<RSTActionError>() { error };
        }

        public RSTActionResult(HttpStatusCode statusCode, IList<RSTActionError> errors)
            : this(statusCode)
        {
            Errors = errors;
        }

        public RSTActionResult(int status, IList<RSTActionError> errors)
        {
            Status = status;
            Errors = errors;
        }

        public RSTActionResult(HttpStatusCode statusCode, string errorMessage)
            : this(statusCode)
        {
            Errors = new List<RSTActionError>() { new RSTActionError((int)statusCode, errorMessage) };
        }

        public RSTActionResult(HttpStatusCode statusCode, IList<string> errorMessages)
        {
            Errors = errorMessages.Select(x => new RSTActionError(400, x)).ToList();
            _statusCode = statusCode;
        }

        public RSTActionResult(int status, IList<string> errorMessages)
        {
            Errors = errorMessages.Select(x => new RSTActionError(400, x)).ToList();
            _statusCode = (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), status.ToString());
        }
    }
}
