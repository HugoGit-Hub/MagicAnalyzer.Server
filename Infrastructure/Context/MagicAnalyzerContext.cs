using Domain.Cards;
using Domain.Decks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class MagicAnalyzerContext(DbContextOptions<MagicAnalyzerContext> options) : DbContext(options)
{
    public DbSet<Deck> Decks { get; set; }
    
    public DbSet<Card> Cards { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MagicAnalyzerContext).Assembly);
    }
}