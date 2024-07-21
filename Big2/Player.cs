namespace Big2;

public abstract class Player(int index)
{
    public CardPatternValidator? CardPatternValidator { get; private set; } = default;
    public int Index { get; } = index;
    public string Name { get; protected set; } = string.Empty;
    public Hand Hand { get; set; } = new Hand();
    public abstract void SetName();
    public abstract CardPattern? Play(CardPattern? topCard, int round, int turn);
    public void SetCardPatternValidator(CardPatternValidator cardPatternValidator)
    {
        CardPatternValidator = cardPatternValidator;
    }
}
