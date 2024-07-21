namespace Big2;

public class HumanPlayer(int index) : Player(index)
{
    public override void SetName()
    {
        while(true)
        {
            Console.WriteLine("請輸入玩家名稱：");
            var name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
            {
                Name = name;
                break;
            }
        }
    }
    public override CardPattern? Play(CardPattern? topCard, int round, int turn)
    {
        return default;
    }
}
