using System;

class Program
{
    public static int IsDivisibleBy(int first, int second)
    {
        return first % second == 0 ? 1 : 0;
    }

    static void Main(string[] args)
    {
        Console.Write("Enter first number: ");
        int firstNumber = int.Parse(Console.ReadLine());
        Console.Write("Enter second number: ");
        int secondNumber = int.Parse(Console.ReadLine());

        int result = IsDivisibleBy(firstNumber, secondNumber);
        Console.WriteLine(result == 1 ? "yes" : "no");
    }
}