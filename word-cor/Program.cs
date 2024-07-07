using word_cor;

var collision = new Collision(new WaterFireCollision(new HeroFireCollision(new HeroWaterCollision(new SameSpriteCollision(null)))));
var word = new Word(collision);

while(true)
{
    var input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input))
        continue;
    else if (input == "q")
        break;
    var locations = input.Split(' ');
    if (locations == null || locations.Length < 2)
        continue;

    if (int.TryParse(locations[0], out int from) &&
     int.TryParse(locations[1], out int to))
    {
        word.Move(from, to);
    }
}