using Microsoft.Extensions.DependencyInjection;
using RickAndMorty.Application.Abstraction.Repositories;
using RickAndMorty.Application.Abstraction.Services;
using RickAndMorty.Infrastructure.Constants;
using RickAndMorty.Infrastructure.Services;
using RickAndMorty.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Infrastructure.Extensions.Registrations
{
    public static class InfrastructureLayerRegistration
    {
        public static void RegisterInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddHttpClient<IRickAndMortyService, RickAndMortyService>(client =>
            {
                client.BaseAddress = new Uri(RickAndMortyConstants.RickAndMortyBaseApiUrlString);
            });
         
            services.AddScoped<IEpisodeRepository, EpisodeRepository>();
            services.AddScoped<ICharacterRepository, CharacterRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
        }
    }
}
