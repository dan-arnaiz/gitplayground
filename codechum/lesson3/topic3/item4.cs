using System;

class Program {
  public static float ComputeSumOfNumbers() {
    Console.Write("Enter first number: ");
    float firstNumber = float.Parse(Console.ReadLine());
    Console.Write("Enter second number: ");
    float secondNumber = float.Parse(Console.ReadLine());
    Console.Write("Enter third number: ");
    float thirdNumber = float.Parse(Console.ReadLine());

    return firstNumber + secondNumber + thirdNumber;
  }

  static void Main(string[] args) {
    float sum = ComputeSumOfNumbers();
    Console.WriteLine(Math.Round(sum, 2));
  }
}
