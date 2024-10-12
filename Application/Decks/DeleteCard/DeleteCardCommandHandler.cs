using Domain.Cards;
using Domain.Decks;
using MediatR;

namespace Application.Decks.DeleteCard;

public class DeleteCardCommandHandler(
    IDeckRepository deckRepository,
    ICardRepository cardRepository) : IRequestHandler<DeleteCardCommand, DeleteCardResponse>
{
    public async Task<DeleteCardResponse> Handle(DeleteCardCommand command, CancellationToken cancellationToken)
    {
        var deck = await deckRepository.GetDeckIncludeCardsAsync(command.DeckId, cancellationToken);
        var card = deck.Cards.First(x => x.Id == command.CardId);
        await cardRepository.Delete(card, cancellationToken);
        
        var updatedDeck = await deckRepository.GetDeckIncludeCardsAsync(command.DeckId, cancellationToken);
        
        return new DeleteCardResponse(updatedDeck.Cards.Select(x => new DeleteCardResponseCard(x.Id, x.CardGuid)));
    }
}