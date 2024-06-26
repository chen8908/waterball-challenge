
using Showdown.Abstractions;
using Showdown.Services;

const int CountOfGamePlayer = 4;
int humanPlayerCount = 0;

do
{
    Console.WriteLine("請輸入真實玩家人數：");
    var input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out var count) || count <= 0)
        Console.WriteLine("人數請輸入正確格式。");
    else if (count > CountOfGamePlayer)
        Console.WriteLine($"此遊戲至多僅可 {CountOfGamePlayer} 位玩家參與。");
    else
        humanPlayerCount = count;

}while(humanPlayerCount <= 0);

// 玩家創建，不足數量則以 AI 玩家補足
var players = Enumerable.Empty<IPlayer>();
for(var i = 0; i < humanPlayerCount; i++)
    players = players.Append(new HumanPlayer());
for(var i = 0; i < CountOfGamePlayer - humanPlayerCount; i++)
    players = players.Append(new AiPlayer());

var game = new Game(players);
game.Play();
