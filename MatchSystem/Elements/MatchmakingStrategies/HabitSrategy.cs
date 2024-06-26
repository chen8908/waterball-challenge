using MatchSystem.Abstractions;

namespace MatchSystem.Elements.MatchmakingStrategies;

public class HabitSrategy : IMatchmakingStrategy
{
    public IEnumerable<Individual> SortIndividuals(IEnumerable<Individual> individuals, Individual individual)
    {
        var habitIntersectionDict = new Dictionary<Individual, int>();
        var othersIndividual = individuals.Where(x => x != individual);
        var myHabits = individual.Habits.Split(',');
        foreach (var item in othersIndividual)
        {
            var habits = item.Habits.Split(',');
            var intersection = 
                    from mh in myHabits
                    join h in habits on mh equals h
                    select mh;
            var count = intersection?.Count() ?? default;
            habitIntersectionDict.Add(item, count);
        }

        return habitIntersectionDict.OrderByDescending(x => x.Value).ThenBy(x => x.Key.Id).Select(x => x.Key);
    }
}
