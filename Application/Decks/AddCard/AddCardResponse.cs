namespace Application.Decks.AddCard;

public record AddCardResponse(IEnumerable<AddCardResponseCard> Cards);

public record AddCardResponseCard(int CardId, Guid CardGuid);