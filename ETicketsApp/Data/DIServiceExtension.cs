using ETicketsApp.Data.Interfaces;
using ETicketsApp.Data.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ETicketsApp.Data
{
    public static class DIServiceExtension
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IActorsService, ActorsService>();
            services.AddScoped<IProducersService, ProducersService>();
            services.AddScoped<ICinemasService, CinemasService>();
        }
    }
}
