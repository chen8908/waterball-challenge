using word_cor.Abstraction;

namespace word_cor;

public class Collision(CollisionEffect collisionEffect)
{
    private readonly CollisionEffect _collisionEffect = collisionEffect;
    public void Collide(Sprite spriteA, Sprite spriteB)
    {
        _collisionEffect.Handle(spriteA, spriteB);
    }
}
