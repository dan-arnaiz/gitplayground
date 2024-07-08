using System;

class Program {
  public static int Factorial(int n) {
    if (n <= 1)
      return 1;
    else
      return n * Factorial(n - 1);
  }

  static void Main(string[] args) {
    Console.Write("Enter a number: ");
    int number = int.Parse(Console.ReadLine());

    int result = Factorial(number);
    Console.WriteLine($"Factorial of {number}: {result}");
  }
}
