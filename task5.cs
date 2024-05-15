using System;
using System.Threading.Tasks;

public class ParallelUtils<T, TR>
{
    private Func<T, T, TR> _operation;
    private T _operand1;
    private T _operand2;

    public ParallelUtils(Func<T, T, TR> operation, T operand1, T operand2)
    {
        _operation = operation;
        _operand1 = operand1;
        _operand2 = operand2;
    }

    public TR Result { get; private set; }

    public void SetOperands(T operand1, T operand2)
    {
        _operand1 = operand1;
        _operand2 = operand2;
    }

    private async Task EvaluateAsync()
    {
        Result = await Task.Run(() => _operation(_operand1, _operand2));
    }

    public void Evaluate()
    {
        EvaluateAsync().GetAwaiter().GetResult();
    }
}

public static class Operations
{
    public static int Add(int x, int y) => x + y;
    public static int Subtract(int x, int y) => x - y;
    public static int Multiply(int x, int y) => x * y;
    public static double Divide(double x, double y)
    {
        if (y == 0)
            throw new DivideByZeroException("Ділення на нуль неможливе.");
        return x / y;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var addUtils = new ParallelUtils<int, int>(Operations.Add, 2, 3);
        var subtractUtils = new ParallelUtils<int, int>(Operations.Subtract, 9, 9);
        var multiplyUtils = new ParallelUtils<int, int>(Operations.Multiply, 7, 7);
        var divideUtils = new ParallelUtils<double, double>(Operations.Divide, 10.0, 1);

        addUtils.Evaluate();
        subtractUtils.Evaluate();
        multiplyUtils.Evaluate();
        divideUtils.Evaluate();

        Console.WriteLine("Результат додавання: " + addUtils.Result);
        Console.WriteLine("Результат вiднiмання: " + subtractUtils.Result);
        Console.WriteLine("Результат множення: " + multiplyUtils.Result);
        Console.WriteLine("Результат дiлення: " + divideUtils.Result);
    }
}
