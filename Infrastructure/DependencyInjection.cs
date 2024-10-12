using Infrastructure.Context;
using Infrastructure.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddPersistence(configuration);
    }
    
    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddDbContext<MagicAnalyzerContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString(nameof(ConnectionStringsOption.DefaultConnection)));
        });
    }
}