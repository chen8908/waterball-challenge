namespace Big2;

public abstract class CardPattern()
{
    public string Name { get; protected set; } = string.Empty;
    public List<Card> Cards { get; protected set; } = [];
    public abstract bool Verify(List<Card> cards);
    public abstract CardPattern Build(List<Card> cards);
}
