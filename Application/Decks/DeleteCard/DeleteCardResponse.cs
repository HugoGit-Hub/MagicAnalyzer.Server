namespace Application.Decks.DeleteCard;

public record DeleteCardResponse(IEnumerable<DeleteCardResponseCard> Cards);

public record DeleteCardResponseCard(int CardId, Guid CardGuid);