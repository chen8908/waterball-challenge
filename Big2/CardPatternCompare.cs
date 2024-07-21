namespace Big2;

public abstract class CardPatternCompare(CardPatternCompare? nextCompare)
{
    public CompareResult Result { get; protected set; } = CompareResult.None;
    public CardPatternCompare? Next { get; } = nextCompare;
    public abstract bool CanCompare(CardPattern cardPatternA, CardPattern cardPatternB);
    public void Compare(CardPattern cardPatternA, CardPattern cardPatternB)
    {
        if (CanCompare(cardPatternA, cardPatternB))
            DoHandling(cardPatternA, cardPatternB);
        else
            Next?.Compare(cardPatternA, cardPatternB);
    }
    public abstract void DoHandling(CardPattern cardPatternA, CardPattern cardPatternB);

    protected void SetResult(int resultIndex)
    {
        if (resultIndex == 0)
            Result = CompareResult.Equals;
        else if (resultIndex > 0)
            Result = CompareResult.Bigger;
        else if (resultIndex < 0)
            Result = CompareResult.Smaller;
    }
}
