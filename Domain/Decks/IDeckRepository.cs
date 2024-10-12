namespace Domain.Decks;

public interface IDeckRepository : IRepository<Deck, int>
{
    Task<Deck> GetDeckIncludeCardsAsync(int id, CancellationToken cancellationToken);
}