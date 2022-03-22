using System;
using System.Linq;
using System.Threading;

namespace Bondx.Extensions.RST.Mediator
{
    public class LinkedCancellationTokenFactory : ILinkedCancellationTokenFactory
    {
        public CancellationToken Create(params CancellationToken[] tokens)
        {
            if (tokens == null)
            {
                throw new ArgumentNullException(nameof(tokens));
            }

            if (tokens.Length == 1)
            {
                return tokens.First();
            }

            return CancellationTokenSource.CreateLinkedTokenSource(tokens).Token;
        }
    }
}
