using Domain.Cards;
using Domain.Decks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Configurations;

public class CardConfiguration : IEntityTypeConfiguration<Card>
{
    public void Configure(EntityTypeBuilder<Card> builder)
    {
        builder.HasKey(d => d.Id);
        builder.Property(d => d.CardGuid).IsRequired();
        builder.HasOne<Deck>().WithMany(x => x.Cards);
    }
}