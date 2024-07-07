namespace word_cor.Abstraction;

public abstract class Sprite(Word word, int location, string name)
{
    public Word Word { get; } = word;
    public int Location { get; set; } = location;
    public string Name { get; } = name;
    public virtual void RemoveFormWord()
    {
        Word.RemoveSprite(this);
    }
}
