using Showdown.Enums;

namespace Showdown.Services;

public class Deck
{
    private readonly Random _random = new();
    public IList<Card> Cards { get; private set; } = [];
    public Deck()
    {
        foreach(Rank rank in Enum.GetValues(typeof(Rank)))
        {
            foreach(Suit suit in Enum.GetValues(typeof(Suit)))
                Cards.Add(new Card(rank, suit));
        }
    }
    /// <summary>
    /// 洗牌
    /// </summary>
    public void Shuffle()
    {
        var array = Cards.ToArray();
        int n = array.Length;
        while (n > 1)
        {
            n--;
            int k = _random.Next(n + 1);
            (array[n], array[k]) = (array[k], array[n]);
        }

        Cards = array;
    }
    public void RemoveCard(Card card)
    {
        var cardList = Cards.ToList();
        cardList.Remove(card);
        Cards = cardList;
    }
}
