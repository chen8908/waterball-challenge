namespace Big2.CardPatternCompares;

public class SingleCompare(CardPatternCompare? next) : CardPatternCompare(next)
{
    public override bool CanCompare(CardPattern cardPatternA, CardPattern cardPatternB)
    {
        return cardPatternA.GetType() == typeof(CardPatterns.Single) && cardPatternA.GetType() == typeof(CardPatterns.Single);
    }
    public override void DoHandling(CardPattern cardPatternA, CardPattern cardPatternB)
    {
        var cardA = cardPatternA.Cards.First();
        var cardB = cardPatternB.Cards.First();
        var result = cardA.Rank.CompareTo(cardB.Rank);
        if (result == 0)
            result = cardA.Suit.CompareTo(cardB.Suit);

        SetResult(result);
    }
}
