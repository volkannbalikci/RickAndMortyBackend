using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RickAndMorty.Persistence.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Persistence.Extensions.Registrations;

public static class PersistenceLayerRegistration
{
    public static void RegisterPersistenceLayerDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RickyAndMortyDbContext>(options =>
        {
            options.UseSqlServer(configuration["SqlServerConnectionString"]);
        });
    }
}
