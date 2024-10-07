
namespace hw5;

internal class Calculator : ICalc
{
    public event EventHandler<EventArgs> GotResult;

    public int Result = 0;

    private Stack<int> results = new Stack<int>();

    private Stack<CalcActionLog> actions = new Stack<CalcActionLog>();

    public void Sum(int value1, int value2)
    {
        long temp;
        if(value1 > value2)
            temp = value1 + Result;
        else
            temp = value2 + Result;
        if (temp >= int.MaxValue)
        {
            actions.Push(new CalcActionLog(CalcAction.Substruct, value1, value2));
            throw new CalculateOperationCauseOverflowException("Overflow", actions);
        }
        results.Push(Result);
        Result = value1 + value2;
        RaiseEvent();
    }

    public void Substruct(int value1, int value2)
    {
        long temp;
        if(value1 < value2)
            temp = Result - value1;
        else
            temp = Result - value2;
        if (temp <= int.MinValue)
        {
            actions.Push(new CalcActionLog(CalcAction.Substruct, value1, value2));
            throw new CalculateOperationCauseOverflowException("Overflow", actions);
        }
        results.Push(Result);
        Result = value1 - value2;
        RaiseEvent();
    }

    public void Multiply(int value1, int value2)
    {
        long temp;
        if(value1 > value2)
            temp = value1 * Result;
        else
            temp = value2 * Result;
        if (temp >= int.MaxValue)
        {
            actions.Push(new CalcActionLog(CalcAction.Substruct, value1, value2));
            throw new CalculateOperationCauseOverflowException("Overflow", actions);
        }
        results.Push(Result);
        Result = value1 * value2;
        RaiseEvent();
    }

    public void Divide(int value1, int value2)
    {
        if (value2 == 0)    
        {
            actions.Push(new CalcActionLog(CalcAction.Substruct, value1, value2));
            throw new CalculatorDivideByZeroException("Divide by zero", actions);
        }
        results.Push(Result);
        Result = value1 / value2;
        RaiseEvent();
    }

    private void RaiseEvent()
    {
        GotResult?.Invoke(this, EventArgs.Empty);
    }

    public void CancelLast()
    {
        if (results.Count > 0)
            {
            Result = results.Pop();
            RaiseEvent();
            }
    }
}