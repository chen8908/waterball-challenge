using MatchSystem.Elements;
using MatchSystem.Elements.MatchmakingStrategies;
using MatchSystem.Enums;

IEnumerable<Individual> individuals = [];

#region Individual Setting

var individual1 = new Individual()
{
    Gender = Gender.Male,
    Intro = "This is individual1's intro.",
    Coord = new Coord()
    {
        X = 23.1049968,
        Y = 119.7467914
    }
};
individual1.SetAge(19);
individual1.SetHabits(["旅遊", "烹飪", "露營"]);
individuals = individuals.Append(individual1);

var individual2 = new Individual()
{
    Gender = Gender.Female,
    Intro = "This is individual2's intro.",
    Coord = new Coord()
    {
        X = 23.1456968,
        Y = 104.7412354
    }
};
individual2.SetAge(30);
individual2.SetHabits(["烹飪", "美妝", "看電影"]);
individuals = individuals.Append(individual2);

var individual3 = new Individual()
{
    Gender = Gender.Male,
    Intro = "This is individual3's intro.",
    Coord = new Coord()
    {
        X = 22.1126758,
        Y = 110.1562754
    }
};
individual3.SetAge(25);
individual3.SetHabits(["攀岩", "露營", "旅遊", "慢跑"]);
individuals = individuals.Append(individual3);

var individual4 = new Individual()
{
    Gender = Gender.Female,
    Intro = "This is individual4's intro.",
    Coord = new Coord()
    {
        X = 20.1751268,
        Y = 120.4252354
    }
};
individual4.SetAge(50);
individual4.SetHabits(["飼養動物", "閱讀", "烹飪", "看電影"]);
individuals = individuals.Append(individual4);

#endregion

var matchmakingSystem = new MatchmakingSystem(new ReverseStrategy(new HabitSrategy()), individuals);
foreach(var individual in individuals)
    MatchAndShow(individual);

void MatchAndShow(Individual individual)
{
    var result = matchmakingSystem.Match(individual);
    if (result == null || !result.Any())
    {
        Console.WriteLine("抱歉了，未匹配到任何對象...");
        return;
    }
    var fitIndividual = result.First();
    Console.WriteLine("以下資訊是為您匹配到最合適的對象：");
    Console.WriteLine($"年齡：{fitIndividual.Age}");
    Console.WriteLine($"性別：{fitIndividual.Gender}");
    Console.WriteLine($"自我介紹：{fitIndividual.Intro}");
    Console.WriteLine($"興趣愛好：{fitIndividual.Habits}");
    Console.WriteLine($"座標位置：{fitIndividual.Coord.X}, {fitIndividual.Coord.Y}");
    Console.WriteLine(new string('=', 50));
}
