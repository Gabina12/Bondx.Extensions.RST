using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Bondx.Extensions.RST.Extensions
{
    public static class RSTActionResultExtensions
    {
        public static void SetActionErrorService(this IRSTActionResult etpActionResult, IConfiguration configuration)
        {
            if (etpActionResult.IsSuccess)
                return;

            var serviceName = string.Empty;
            var serviceNameRetrieved = false;

            for (int i = 0; i < etpActionResult.Errors?.Count(); i++)
            {
                if (etpActionResult.Errors[i] != null && string.IsNullOrEmpty(etpActionResult.Errors[i].Service))
                {
                    if (!serviceNameRetrieved)
                    {
                        serviceName = configuration.GetValue<string>("ServiceName");
                        serviceNameRetrieved = true;
                    }

                    etpActionResult.Errors[i].Service = serviceName;
                }
            }
        }
    }
}
