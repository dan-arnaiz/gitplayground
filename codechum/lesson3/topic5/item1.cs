using System;

class Program {
  public static int GetSum(int num1, int num2) { return num1 + num2; }

  static void Main(string[] args) {
    Console.Write("Enter first number: ");
    int firstNumber = int.Parse(Console.ReadLine());
    Console.Write("Enter second number: ");
    int secondNumber = int.Parse(Console.ReadLine());

    int sum = GetSum(firstNumber, secondNumber);
    Console.WriteLine("Sum = " + sum);
  }
}
