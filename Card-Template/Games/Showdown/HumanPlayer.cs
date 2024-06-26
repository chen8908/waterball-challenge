using Card_Template.Games.BaseGame;

namespace Card_Template.Games.Showdown;

public class HumanPlayer : Player
{
    public override void NameHimself()
    {
        string? name;
        do
        {
            Console.WriteLine("請輸入您的姓名：");
            name = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(name));
        Name = name;
    }

    public override ICard? TakeTurn()
    {
        if (!Hand.Cards.Any())
            return null;
        
        var cardsOfHand = Hand.Cards.ToList();
        var cardDict = new Dictionary<int, ICard>();
        var index = 0;
        foreach (var cardOfHand in cardsOfHand)
        {
            if (cardOfHand is not Card showdownCard)
                continue;

            cardDict.Add(index, showdownCard);
            Console.WriteLine($"{index}:{showdownCard.Rank}{showdownCard.Suit}");
            index++;
        }
        ICard? card = null;
        do
        {
            Console.WriteLine("請出牌：");
            var choiceCardIndex = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(choiceCardIndex) &&
                int.TryParse(choiceCardIndex, out var choiceIndex) &&
                cardDict.TryGetValue(choiceIndex, out var tempCard))
                card = tempCard;
        } while (card is null);

        cardsOfHand.Remove(card);
        Hand.Cards = cardsOfHand;

        return card;
    }
}
