namespace word_cor.Abstraction;

public abstract class CollisionEffect(CollisionEffect? nextHandler)
{
    public CollisionEffect? NextHandler { get; set; } = nextHandler;
    public abstract bool Match(Sprite spriteA, Sprite spriteB);

    public void Handle(Sprite spriteA, Sprite spriteB)
    {
        if (Match(spriteA, spriteB))
            DoHandling(spriteA, spriteB);
        else
            NextHandler?.Handle(spriteA, spriteB);
    }
    public abstract void DoHandling(Sprite spriteA, Sprite spriteB);
}
