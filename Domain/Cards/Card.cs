using Domain.Base;
using Domain.Decks;

namespace Domain.Cards;

public class Card : Entity<int>
{
    public Guid CardGuid { get; }
    
    public int DeckId { get; }
    
    public Deck Deck { get; } = null!;

    private Card(int id, int deckId, Guid cardGuid) : base(id)
    {
        CardGuid = cardGuid;
        DeckId = deckId;
    }
    
    public static Card Create(int id, int deckId, Guid cardGuid)
    {
        return new Card(id, deckId, cardGuid);
    }
}