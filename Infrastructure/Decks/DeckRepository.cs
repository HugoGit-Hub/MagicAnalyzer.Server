using Domain.Decks;
using Domain.Exceptions;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Decks;

public class DeckRepository(MagicAnalyzerContext context) : Repository<Deck, int>(context), IDeckRepository
{
    private readonly MagicAnalyzerContext _context = context;

    public async Task<Deck> GetDeckIncludeCardsAsync(int id, CancellationToken cancellationToken)
    {
        var result = await _context.Decks 
            .Include(d => d.Cards)
            .FirstAsync(d => d.Id == id, cancellationToken) ?? throw new NotFoundException($"Unable to get requiered entity {nameof(Deck)}");
        _context.Entry(result).State = EntityState.Detached;
        
        return result;
    }
}