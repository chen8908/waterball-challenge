using Big2.Utilities;

namespace Big2;

public class Card(Rank rank, Suit suit)
{
    public Rank Rank { get; } = rank;
    public Suit Suit { get; } = suit;
    public override string ToString()
    {
        return $"{Suit.GetEnumDescription()}[{Rank.GetEnumDescription()}]";
    }
}
