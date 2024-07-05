using System;

public class Program
{
    // Recursive function to find the nth Fibonacci number
    public static int fib(int n)
    {
        if (n <= 0)
        {
            return 0; // Base case for 0
        }
        else if (n == 1)
        {
            return 1; // Base case for 1
        }
        else
        {
            return fib(n - 1) + fib(n - 2); // Recursive case
        }
    }

    public static void Main(string[] args)
    {
        int n;
        Console.Write("Enter which nth term: ");
        n = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Nth term = " + fib(n));
    }
}