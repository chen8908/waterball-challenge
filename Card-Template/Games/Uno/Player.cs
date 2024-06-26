using Card_Template.Games.BaseGame;

namespace Card_Template.Games.Uno;

public abstract class Player : IPlayer
{
    public IHand Hand { get; set; } = new Hand();
    public string Name { get; protected set; } = string.Empty;
    public abstract void NameHimself();
    public abstract ICard? TakeTurn();
    public abstract ICard? TakeTurn(Card lastCard);
}
