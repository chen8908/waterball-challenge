using Card_Template.Games.BaseGame;

namespace Card_Template.Games.Uno;

public class Uno(IEnumerable<IPlayer> players) : CardGame(players, new Deck())
{
    private const int PlayerCardInitCount = 5;
    private List<Card> Mesa { get; set; } = new();

    private Card GetLastCardOfMesa()
    {
        return Mesa.Last();
    }

    protected override void Init()
    {
        base.Init();

        // 將牌堆第一張放於檯面
        if (Deck.Cards.Any())
        {
            var card = Deck.Draw();
            if (card is Card unoCard)
                Mesa.Add(unoCard);
        }
    }

    protected override bool DrawCardCondition()
    {
        return Players.Any(x => x.Hand.Cards.Count < PlayerCardInitCount);
    }

    protected override bool GameProgressCondition()
    {
        return Players.All(x => x.Hand.Cards.Any());
    }

    protected override void RoundOfGameInProgress()
    {
        if (!Deck.Cards.Any())
            RefillDeckFromMesa();
        foreach(Player player in Players.Cast<Player>())
        {
            // consloe Mesa top card
            var lastCard = GetLastCardOfMesa();
            Console.WriteLine("Please take a card what color or number is equal to Mesa top card.");
            Console.WriteLine($"The Mesa current top card is {lastCard.Color} {lastCard.Number}");
            var card = player.TakeTurn(lastCard);

            if (card is Card unoCard)
            {
                Mesa.Add(unoCard);
                var cardsOfHand = player.Hand.Cards.ToList();
                cardsOfHand.Remove(card);
                player.Hand.Cards = cardsOfHand;
            }
            else
            {
                var cardToDraw = Deck.Draw();
                if (cardToDraw is not null)
                    player.Hand.Cards.Add(cardToDraw);
            }
        }
    }

    protected override IPlayer? FindWinner() =>
        // return a player who no any card in hand
        Players.FirstOrDefault(x => x.Hand.Cards.Any() == false);

    private void RefillDeckFromMesa()
    {
        var lastCardOfMesa = Mesa.Last();
        Deck.Cards = Mesa
            .Where(x => x != lastCardOfMesa)
            .Cast<ICard>().ToList();
        Mesa = [lastCardOfMesa];
    }
}
