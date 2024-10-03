
namespace hw5;

internal class Calculator : ICalc
{
    public event EventHandler<EventArgs> GotResult;

    public int Result = 0;

    private Stack<int> Results = new Stack<int>();

    public void Sum(int value1, int value2)
    {
        Results.Push(Result);
        Result = value1 + value2;
        RaiseEvent();
    }

    public void Substruct(int value1, int value2)
    {
        Results.Push(Result);
        Result = value1 - value2;
        RaiseEvent();
    }

    public void Multiply(int value1, int value2)
    {
        Results.Push(Result);
        Result = value1 * value2;
        RaiseEvent();
    }

    public void Divide(int value1, int value2)
    {
        Results.Push(Result);
        Result = value1 / value2;
        RaiseEvent();
    }

    private void RaiseEvent()
    {
        GotResult?.Invoke(this, EventArgs.Empty);
    }

    public void CancelLast()
    {
        if (Results.Count > 0)
            {
            Result = Results.Pop();
            RaiseEvent();
            }
    }
}