using Domain;
using Domain.Cards;
using Domain.Decks;
using Infrastructure.Cards;
using Infrastructure.Context;
using Infrastructure.Decks;
using Infrastructure.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddPersistence(configuration)
            .AddRepositories();
    }
    
    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddDbContext<MagicAnalyzerContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString(nameof(ConnectionStringsOption.DefaultConnection)));
        });
    }
    
    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>))
            .AddScoped<IDeckRepository, DeckRepository>()
            .AddScoped<ICardRepository, CardRepository>();
    }
}