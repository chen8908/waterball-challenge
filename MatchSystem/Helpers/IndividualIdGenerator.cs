namespace MatchSystem.Helpers;

public static class IndividualIdGenerator
{
    private static int _nextId = 0;

    public static int GetNextId()
    {
        return Interlocked.Increment(ref _nextId);
    }
}
