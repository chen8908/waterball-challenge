using Card_Template.Games.BaseGame;
using Card_Template.Games.Showdown.Enums;

namespace Card_Template.Games.Showdown;

public class Card(Rank rank, Suit suit): ICard
{
    public Rank Rank { get; } = rank;
    public Suit Suit { get; } = suit;
    
    public static Card Max(IList<Card> cards)
    {
        return cards
            .OrderByDescending(x => x.Rank)
            .ThenByDescending(x => x.Suit)
            .First();
    }
}
