using word_cor.Abstraction;

namespace word_cor;

public class SameSpriteCollision(CollisionEffect? nextHandler) : CollisionEffect(nextHandler)
{
    public override bool Match(Sprite spriteA, Sprite spriteB)
    {
        return spriteA.GetType() == spriteB.GetType();
    }
    public override void DoHandling(Sprite spriteA, Sprite spriteB)
    {
        Console.WriteLine("移動失敗。");
    }
}
