using MatchSystem.Abstractions;

namespace MatchSystem.Elements.MatchmakingStrategies;

public class DistanceStrategy : IMatchmakingStrategy
{
    public IEnumerable<Individual> SortIndividuals(IEnumerable<Individual> individuals, Individual individual)
    {
        var distanceDict = new Dictionary<Individual, double>();
        var othersIndividual = individuals.Where(x => x != individual);
        foreach(var item in othersIndividual)
        {
            double deltaX = item.Coord.X - individual.Coord.X;
            double deltaY = item.Coord.Y - individual.Coord.Y;
            double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
            distanceDict.Add(item, distance);
        }

        return distanceDict.OrderByDescending(x => x.Value).Select(x => x.Key);
    }
}
