namespace Showdown.Services;

public class Hand
{
    public IList<Card> Cards { get; private set; } = [];

    public void RemoveCard(Card card)
    {
        var cardList = Cards.ToList();
        cardList.Remove(card);
        Cards = cardList;
    }
}
