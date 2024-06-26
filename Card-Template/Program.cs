using Card_Template.Games.Showdown;
using Card_Template.Games.Uno;

IList<Card_Template.Games.Showdown.Player> showdownPlayers =
[
    new Card_Template.Games.Showdown.HumanPlayer(),
    new Card_Template.Games.Showdown.HumanPlayer(),
    new Card_Template.Games.Showdown.AIPlayer(),
    new Card_Template.Games.Showdown.AIPlayer()
];

// showdown game
var showdownGame = new Showdown(showdownPlayers);
showdownGame.Start();

// uno game
IList<Card_Template.Games.Uno.Player> unoPlayers =
[
    new Card_Template.Games.Uno.HumanPlayer(),
    new Card_Template.Games.Uno.HumanPlayer(),
    new Card_Template.Games.Uno.AIPlayer(),
    new Card_Template.Games.Uno.AIPlayer()
];

var unoGame = new Uno(unoPlayers);
unoGame.Start();
