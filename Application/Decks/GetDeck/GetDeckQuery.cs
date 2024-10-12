using Domain.Decks;
using MediatR;

namespace Application.Decks.GetDeck;

public record GetDeckQuery(int Id) : IRequest<GetDeckResponse>;