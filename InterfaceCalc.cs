namespace hw5;

internal interface ICalc
{
    event EventHandler<EventArgs> GotResult;

    void Sum(int value1, int value2);

    void Substruct(int value1, int value2);

    void Multiply(int value1, int value2);

    void Divide(int value1, int value2); 

    void CancelLast();

}