using Bondx.Extensions.RST.Filter;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RegistrationExtensions
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
