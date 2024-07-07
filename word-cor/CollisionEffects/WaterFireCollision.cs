using word_cor.Abstraction;

namespace word_cor;

public class WaterFireCollision(CollisionEffect? nextHandler) : CollisionEffect(nextHandler)
{
    public override bool Match(Sprite spriteA, Sprite spriteB)
    {
        return (spriteA is Water && spriteB is Fire) || 
            (spriteA is Fire && spriteB is Water);
    }
    public override void DoHandling(Sprite spriteA, Sprite spriteB)
    {
        spriteA.RemoveFormWord();
        spriteB.RemoveFormWord();
        Console.WriteLine($"於世界中移除 生命{spriteA.Name} 與 生命{spriteB.Name}");
    }
}
