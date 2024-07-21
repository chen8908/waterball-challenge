namespace Big2;

public class AiPlayer(int index) : Player(index)
{
    public override void SetName()
    {
        Name = "AI.Plyaer";
    }
    public override CardPattern? Play(CardPattern? topCard, int round, int turn)
    {
        return default;
    }
}
