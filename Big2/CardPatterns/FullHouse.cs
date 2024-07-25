namespace Big2.CardPatterns;

public class FullHouse : CardPattern
{
    public FullHouse()
    {
        Name = "葫蘆";
    }
    private const int CountOfCard = 5;
    public override bool Verify(List<Card> cards)
    {
        if (cards is null || cards.Count != CountOfCard)
            return false;
        var cardsLookup = cards.ToLookup(x => x.Rank);
        if (cardsLookup is null || cardsLookup.Count != 2)
            return false;

        bool hasThreeOfAKind = false;
        bool hasPair = false;
        foreach (var group in cardsLookup)
        {
            if (group.Count() == 3)
                hasThreeOfAKind = true;
            else if (group.Count() == 2)
                hasPair = true;
        }

        return hasThreeOfAKind && hasPair;
    }
    public override CardPattern Build(List<Card> cards)
    {
        return new FullHouse() { Cards = cards };
    }
}
