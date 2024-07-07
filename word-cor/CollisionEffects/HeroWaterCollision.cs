using word_cor.Abstraction;

namespace word_cor;

public class HeroWaterCollision(CollisionEffect? nextHandler) : CollisionEffect(nextHandler)
{
    public override bool Match(Sprite spriteA, Sprite spriteB)
    {
        return (spriteA is Hero && spriteB is Water) || 
            (spriteA is Water && spriteB is Hero);
    }
    public override void DoHandling(Sprite spriteA, Sprite spriteB)
    {
        Hero heroSprite = (Hero)(spriteA is Hero ? spriteA : spriteB);
        var waterSprite = spriteA is Water ? spriteA : spriteB;

        heroSprite.HP += 10;
        if (heroSprite.IsDead())
            heroSprite.RemoveFormWord();
        waterSprite.RemoveFormWord();
        if (spriteA is Hero)
            heroSprite.Location = waterSprite.Location;
    }
}
