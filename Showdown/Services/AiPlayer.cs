using Showdown.Abstractions;

namespace Showdown.Services;

public class AiPlayer : IPlayer
{
    private readonly Random _random = new ();
    public Hand Hand { get; set; } = new Hand();
    public string Name { get; private set; } = string.Empty;
    public int Point { get; private set; } = 0;
    public bool IsExchangedHand { get; set; } = false;
    public int? ExchangeHandsRound { get; set; }
    public IPlayer? ExchangedPlayer { get; set; }
    public void SetName()
    {
        Name = $"Player {_random.Next(0, 5000):0000}";
    }
    public void AddPoint()
    {
        Point++;
    }
}
