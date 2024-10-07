using System.Security.Cryptography.X509Certificates;

namespace hw5;

internal class CalculatorException : Exception
{
    public CalculatorException(string v, Stack<CalcActionLog> actionLogs) : base (v)
    {
        ActionLogs = actionLogs;
    }

    public CalculatorException(string v, Exception e) : base (v, e)
    {

    }

    public override string ToString()
    {
        return Message + ":" + string.Join ("\n", ActionLogs.Select(x => $"{x.CalcAction} {x.CalcArgument}"));
    }

    public Stack<CalcActionLog> ActionLogs { get; private set; }

}

internal class CalculatorDivideByZeroException : CalculatorException
{


    public CalculatorDivideByZeroException(string v, Stack<CalcActionLog> actionLogs) : base (v, actionLogs)
    {

    }

    public CalculatorDivideByZeroException(string v, Exception e) : base (v, e)
    {

    }
}

internal class CalculateOperationCauseOverflowException : CalculatorException
{
    public CalculateOperationCauseOverflowException(string v, Stack<CalcActionLog> actionLogs) : base (v, actionLogs)
    {

    }

    public CalculateOperationCauseOverflowException(string v, Exception e) : base (v, e)
    {

    }
    
}

