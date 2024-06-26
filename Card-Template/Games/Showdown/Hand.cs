using Card_Template.Games.BaseGame;

namespace Card_Template.Games.Showdown;

public class Hand : IHand
{
    public IList<ICard> Cards { get; set; } = new List<ICard>();
}
