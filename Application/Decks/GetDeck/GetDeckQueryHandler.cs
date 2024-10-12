using Domain.Decks;
using MediatR;

namespace Application.Decks.GetDeck;

public class GetDeckQueryHandler(IDeckRepository deckRepository) : IRequestHandler<GetDeckQuery, GetDeckResponse>
{
    public async Task<GetDeckResponse> Handle(GetDeckQuery query, CancellationToken cancellationToken)
    {
        var deck = await deckRepository.GetDeckIncludeCardsAsync(query.Id, cancellationToken);

        return new GetDeckResponse
        (
            deck.Name,
            deck.Cards.Select(x => new GetDeckResponseCard(x.Id, x.CardGuid))
        );
    }
}