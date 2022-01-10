using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UnluCoSample.Domain.Repositories;
using UnluCoSample.Infrastructure.Database;
using UnluCoSample.Infrastructure.Repositories;

namespace UnluCoSample.Infrastructure.Extensions;

public static class ServiceCollectionExtension
    {
        public static void RegisterInfrastructureServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<UnluCoDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("PostgreSQL"), b => b.MigrationsAssembly("UnluCoSample.Infrastructure"));
            }, ServiceLifetime.Scoped);
            serviceCollection.AddScoped<INumberPlateRepository, NumberPlateRepository>();

            serviceCollection.AddStackExchangeRedisCache(options => options.Configuration = configuration.GetSection("Redis")["Configuration"]);
        }
    }

