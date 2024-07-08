using System;

class Program {
  public static int Max(int a, int b, int c) {
    return Math.Max(a, Math.Max(b, c));
  }

  static void Main(string[] args) {
    Console.Write("Enter first number: ");
    int firstNumber = int.Parse(Console.ReadLine());
    Console.Write("Enter second number: ");
    int secondNumber = int.Parse(Console.ReadLine());
    Console.Write("Enter third number: ");
    int thirdNumber = int.Parse(Console.ReadLine());

    int maxValue = Max(firstNumber, secondNumber, thirdNumber);
    Console.WriteLine("Maximum Value: " + maxValue);
  }
}
