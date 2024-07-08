using System;

public class Program {
  public static int computeSum(int n) {
    if (n <= 1) // Base case
    {
      return n;
    } else // Recursive step
    {
      return n + computeSum(n - 1);
    }
  }

  public static void Main(string[] args) {
    Console.Write("Enter n: ");
    int n = Convert.ToInt32(Console.ReadLine());

    int sum = computeSum(n);
    Console.WriteLine("Sum = " + sum);
  }
}