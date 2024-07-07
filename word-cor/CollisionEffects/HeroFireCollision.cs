using word_cor.Abstraction;

namespace word_cor;

public class HeroFireCollision(CollisionEffect? nextHandler) : CollisionEffect(nextHandler)
{
    public override bool Match(Sprite spriteA, Sprite spriteB)
    {
        return (spriteA is Hero && spriteB is Fire) || 
            (spriteA is Fire && spriteB is Hero);
    }
    public override void DoHandling(Sprite spriteA, Sprite spriteB)
    {
        Hero heroSprite = (Hero)(spriteA is Hero ? spriteA : spriteB);
        var fireSprite = spriteA is Fire ? spriteA : spriteB;

        heroSprite.HP -= 10;
        if (heroSprite.IsDead())
            heroSprite.RemoveFormWord();
        fireSprite.RemoveFormWord();
        if (spriteA is Hero)
            heroSprite.Location = fireSprite.Location;
    }
}
