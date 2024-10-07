using System.Linq.Expressions;

namespace hw5;

class Program
{
    private static void Calculator_GotResult(object sendler, EventArgs eventArgs)
    {
        System.Console.WriteLine($"Result = {((Calculator)sendler).Result}");
    }

    static void Execute (Action<int> action)
    {
        try
        {
            action.Invoke(5);
        }
        catch (CalculatorDivideByZeroException ex)
        {
            System.Console.WriteLine(ex);
        }
        catch (CalculateOperationCauseOverflowException ex)
        {
            System.Console.WriteLine(ex);
        }
    }

    static void Main()
    {
        ICalc calc = new Calculator();

        calc.GotResult += Calculator_GotResult;

        ConsoleKeyInfo action = new ConsoleKeyInfo();

        do
        {
            Console.Clear();

            int value1, value2;

            try
            {
                Console.Write("Enter first number: ");
                value1 = int.Parse(Console.ReadLine());

                Console.Write("Enter second number: ");  
                value2 = int.Parse(Console.ReadLine());
            }
            catch(Exception)
            {
                System.Console.WriteLine("In not number");
                Console.ReadLine();
                continue;
            }

            Console.WriteLine($"Enter action: +, -, *, / or 'esc'");

            action = Console.ReadKey(true);

            if (action.Key.GetHashCode() == 187 || action.Key.GetHashCode() == 189 || action.Key.GetHashCode() == 56 || action.Key.GetHashCode() == 191 || action.Key.GetHashCode() == 27)
            {
                switch(action.Key.GetHashCode())
                {
                    case 187:
                    calc.Sum(value1, value2);
                        break;
                    case 189:
                        calc.Substruct(value1, value2);
                        break;
                    case 56:
                        calc.Multiply(value1, value2);
                        break;
                    case 191:
                        calc.Divide(value1, value2);
                        break;
                    case 27:
                        Console.WriteLine("Esc");
                        break;
                }
            }
            else 
                Console.WriteLine("Incorrect action!");
            Console.ReadLine();
        } while (action.Key != ConsoleKey.Escape);     
    }
}