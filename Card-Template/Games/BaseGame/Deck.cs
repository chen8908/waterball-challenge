namespace Card_Template.Games.BaseGame;

public abstract class Deck
{
    private readonly Random _random = new();
    public IList<ICard> Cards { get; set; } = [];

    public void Shuffle()
    {
        if (!Cards.Any())
            return;
        var cards = Cards.ToArray();
        _random.Shuffle(cards);
        Cards = cards;
    }

    public virtual ICard? Draw()
    {
        if (!Cards.Any())
            return default;
        
        var cardList = Cards.ToList();
        var index = _random.Next(0, Cards.Count);
        var card = cardList[index];
        cardList.Remove(card);
        Cards = cardList;
        
        return card;
    }
}