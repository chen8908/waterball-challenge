using Showdown.Services;

namespace Showdown.Abstractions;

public interface IPlayer
{
    Hand Hand { get; set; }
    string Name { get; }
    int Point { get; }
    bool IsExchangedHand { get; set; }
    int? ExchangeHandsRound { get; set; }
    IPlayer? ExchangedPlayer { get; set; }
    void SetName();
    void AddPoint();
}
