
using Card_Template.Games.BaseGame;

namespace Card_Template.Games.Showdown;

public class AIPlayer : Player
{
    private readonly Random _random = new();
    public override void NameHimself()
    {
        Name = $"AI Player {_random.Next(0, 10000)}";
    }

    public override ICard? TakeTurn()
    {
        return !Hand.Cards.Any() ? null : Hand.Cards[_random.Next(0, Hand.Cards.Count)];
    }
}