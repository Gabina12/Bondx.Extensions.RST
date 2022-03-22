using Bondx.Extensions.RST.Filter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtention
    {
        public static IServiceCollection AddRSTApiResponseExplorer(this IServiceCollection services)
        {
            services.AddMvcCore(options =>
            {
                options.Filters.Add<RSTActionResultFilter>();
            });

            return services;
        }
    }
}
