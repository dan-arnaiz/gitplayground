using System;

class Program {
  public static float Min(float a, float b, float c) {
    return Math.Min(a, Math.Min(b, c));
  }

  static void Main(string[] args) {
    Console.Write("Enter first value: ");
    float firstValue = float.Parse(Console.ReadLine());
    Console.Write("Enter second value: ");
    float secondValue = float.Parse(Console.ReadLine());
    Console.Write("Enter third value: ");
    float thirdValue = float.Parse(Console.ReadLine());

    float minValue = Min(firstValue, secondValue, thirdValue);
    Console.WriteLine($"Minimum Value: {minValue:F3}");
  }
}
