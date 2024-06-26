using Showdown.Abstractions;

namespace Showdown.Services;

public class HumanPlayer : IPlayer
{
    public Hand Hand { get; set; } = new Hand();
    public string Name { get; private set; } = string.Empty;
    public int Point { get; private set; } = 0;
    public bool IsExchangedHand { get; set; } = false;
    public int? ExchangeHandsRound { get; set; }
    public IPlayer? ExchangedPlayer { get; set; }
    public void SetName()
    {
        string? playerName;
        do
        {
            Console.WriteLine("請輸入玩家名稱：");
            playerName = Console.ReadLine();

        }while(string.IsNullOrWhiteSpace(playerName));

        Name = playerName;
    }
    public void AddPoint()
    {
        Point++;
    }
}
