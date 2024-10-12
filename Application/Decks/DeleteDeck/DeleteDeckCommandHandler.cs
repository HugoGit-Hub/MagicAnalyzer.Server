using Domain.Decks;
using MediatR;

namespace Application.Decks.DeleteDeck;

public class DeleteDeckCommandHandler(IDeckRepository deckRepository) : IRequestHandler<DeleteDeckCommand, string>
{
    public async Task<string> Handle(DeleteDeckCommand command, CancellationToken cancellationToken)
    {
        var deck = await deckRepository.Get(command.Id, cancellationToken);
        var result = await deckRepository.Delete(deck, cancellationToken);
        
        return result.Name;
    }
}