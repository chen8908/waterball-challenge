namespace Big2.CardPatternCompares;

public class StraghtCompare(CardPatternCompare? next) : CardPatternCompare(next)
{
    public override bool CanCompare(CardPattern cardPatternA, CardPattern cardPatternB)
    {
        return cardPatternA.GetType() == typeof(CardPatterns.Straight) && cardPatternA.GetType() == typeof(CardPatterns.Straight);
    }
    public override void DoHandling(CardPattern cardPatternA, CardPattern cardPatternB)
    {
        var biggestOfCardARank = cardPatternA.Cards.Max(x => x.Rank);
        var biggestOfCardBRank = cardPatternA.Cards.Max(x => x.Rank);
        var result = biggestOfCardARank.CompareTo(biggestOfCardBRank);

        SetResult(result);
    }
}
