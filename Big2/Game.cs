namespace Big2;

public class Game(List<Player> players)
{
    private readonly List<Player> _players = players;
    public int Round { get; private set; } = 1;
    public IList<CardPattern?> Mesa { get; private set; } = [];
    public Deck Deck { get; private set; } = new Deck();

    /// <summary>
    /// 遊戲開始
    /// </summary>
    public void Start()
    {
        foreach (var player in _players)
            player.SetName();
        
        Deck.Suffle();
        do
        {
            foreach (var player in _players)
                Deck.Deal(player);
        }while(Deck.Cards.Count > 0);

        Player? topPlayer = default;
        do
        {
            Console.WriteLine("新的回合開始了。");
            var turn = 1;
            while(true)
            {
                // 若有三個 pass，則回合結束，進入下一回合
                if (Mesa.Any() && Mesa.Count >= 3 && Mesa.TakeLast(3).All(x => x is null))
                {
                    Mesa.Clear();
                    break;
                }
                topPlayer = (Round == 1 && turn == 1) || topPlayer is null ? 
                    _players.First(x => x.Hand.Cards.Any(c => c.Rank == Rank.Three && c.Suit == Suit.Club)) :
                    _players.First(x => (topPlayer.Index + 1) % 4 == x.Index);

                Console.WriteLine($"輪到 {topPlayer.Name} 了");
                topPlayer.Hand.PrintCardsWithIndices();
                var topPlay = GetTopPlayByMesa();
                var cardPattern = topPlayer.Play(topPlay, Round, turn);
                Mesa.Add(cardPattern);
                turn++;
            }
        }while(_players.All(x => x.Hand.Cards.Count > 0));

        var winner = _players.First(x => x.Hand.Cards.Count == 0);
        Console.WriteLine($"🎉 Winner is {winner.Name}. 🎉");
    }

    /// <summary>
    /// 由檯面取得頂牌
    /// </summary>
    /// <returns></returns>
    private CardPattern? GetTopPlayByMesa() => Mesa.Any() ? Mesa.LastOrDefault(x => x is not null) : default;
}
