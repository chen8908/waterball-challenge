namespace Big2;

public abstract class CardPatternCompare(CardPatternCompare? nextCompare)
{
    private static CompareResult _compareResult = CompareResult.None;
    public static CompareResult Result { get { return GetCompareResult(); } }
    public CardPatternCompare? Next { get; } = nextCompare;
    public abstract bool CanCompare(CardPattern cardPatternA, CardPattern cardPatternB);
    public void Compare(CardPattern cardPatternA, CardPattern cardPatternB)
    {
        if (CanCompare(cardPatternA, cardPatternB))
        {
            DoHandling(cardPatternA, cardPatternB);
            return;
        }
        else
            Next?.Compare(cardPatternA, cardPatternB);
    }
    public abstract void DoHandling(CardPattern cardPatternA, CardPattern cardPatternB);

    protected static void SetResult(int resultIndex)
    {
        if (resultIndex == 0)
            _compareResult = CompareResult.Equals;
        else if (resultIndex > 0)
            _compareResult = CompareResult.Bigger;
        else if (resultIndex < 0)
            _compareResult = CompareResult.Smaller;
    }

    private static CompareResult GetCompareResult()
    {
        return _compareResult;
    }
}
