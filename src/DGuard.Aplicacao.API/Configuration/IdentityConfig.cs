using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DGuard.Aplicacao.API.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            return services;
        }
    }
}