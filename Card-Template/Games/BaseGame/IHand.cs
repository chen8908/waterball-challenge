namespace Card_Template.Games.BaseGame;

public interface IHand
{
    IList<ICard> Cards { get; set; }
}