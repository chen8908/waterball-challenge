using MatchSystem.Abstractions;

namespace MatchSystem.Elements;

public class MatchmakingSystem(IMatchmakingStrategy strategy, IEnumerable<Individual> individuals)
{
    private readonly IMatchmakingStrategy _matchmakingStrategy = strategy;
    private readonly IEnumerable<Individual> _individuals = individuals;

    public IEnumerable<Individual> Match(Individual individual)
    {
        return _matchmakingStrategy.SortIndividuals(_individuals, individual);
    }
}
