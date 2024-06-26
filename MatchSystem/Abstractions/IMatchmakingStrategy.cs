using MatchSystem.Elements;

namespace MatchSystem.Abstractions;

public interface IMatchmakingStrategy
{
    IEnumerable<Individual> SortIndividuals(IEnumerable<Individual> individuals, Individual individual);
}
