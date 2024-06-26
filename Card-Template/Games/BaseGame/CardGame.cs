namespace Card_Template.Games.BaseGame;

public class CardGame(IEnumerable<IPlayer> players, Deck deck)
{
    protected IEnumerable<IPlayer> Players { get; set; } = players;
    protected Deck Deck { get; } = deck;
    protected int Round { get; private set; } = 1;
    
    public void Start()
    {
        // 遊戲初始化
        Init();

        // 回合遊戲
        while(GameProgressCondition())
        {
            RoundOfGameInProgress();
            Round++;
        }

        var winner = FindWinner();
        Console.WriteLine(winner != null
            ? $@"The player {winner.Name} is winner! Congratulations!🏅"
            : "Oops! No any player win.");
    }

    protected virtual void Init()
    {
        // 玩家取名
        foreach (var player in Players)
            player.NameHimself();
        // 洗牌
        Deck.Shuffle();
        // 發牌
        while(DrawCardCondition())
        {
            foreach (var player in Players)
            {
                var card = Deck.Draw();
                if (card is null)
                    continue;
                player.Hand.Cards.Add(card);
            }
        }
    }

    protected virtual bool DrawCardCondition()
    {
        return false;
    }

    protected virtual bool GameProgressCondition()
    {
        return false;
    }

    protected virtual void RoundOfGameInProgress()
    {
        // play round of game.
    }

    protected virtual IPlayer? FindWinner()
    {
        return default;
    }
}