using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bondx.Extensions.RST.Mediator.Extensions
{
    public static class LoggerExtensions
    {
        public static void LogException(this ILogger logger, Exception exception)
        {
            switch (exception)
            {
                default:
                    logger.LogError(exception, "Error occurred during request execution");
                    break;
            }
        }

        public static IList<RSTActionError> AsError<T>(this RSTActionResult<T> value)
        {
            return value.Errors;
        }
    }

    public class LogExceptionAction<TRequest, TException> : IRequestExceptionAction<TRequest, TException>
       where TException : Exception
    {
        private readonly ILogger<LogExceptionAction<TRequest, TException>> _logger;

        public LogExceptionAction(ILogger<LogExceptionAction<TRequest, TException>> logger) => _logger = logger;

        public Task Execute(TRequest request, TException exception, CancellationToken cancellationToken)
        {
            _logger.LogException(exception);

            return Task.CompletedTask;
        }
    }
}
