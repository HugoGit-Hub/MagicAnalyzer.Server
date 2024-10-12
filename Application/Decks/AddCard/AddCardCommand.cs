using Domain.Decks;
using MediatR;

namespace Application.Decks.AddCard;

public record AddCardCommand(int DeckId, Guid CardGuid) : IRequest<AddCardResponse>;