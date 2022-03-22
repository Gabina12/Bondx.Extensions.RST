using Bondx.Extensions.RST.Mediator;
using Bondx.Extensions.RST.Mediator.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    [ExcludeFromCodeCoverage]
    public static class RegistrationExtensions
    {

        private static IServiceCollection AddRSTApiMediatRExplorer(this IServiceCollection services, params Assembly[] assemblies)
        {
            var mediatorDescriptor = ServiceDescriptor.Transient<IMediator, HttpContextMediator>(provider => new HttpContextMediator(
                new MediatR.Mediator(provider.GetRequiredService<ServiceFactory>()), provider.GetRequiredService<IHttpContextAccessor>(),
                provider.GetRequiredService<ILinkedCancellationTokenFactory>()));

            var hashSet = new HashSet<Assembly>(assemblies)
            {
                typeof(LogExceptionAction<,>).Assembly,
            };

            return services
                .AddMediatR(hashSet.ToArray())
                .AddHttpContextAccessor()
                .AddTransient<ILinkedCancellationTokenFactory, LinkedCancellationTokenFactory>()
                .Replace(mediatorDescriptor);
        }
    }
}
