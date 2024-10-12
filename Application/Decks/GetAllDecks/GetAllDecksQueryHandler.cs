using Domain.Decks;
using MediatR;

namespace Application.Decks.GetAllDecks;

public class GetAllDecksQueryHandler(IDeckRepository deckRepository) 
    : IRequestHandler<GetAllDecksQuery, IEnumerable<GetAllDecksResponse>>
{
    public async Task<IEnumerable<GetAllDecksResponse>> Handle(GetAllDecksQuery request, CancellationToken cancellationToken)
    {
        var decks = await deckRepository.GetAll(cancellationToken);
        
        return decks.Select(deck => new GetAllDecksResponse(deck.Id, deck.Name));
    }
}