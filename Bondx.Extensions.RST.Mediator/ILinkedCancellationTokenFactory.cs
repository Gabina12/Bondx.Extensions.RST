using System.Threading;

namespace Bondx.Extensions.RST.Mediator
{
    public interface ILinkedCancellationTokenFactory
    {
        CancellationToken Create(params CancellationToken[] tokens);
    }
}
