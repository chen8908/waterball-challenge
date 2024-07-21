namespace Big2;

public class CardPatternValidator(List<CardPattern> cardPatterns, CardPatternCompare cardPatternCompare)
{
    public CardPatternCompare CardPatternCompare { get; } = cardPatternCompare;
    public List<CardPattern> CardPatterns { get; } = cardPatterns;

    /// <summary>
    /// 是否為合法牌型
    /// </summary>
    /// <param name="cards">卡牌</param>
    /// <param name="cardPattern">牌型</param>
    /// <returns></returns>
    public bool IsLegal(List<Card> cards, out CardPattern? cardPattern)
    {
        cardPattern = default;
        foreach (var item in CardPatterns)
        {
            if (item.Verify(cards))
            {
                cardPattern = item.Build(cards);
                return true;
            }
        }
        return false;
    }
    /// <summary>
    /// 是否為相同牌型
    /// </summary>
    /// <param name="cardPatternA">牌型A</param>
    /// <param name="cardPatternB">牌型B</param>
    /// <returns></returns>
    public static bool IsSame(CardPattern cardPatternA, CardPattern cardPatternB)
    {
        return cardPatternA.GetType() == cardPatternB.GetType();
    }
    /// <summary>
    /// 比較大小
    /// </summary>
    /// <param name="cardPatternA">牌型A</param>
    /// <param name="cardPatternB">牌型B</param>
    /// <returns></returns>
    public CompareResult Compare(CardPattern cardPatternA, CardPattern cardPatternB)
    {
        CardPatternCompare.Compare(cardPatternA, cardPatternB);
        return CardPatternCompare.Result;
    }
}
