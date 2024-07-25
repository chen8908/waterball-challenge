namespace Big2.CardPatterns;

public class Single : CardPattern
{
    public Single()
    {
        Name = "單張";
    }
    private const int CountOfCard = 1;
    public override bool Verify(List<Card> cards)
    {
        return cards is not null && cards.Count == CountOfCard;
    }
    public override CardPattern Build(List<Card> cards)
    {
        return new Single() { Cards = cards };
    }
}
