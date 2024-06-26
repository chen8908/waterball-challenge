
using Card_Template.Games.Uno.Enums;

namespace Card_Template.Games.Uno;

public class Deck : BaseGame.Deck
{
    public Deck()
    {
        foreach (var color in Enum.GetValues<Color>())
        {
            for(int i = 0; i <= 9; i++)
                Cards.Add(new Card(color, i));
        }
    }
}
