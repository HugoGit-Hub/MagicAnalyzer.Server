using Domain.Decks;
using MediatR;

namespace Application.Decks.GetAllDecks;

public record GetAllDecksQuery : IRequest<IEnumerable<GetAllDecksResponse>>;