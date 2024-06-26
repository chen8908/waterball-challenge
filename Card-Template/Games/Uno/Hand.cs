using Card_Template.Games.BaseGame;

namespace Card_Template.Games.Uno;

public class Hand : IHand
{
    public IList<ICard> Cards { get; set; } = [];
}
