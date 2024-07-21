namespace Big2;

public class Hand
{
    public List<Card> Cards { get; set; } = [];
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
