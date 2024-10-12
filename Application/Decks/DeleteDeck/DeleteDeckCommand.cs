using MediatR;

namespace Application.Decks.DeleteDeck;

public record DeleteDeckCommand(int Id) : IRequest<string>;