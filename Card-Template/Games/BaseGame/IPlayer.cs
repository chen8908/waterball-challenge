namespace Card_Template.Games.BaseGame;

public interface IPlayer
{
    IHand Hand { get; set; }
    string Name { get; }
    void NameHimself();
    ICard? TakeTurn();
}