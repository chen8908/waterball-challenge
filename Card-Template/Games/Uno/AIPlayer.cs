using Card_Template.Games.BaseGame;

namespace Card_Template.Games.Uno;

public class AIPlayer : Player
{
    private readonly Random _random = new();
    public override void NameHimself()
    {
        Name = $"AI Player {_random.Next(0, 10000)}";
    }

    public override ICard? TakeTurn()
    {
        return default;
    }

    public override ICard? TakeTurn(Card lastCard)
    {
        if (!Hand.Cards.Any())
            return null;

        var validCards = Hand.Cards.Cast<Card>()
            .Where(x => x.Color == lastCard.Color || x.Number == lastCard.Number);
        var choiceIndex = _random.Next(0, validCards.Count());
        if (validCards != null && validCards.Any() && validCards.Count() >= choiceIndex)
            return validCards.ElementAt(choiceIndex);

        return default;
    }
}
