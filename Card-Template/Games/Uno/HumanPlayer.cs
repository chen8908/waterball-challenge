using Card_Template.Games.BaseGame;

namespace Card_Template.Games.Uno;

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
        return default;
    }

    public override ICard? TakeTurn(Card lastCard)
    {
        if (!Hand.Cards.Any())
            return null;
        
        var cardsOfHand = Hand.Cards.ToList();
        var cardDict = new Dictionary<int, ICard>();
        var index = 0;
        foreach (var cardOfHand in cardsOfHand)
        {
            if (cardOfHand is not Card unoCard)
                continue;

            cardDict.Add(index, unoCard);
            Console.WriteLine($"{index}:{unoCard.Color} {unoCard.Number}");
            index++;
        }
        ICard? card = null;
        do
        {
            Console.WriteLine("請出牌：");
            var choiceCardIndex = Console.ReadLine();
            if (choiceCardIndex == "pass")
                break;
            else if (!string.IsNullOrWhiteSpace(choiceCardIndex) &&
                int.TryParse(choiceCardIndex, out var choiceIndex) &&
                cardDict.TryGetValue(choiceIndex, out var tempCard))
                card = tempCard;
        } while (card is not Card unoCard ||
                (unoCard.Color != lastCard.Color && 
                unoCard.Number != lastCard.Number));

        return card;
    }
}
