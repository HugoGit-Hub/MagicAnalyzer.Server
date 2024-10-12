using Application.Decks.AddCard;
using Application.Decks.CreateDeck;
using Application.Decks.DeleteCard;
using Application.Decks.DeleteDeck;
using Application.Decks.GetAllDecks;
using Application.Decks.GetDeck;
using Domain.Decks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DeckController(ISender sender) : ControllerBase
{
    [HttpPost(nameof(Create))]
    public async Task<ActionResult<string>> Create(string name, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new CreateDeckCommand(name), cancellationToken);

        return Ok(result);
    }
    
    [HttpGet("Get/{id:int}")]
    public async Task<ActionResult<GetDeckResponse>> Get(int id, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetDeckQuery(id), cancellationToken);
        
        return Ok(result);
    }
    
    [HttpGet(nameof(GetAll))]
    public async Task<ActionResult<IEnumerable<GetAllDecksResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetAllDecksQuery(), cancellationToken);
        
        return Ok(result);
    }
    
    [HttpDelete("Delete/{id:int}")]
    public async Task<ActionResult<string>> Delete(int id,CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeleteDeckCommand(id), cancellationToken);
        
        return Ok(result);
    }
    
    [HttpPost("AddCard/{deckId:int}/{cardGuid:guid}")]
    public async Task<ActionResult<AddCardResponse>> AddCard(
        int deckId,
        Guid cardGuid,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(new AddCardCommand(deckId, cardGuid), cancellationToken);
        
        return Ok(result);
    }
    
    [HttpDelete("DeleteCard/{deckId:int}/{cardId:int}")]
    public async Task<ActionResult<DeleteCardResponse>> DeleteCard(
        int deckId,
        int cardId,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(new DeleteCardCommand(deckId, cardId), cancellationToken);
        
        return Ok(result);
    }
}
