using Domain.Decks;
using MediatR;

namespace Application.Decks.CreateDeck;

public class CreateDeckCommandHandler(IDeckRepository deckRepository) 
    : IRequestHandler<CreateDeckCommand, string>
{
    public async Task<string> Handle(CreateDeckCommand command, CancellationToken cancellationToken)
    {
        var deck = Deck.Create(default, command.Name);
        var result = await deckRepository.Create(deck, cancellationToken);
        
        return result.Name;
    }
}