using System.Text;

namespace Big2;

public class HumanPlayer(int index, CardPatternValidator cardPatternValidator) : Player(index, cardPatternValidator)
{
    public override void SetName()
    {
        while(true)
        {
            Console.WriteLine("請輸入玩家名稱：");
            var name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
            {
                Name = name;
                break;
            }
        }
    }
    public override CardPattern? Play(CardPattern? topCard, int round, int turn)
    {
        while (true)
        {
            Console.WriteLine("請出牌");
            var playerShow = Console.ReadLine();
            if (!TryParseShowCard(playerShow, out var cards))
                continue;
            else if (cards is null)
            {
                Console.WriteLine($"玩家 {Name} PASS.");
                return default;
            }
            // 是否為合法牌型
            if (CardPatternValidator.IsLegal(cards, out var cardPattern) && cardPattern is not null)
            {
                if (turn == 1 || topCard is null)
                {
                    if (round == 1 && !cardPattern.Cards.Any(x => x.Suit == Suit.Club && x.Rank == Rank.Three))
                        continue;
                    return Show(cards, cardPattern);;
                }
                else
                {
                    // 判斷是否為同牌型 且 是否比頂牌大
                    if (CardPatternValidator.IsSame(topCard, cardPattern) && CardPatternValidator.Compare(cardPattern, topCard) == CompareResult.Bigger)
                        return Show(cards, cardPattern);
                    else
                        continue;
                }
            }
            else
                continue;
        }
    }
    /// <summary>
    /// 出牌
    /// </summary>
    /// <param name="cards"></param>
    /// <param name="cardPattern"></param>
    /// <returns></returns>
    private CardPattern Show(List<Card> cards, CardPattern cardPattern)
    {
        var cardsInfo = new StringBuilder();
        for (int i = 0; i < cards.Count; i++)
            cardsInfo.Append(cards[i].ToString().PadRight(3));

        Console.WriteLine($"玩家 {Name} 打出了 {cardPattern.Name} {cardsInfo}");
        Hand.Remove(cards);
        return cardPattern;
    }
    /// <summary>
    /// 嘗試將使用者輸入轉為卡牌
    /// </summary>
    /// <param name="input">使用者輸入值</param>
    /// <param name="cards">卡牌</param>
    /// <returns></returns>
    private bool TryParseShowCard(string? input, out List<Card>? cards)
    {
        cards = default;
        if (string.IsNullOrWhiteSpace(input))
            return false;
        var cardsIndexArray = input.Split(' ');
        if (cardsIndexArray is null || cardsIndexArray.Length <= 0)
            return false;

        var cardsIndex = Enumerable.Empty<int>();
        foreach(var item in cardsIndexArray)
        {
            if (!int.TryParse(item, out var index))
                return false;
            else
                cardsIndex = cardsIndex.Append(index);
        }
        if (cardsIndex.Any(x => x >= Hand.Cards.Count))
            return false;
        if (cardsIndex.All(x => x >= 0))
        {
            var cardList = new List<Card>();
            foreach(var index in cardsIndex)
                cardList.Add(Hand.Cards[index]);
            cards = cardList;
        }
        
        return true;
    }
}
