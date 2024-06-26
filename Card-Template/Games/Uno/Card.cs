using Card_Template.Games.BaseGame;
using Card_Template.Games.Uno.Enums;

namespace Card_Template.Games.Uno;

public class Card : ICard
{
    public Card(Color color, int number)
    {
        if (number < 0 || number > 9)
            throw new ArgumentOutOfRangeException(
                $@"The value '{number}' is not within the reasonable range. Please set the value between 0-9.");

        Color = color;
        Number = number;
    }

    public Color Color { get; set; }
    public int Number { get; set; } = 0;
}
