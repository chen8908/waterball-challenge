using Showdown.Abstractions;
using Showdown.Utilities;

namespace Showdown.Services;

public class Game(IEnumerable<IPlayer> players)
{
    private readonly Random _random = new();
    private const int CountOfPlayer = 4;
    public int Round { get; private set; } = 1;
    public Deck Deck { get; } = new Deck();
    public IEnumerable<IPlayer> Players { get; } = SetPlayers(players);

    public void Play()
    {
        // P1-P4 取名
        foreach(var player in Players)
            player.SetName();

        // 洗牌
        Deck.Shuffle();

        // 輪流抽牌，直到每人都有13張為止
        while(Deck.Cards.Count > 0)
        {
            foreach(var player in Players)
            {
                if (player.Hand.Cards.Count == 13)
                    continue;
                var playeGame = new PlayGame(this, player);
                var card = Deck.Cards[_random.Next(Deck.Cards.Count)];
                playeGame.DrawCard(card);
            }
        }

        var scoreBoard = new Dictionary<int, Dictionary<IPlayer, Card>>();

        // 13回合進行
        for(var i = 1; i <= 13; i++)
        {
            Round = i;
            Console.WriteLine($"===== Round {i} =====");
            var scoreBoardOfRound = new Dictionary<IPlayer, Card>();

            // P1-P4 輪流－決定交換手牌、出牌
            foreach(var player in Players)
            {
                var playeGame = new PlayGame(this, player);
                var card = playeGame.TakeATurn();

                scoreBoardOfRound.Add(player, card);
            }
            scoreBoard.Add(i ,scoreBoardOfRound);

            // 顯示這回合所有玩家出的牌
            foreach(var item in scoreBoardOfRound)
            {
                if (item.Value is null)
                    Console.WriteLine($"玩家 {item.Key.Name} 未出牌");
                else
                    Console.WriteLine($"玩家 {item.Key.Name} 出了 {item.Value.Suit.GetDescription()} {item.Value.Rank.GetDescription()} ");
            }

            // 比較大小
            var theBiggestPlayer = CompareCardAndGetTheBiggestPlayer(scoreBoardOfRound);

            // 獲勝者加點數
            theBiggestPlayer.AddPoint();
            Console.WriteLine($"此回合，玩家 {theBiggestPlayer.Name} 獲勝，獲得點數一點");
        }

        // 顯示獲勝者名稱及分數
        var maxPoint = Players.Max(x => x.Point);
        var winners = Players.Where(x => x.Point == maxPoint) ?? throw new Exception("NO ANY PLYAER IS WINNER.");
        var winnersName = string.Join('、', winners.Select(x => x.Name));

        Console.WriteLine($"恭喜玩家 {winnersName} 獲勝，共取得了 {maxPoint} 分");
    }

    private static IPlayer CompareCardAndGetTheBiggestPlayer(Dictionary<IPlayer, Card> showCardDict)
    {
        var cards = showCardDict.Values;
        var maxRank = cards.Max(x => x.Rank);
        var maxCard = cards.Where(x => x.Rank == maxRank).MaxBy(x => x.Suit) ?? throw new Exception("NO ANY CARD IS THE BIGGEST.");
        var biggest = showCardDict.FirstOrDefault(x => x.Value == maxCard);

        return biggest.Key;
    }

    private static IEnumerable<IPlayer> SetPlayers(IEnumerable<IPlayer> players)
    {
        if (players is null || !players.Any() || players.Count() != CountOfPlayer)
            throw new Exception($"應須有 {CountOfPlayer} 位玩家進行遊戲");
        return players;
    }
}
