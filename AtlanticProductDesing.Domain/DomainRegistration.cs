

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AtlanticProductDesing.Domain
{

    /// <summary>
    /// clase para registrar la inyección de dependecia de Infrastructure
    /// </summary>
    public static class InfrastructureRegistration
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services, IConfiguration configuration)
        {

            return services;
        }
    }

}
