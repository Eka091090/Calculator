namespace hw5;

internal class CalcActionLog
{
    public CalcAction CalcAction { get; private set; }
    public int CalcArgument1 { get; private set; }

    public int CalcArgument2 { get; private set; }

    public CalcActionLog(CalcAction calcAction, int calcArgument1, int calcArgument2)
    {
        CalcAction = calcAction;
        CalcArgument1 = calcArgument1;

        CalcArgument2 = calcArgument2;
    }
}