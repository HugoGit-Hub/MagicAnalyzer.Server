using Domain.Cards;
using Domain.Decks;
using MediatR;

namespace Application.Decks.AddCard;

public class AddCardCommandHandler(
    IDeckRepository deckRepository,
    ICardRepository cardRepository) : IRequestHandler<AddCardCommand, AddCardResponse>
{
    public async Task<AddCardResponse> Handle(AddCardCommand command, CancellationToken cancellationToken)
    {
        var deck = await deckRepository.GetDeckIncludeCardsAsync(command.DeckId, cancellationToken);
        var card = Card.Create(default, command.DeckId, command.CardGuid);
        var createdCard = await cardRepository.Create(card, cancellationToken);
        deck.Cards.Add(createdCard);
        
        var result = await deckRepository.Update(deck, cancellationToken);

        return new AddCardResponse(result.Cards.Select(c => new AddCardResponseCard(c.Id, c.CardGuid)));
    }
}