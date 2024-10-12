using Domain.Decks;
using MediatR;

namespace Application.Decks.DeleteCard;

public record DeleteCardCommand(int DeckId, int CardId) : IRequest<DeleteCardResponse>;