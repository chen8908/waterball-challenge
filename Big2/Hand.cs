namespace Big2;

public class Hand
{
    public List<Card> Cards { get; private set; } = [];

    public void Remove(List<Card> cards)
    {
        var cardList = Cards.ToList();
        cardList.RemoveAll(cards.Contains);
        Cards = cardList;
    }
    /// <summary>
    /// 印出含有索引的當前手牌
    /// </summary>
    public void PrintCardsWithIndices()
    {
        // 輸出索引號碼
        for (int i = 0; i < Cards.Count; i++)
            Console.Write(i.ToString().PadRight(5));
        Console.WriteLine();
        // 輸出卡片
        for (int i = 0; i < Cards.Count; i++)
            Console.Write(Cards[i].ToString().PadRight(5));
        Console.WriteLine();
    }
}
