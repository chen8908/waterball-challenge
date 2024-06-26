using Card_Template.Games.Showdown.Enums;

namespace Card_Template.Games.Showdown;

public class Deck : BaseGame.Deck
{
    public Deck()
    {
        foreach (var rank in Enum.GetValues<Rank>())
        {
            foreach (var suit in Enum.GetValues<Suit>())
                Cards.Add(new Card(rank, suit));
        }
    }
}
