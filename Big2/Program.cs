using Big2;
using Big2.CardPatternCompares;

var cardPatterns = new List<CardPattern>()
{
    new Big2.CardPatterns.Single(),
    new Big2.CardPatterns.Pair(),
    new Big2.CardPatterns.Straight(),
    new Big2.CardPatterns.FullHouse()
};
var cardPatternCompare = new SingleCompare(new PairCompare(new StraghtCompare(new FullHouseCompare(null))));
var cardPatternValidator = new CardPatternValidator(cardPatterns, cardPatternCompare);
var players = new List<Player>()
{
    new HumanPlayer(0, cardPatternValidator),
    new HumanPlayer(1, cardPatternValidator),
    new HumanPlayer(2, cardPatternValidator),
    new HumanPlayer(3, cardPatternValidator)
};

var big2 = new Game(players);
big2.Start();
