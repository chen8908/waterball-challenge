using word_cor.Abstraction;

namespace word_cor;

public class Word
{
    private readonly Collision _collision;
    public int[] Scope = [30];
    public IList<Sprite> Sprites { get; set; } = [];
    private const int HeroCount = 10;
    private const int WaterCount = 10;
    private const int FireCount = 10;

    public Word(Collision collision)
    {
        _collision = collision;

        for (int i = 0; i < HeroCount; i++)
            Sprites.Add(new Hero(this, Sprites.Count - 1));
        for (int i = 0; i < WaterCount; i++)
            Sprites.Add(new Water(this, Sprites.Count - 1)); 
        for (int i = 0; i < FireCount; i++)
            Sprites.Add(new Fire(this, Sprites.Count - 1));
    }

    public void Move(int from, int to)
    {
        var spriteA = GetSpriteByLocation(from);
        var spriteB = GetSpriteByLocation(to);

        if (spriteA is null)
            throw new Exception($"There are no any Sprite at location {from}");
        if (spriteB is null)
        {
            spriteA.Location = to;
            return;
        }
        _collision.Collide(spriteA, spriteB);
    }
    
    public void RemoveSprite(Sprite sprite)
    {
        Sprites.Remove(sprite);
    }

    private Sprite? GetSpriteByLocation(int locatoin)
    {
        return Sprites.FirstOrDefault(x => x.Location == locatoin);
    }
}
