namespace Big2.CardPatternCompares;

public class PairCompare(CardPatternCompare? next) : CardPatternCompare(next)
{
    public override bool CanCompare(CardPattern cardPatternA, CardPattern cardPatternB)
    {
        return cardPatternA.GetType() == typeof(CardPatterns.Pair) && cardPatternA.GetType() == typeof(CardPatterns.Pair);
    }
    public override void DoHandling(CardPattern cardPatternA, CardPattern cardPatternB)
    {
        var firstOfCardARank = cardPatternA.Cards.First().Rank;
        var firstOfCardBRank = cardPatternB.Cards.First().Rank;
        var result = firstOfCardARank.CompareTo(firstOfCardBRank);

        SetResult(result);
    }
}
