namespace Big2.CardPatternCompares;

public class FullHouseCompare(CardPatternCompare? next) : CardPatternCompare(next)
{
    public override bool CanCompare(CardPattern cardPatternA, CardPattern cardPatternB)
    {
        return cardPatternA.GetType() == typeof(CardPatterns.FullHouse) && cardPatternA.GetType() == typeof(CardPatterns.FullHouse);
    }
    public override void DoHandling(CardPattern cardPatternA, CardPattern cardPatternB)
    {
        var cardPatternARank = cardPatternA.Cards.ToLookup(x => x.Rank).MaxBy(x => x.Count())?.First().Rank;
        var cardPatternBRank = cardPatternA.Cards.ToLookup(x => x.Rank).MaxBy(x => x.Count())?.First().Rank;
        if (cardPatternARank == null || cardPatternBRank == null)
            return;

        var result = cardPatternARank.Value.CompareTo(cardPatternBRank.Value);
        SetResult(result);
    }
}
