using System;

class Program {
  public static void Max(double num1, double num2) {
    double higherValue = num1 > num2 ? num1 : num2;
    Console.WriteLine($"{higherValue:F2}");
  }

  static void Main(string[] args) {
    Console.Write("Enter first decimal number: ");
    double firstNumber = double.Parse(Console.ReadLine());
    Console.Write("Enter second decimal number: ");
    double secondNumber = double.Parse(Console.ReadLine());

    Max(firstNumber, secondNumber);
  }
}
