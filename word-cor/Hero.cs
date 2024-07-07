using word_cor.Abstraction;

namespace word_cor;

public class Hero(Word word, int location) : Sprite(word, location, "H")
{
    public int HP { get; set; } = 30;
    public bool IsDead()
    {
        return HP <= 0;
    }
}
