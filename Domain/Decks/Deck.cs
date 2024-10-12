using Domain.Base;
using Domain.Cards;

namespace Domain.Decks;

public class Deck : Entity<int>
{
    public string Name { get; }

    public ICollection<Card> Cards { get; } = [];

    private Deck(int id, string name) : base(id)
    {
        Name = name;
    }

    public static Deck Create(int id, string name)
    {
        return new Deck(id, name);
    }
}