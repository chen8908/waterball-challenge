using Card_Template.Games.BaseGame;

namespace Card_Template.Games.Showdown;

public class Showdown: CardGame
{
    private const int PlayerMaxLimit = 4;
    private const int PlayerCardMaxLimit = 13;
    private const int RoundMaxLimit = 13;
    public Showdown(IList<Player> players) : base(players, new Deck())
    {
        if (!players.Any() || players.Count > PlayerMaxLimit)
            throw new ArgumentException(
                "The number of players in the game should be between 1-4 players.");
    }
    
    protected override bool DrawCardCondition()
    {
        return Players.Any(x => x.Hand.Cards.Count < PlayerCardMaxLimit);
    }

    protected override bool GameProgressCondition()
    {
        return Round < RoundMaxLimit;
    }

    protected override void RoundOfGameInProgress()
    {
        var resultDict = new Dictionary<Player, Card>();
        foreach (var player in Players)
        {
            var card = player.TakeTurn();
            if (player is Player showdownPlayer &&
                card is Card showdownCard)
                resultDict.Add(showdownPlayer, showdownCard);
        }

        Console.WriteLine($@"==== 回合 {Round} 結束，以下顯示各玩家出牌 ====");
        foreach(var player in Players)
        {
            if (player is Player showdownPlayer &&
            resultDict.TryGetValue(showdownPlayer, out var card))
                Console.WriteLine($@"{player.Name}: {card.Rank} {card.Suit}");
            else
                Console.WriteLine($@"{player.Name} 未出牌。");
        }

        var maxCard = Card.Max([.. resultDict.Values]);
        var winner = resultDict
            .FirstOrDefault(x => x.Value == maxCard)
            .Key;
        
        winner.Point++;
    }

    protected override Player? FindWinner()
    {
        var players = new List<Player>();
        foreach (var player in Players)
        {
            if (player is Player showdownPlayer)
            {
                players.Add(showdownPlayer);
                Console.WriteLine($@"{showdownPlayer.Name} gain {showdownPlayer.Point} points.");
            }
        }
        return players.MaxBy(x => x.Point);
    }
}
