using Domain.Cards;
using Infrastructure.Context;

namespace Infrastructure.Cards;

public class CardRepository(MagicAnalyzerContext context) : Repository<Card, int>(context), ICardRepository;