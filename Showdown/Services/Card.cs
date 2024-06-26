using Showdown.Enums;

namespace Showdown.Services;

public class Card(Rank rank, Suit suit)
{
    public Rank Rank { get; } = rank;
    public Suit Suit { get; } = suit;
}
