namespace Big2;

public abstract class Player(int index, CardPatternValidator cardPatternValidator)
{
    public CardPatternValidator CardPatternValidator { get; } = cardPatternValidator;
    public int Index { get; } = index;
    public string Name { get; protected set; } = string.Empty;
    public Hand Hand { get; set; } = new Hand();
    public abstract void SetName();
    public abstract CardPattern? Play(CardPattern? topCard, int round, int turn);
}
