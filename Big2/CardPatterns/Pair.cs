namespace Big2.CardPatterns;

public class Pair : CardPattern
{
    private const int CountOfCard = 2;
    public override bool Verify(List<Card> cards)
    {
        if (cards is null || cards.Count != CountOfCard)
            return false;

        var firstCardRank = cards.First().Rank;
        return cards.All(card => card.Rank == firstCardRank);
    }
    public override CardPattern Build(List<Card> cards)
    {
        return new Pair() { Cards = cards };
    }
}
