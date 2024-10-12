namespace Application.Decks.GetDeck;

public record GetDeckResponse(string Name, IEnumerable<GetDeckResponseCard> Cards);

public record GetDeckResponseCard(int CardId, Guid CardGuid);
