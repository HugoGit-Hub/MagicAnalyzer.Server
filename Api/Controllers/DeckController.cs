using Domain.Decks;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DeckController : ControllerBase
{
    [HttpPost(nameof(Create))]
    public Deck Create(string name)
    {
        throw new NotImplementedException();
    }
    
    [HttpGet("Get/{id:int}")]
    public Deck Get(int id)
    {
        throw new NotImplementedException();
    }
    
    [HttpGet(nameof(GetAll))]
    public IEnumerable<Deck> GetAll()
    {
        throw new NotImplementedException();
    }
    
    [HttpPut("AddCard/{id:int}")]
    public Deck AddCard(int id)
    {
        throw new NotImplementedException();
    }
    
    [HttpPut("DeleteCard/{id:int}")]
    public Deck DeleteCard(int id)
    {
        throw new NotImplementedException();
    }
    
    [HttpDelete("Delete/{id:int}")]
    public Deck Delete(int id)
    {
        throw new NotImplementedException();
    }
}
