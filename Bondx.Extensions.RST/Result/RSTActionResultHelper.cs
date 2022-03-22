using System.Net;

namespace Bondx.Extensions.RST
{
    public static class RSTActionResultHelper
    {
        public static bool CheckIfStatusSuccessful(int httpStatusCode)
        {
            return httpStatusCode >= (int)HttpStatusCode.OK && httpStatusCode < (int)HttpStatusCode.Ambiguous;
        }
    }
}
