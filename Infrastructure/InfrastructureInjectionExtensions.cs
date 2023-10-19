using Application.Contracts;
using Infrastructure.Census;
using Infrastructure.Rentcast;
using Infrastructure.Services.Zippopotamus;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Injection
{
    public static class InfrastructureInjectionExtensions
    {

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ICensusService, CensusService>();
            services.AddScoped<ILocationService, ZippopotamusService>();
            services.AddScoped<IRentService, RentcastService>();

            return services;
        }
    }
}
