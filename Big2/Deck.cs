namespace Big2;

public class Deck
{
    private readonly Random _random = new();
    public IList<Card> Cards { get; private set; } = [];

    public Deck()
    {
        foreach(Rank rank in Enum.GetValues<Rank>())
        {
            foreach(Suit suit in Enum.GetValues<Suit>())
                Cards.Add(new Card(rank, suit));
        }
    }

    /// <summary>
    /// 洗牌
    /// </summary>
    public void Suffle()
    {
        if (!Cards.Any())
            return;
        var cards = Cards.ToArray();
        _random.Shuffle(cards);
        Cards = cards;
    }

    /// <summary>
    /// 發牌
    /// </summary>
    /// <param name="player"></param>
    public void Deal(Player player)
    {
        var card = Cards.LastOrDefault();
        if (card is null)
            return;
            
        Cards.Remove(card);
        player.Hand.Cards.Add(card);
    }
}
