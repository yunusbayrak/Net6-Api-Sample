using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using dotnety.Domain.Repositories;
using dotnety.Infrastructure.Database;
using dotnety.Infrastructure.Repositories;

namespace dotnety.Infrastructure.Extensions;

public static class ServiceCollectionExtension
{
    public static void RegisterInfrastructureServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<DotnetyDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("PostgreSQL"), b => b.MigrationsAssembly("dotnety.Infrastructure"));
        }, ServiceLifetime.Scoped);
        serviceCollection.AddScoped<INumberPlateRepository, NumberPlateRepository>();

        serviceCollection.AddStackExchangeRedisCache(options => options.Configuration = configuration.GetSection("Redis")["Configuration"]);
    }
}

