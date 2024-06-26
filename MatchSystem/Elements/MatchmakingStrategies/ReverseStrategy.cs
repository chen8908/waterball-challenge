using MatchSystem.Abstractions;

namespace MatchSystem.Elements.MatchmakingStrategies;

public class ReverseStrategy(IMatchmakingStrategy matchmakingStrategy) : IMatchmakingStrategy
{
    private readonly IMatchmakingStrategy _matchmakingStrategy = matchmakingStrategy;

    public IEnumerable<Individual> SortIndividuals(IEnumerable<Individual> individuals, Individual individual)
    {
        return _matchmakingStrategy.SortIndividuals(individuals, individual).Reverse();
    }
}
