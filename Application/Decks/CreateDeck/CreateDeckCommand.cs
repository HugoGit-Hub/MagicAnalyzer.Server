using MediatR;

namespace Application.Decks.CreateDeck;

public record CreateDeckCommand(string Name) : IRequest<string>;