using Showdown.Abstractions;
using Showdown.Utilities;

namespace Showdown.Services;

public class PlayGame(Game game, IPlayer player)
{
    private const int ExchangeHandsRollBackRound = 3;
    private readonly Random _random = new ();
    public Game Game { get; } = game;
    public IPlayer Player { get; } = player;

    /// <summary>
    /// 發牌至玩家手牌
    /// </summary>
    /// <param name="card">牌</param>
    public void DrawCard(Card card)
    {
        Game.Deck.RemoveCard(card);
        Player.Hand.Cards.Add(card);
    }
    /// <summary>
    /// 輪流－進行交換手牌與玩家出牌
    /// </summary>
    /// <returns></returns>
    public Card TakeATurn()
    {
        // 交換手牌
        if (!Player.IsExchangedHand)
        {
            Console.WriteLine("請問要交換手牌嗎？y/n：");
            switch(Player)
            {
                case HumanPlayer:
                    var input = Console.ReadLine();
                    if (input?.ToLower() == "y")
                        ExchangeHands();
                    break;
                default:
                    Console.WriteLine("n");
                    break;
            }
        }
        else
        {
            // 檢查是否需換回手牌
            if (Player.ExchangeHandsRound.HasValue && Player.ExchangedPlayer is not null && 
            Game.Round == Player.ExchangeHandsRound.Value + ExchangeHandsRollBackRound)
             {
                (Player.Hand, Player.ExchangedPlayer.Hand) = (Player.ExchangedPlayer.Hand, Player.Hand);
                Console.WriteLine("成功換回手牌");
             }
        }
        
        // 玩家出牌
        return Show();
    }

    private void ExchangeHands()
    {
        Console.WriteLine("以下為可交換手牌的玩家：");
        
        var index = 0;
        IList<IPlayer> players = Game.Players.Where(x => x != Player).ToList();
        foreach(var player in players)
            Console.WriteLine($"{index++}:{player.Name}");

        int? choicedIndex = null;
        do
        {
            Console.WriteLine("請選擇：");
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out var playerIndex))
                Console.WriteLine("選擇玩家請以正確格式輸入。");
            else if(playerIndex >= players.Count)
                Console.WriteLine("請選擇範圍內的玩家。");
            else
                choicedIndex = playerIndex;
                
        }while(choicedIndex is null);

        (Player.Hand, players[choicedIndex.Value].Hand) = (players[choicedIndex.Value].Hand, Player.Hand);
        Player.IsExchangedHand = true;
        Player.ExchangeHandsRound = Game.Round;
        Player.ExchangedPlayer = players[choicedIndex.Value];
        Console.WriteLine($@"成功交換手牌，{ExchangeHandsRollBackRound} 回合後自動換回。");
    }

    /// <summary>
    /// 玩家出牌
    /// </summary>
    /// <returns></returns>
    private Card Show()
    {
        int? choicedCardIndex = null;
        do
        {
            Console.WriteLine("請出牌：");
            switch(Player)
            {
                case HumanPlayer:
                    var index = 0;
                    Console.WriteLine("以下為您目前的手牌：");
                    foreach(var card in Player.Hand.Cards)
                        Console.WriteLine($"{index++}:{card.Suit.GetDescription()} {card.Rank.GetDescription()}");
                    var input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out var choisedValue))
                        Console.WriteLine("請以正確格式出牌，請重新出牌。");
                    else if (choisedValue >= Player.Hand.Cards.Count)
                        Console.WriteLine("請勿超出手牌範圍，請重新出牌。");
                    else
                        choicedCardIndex = choisedValue;
                    break;
                default:
                    choicedCardIndex = _random.Next(0, Player.Hand.Cards.Count);
                    break;
            }
        }while(choicedCardIndex is null);

        var showCard = Player.Hand.Cards[choicedCardIndex.Value];
        Player.Hand.RemoveCard(showCard);

        return showCard;
    }
}
