using System.Collections.Generic;

namespace Bondx.Extensions.RST
{
    public interface IRSTActionResult
    {
        int Status { get; }

        bool IsSuccess { get; }

        IList<RSTActionError> Errors { get; }
    }
}
