namespace Big2.CardPatterns;

public class Straight : CardPattern
{
    public Straight()
    {
        Name = "順子";
    }
    private const int CountOfCard = 5;
    public override bool Verify(List<Card> cards)
    {
        if (cards is null || cards.Count != CountOfCard)
            return false;

        // 將卡片按Rank排序
        cards = [.. cards.OrderBy(card => card.Rank)];

        // 檢查是否是順子
        for (int i = 1; i < cards.Count; i++)
        {
            if (cards[i].Rank != cards[i - 1].Rank + 1)
                return false;
        }

        return true;
    }
    public override CardPattern Build(List<Card> cards)
    {
        return new Straight() { Cards = cards };
    }
}
