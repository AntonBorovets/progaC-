
using System;

//1:
public delegate double CalcDelegate(double num1, double num2, char operation);

//2:
public class CalcProgram
{
    //2.1:
    public static double Calc(double num1, double num2, char operation)
    {
        switch (operation)
        {
            case '+':
                return num1 + num2;
            case '-':
                return num1 - num2;
            case '*':
                return num1 * num2;
            case '/':
                
                if (num2 != 0)
                    return num1 / num2;
                else
                    return 0;
            default:
                throw new ArgumentException("Invalid operation");
        }
    }
    //2.2:
    public CalcDelegate funcCalc;

    public CalcProgram()
    {
        funcCalc = new CalcDelegate(Calc);
    }
}

class Program
{
    static void Main(string[] args)
    {
        CalcProgram calculator = new CalcProgram();

        double result1 = calculator.funcCalc(10, 5, '+'); //  = 15
        double result2 = calculator.funcCalc(20, 4, '/'); //  = 5
        double result3 = calculator.funcCalc(8, 3, '*');  //  = 24
        double result4 = calculator.funcCalc(15, 7, '-'); //  = 8

        Console.WriteLine($"Result of 10 + 5 = {result1}");
        Console.WriteLine($"Result of 20 / 4 = {result2}");
        Console.WriteLine($"Result of 8 * 3 = {result3}");
        Console.WriteLine($"Result of 15 - 7 = {result4}");

        CalcProgram calculator2 = new CalcProgram();

        Console.WriteLine("Enter first number:");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter second number:");
        double num2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter operation (+, -, *, /):");
        char operation = Convert.ToChar(Console.ReadLine());

        double result = calculator2.funcCalc(num1, num2, operation);

        Console.WriteLine($"Result of {num1} {operation} {num2} = {result}");
    }
}
