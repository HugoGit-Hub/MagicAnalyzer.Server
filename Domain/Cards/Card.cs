using Domain.Base;
using Domain.Decks;

namespace Domain.Cards;

public class Card : Entity<int>
{
    public Guid CardGuid { get; }
    
    public Deck Deck { get; } = null!;

    private Card(int id, Guid cardGuid) : base(id)
    {
        CardGuid = cardGuid;
    }
    
    public static Card Create(int id, Guid cardGuid)
    {
        return new Card(id, cardGuid);
    }
}