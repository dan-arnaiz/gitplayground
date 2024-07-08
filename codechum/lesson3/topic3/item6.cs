
using System;

class Program {
  public static int[] GetIntegers() {
    int[] integers = new int[3];
    Console.Write("Enter first integer: ");
    integers[0] = int.Parse(Console.ReadLine());
    Console.Write("Enter second integer: ");
    integers[1] = int.Parse(Console.ReadLine());
    Console.Write("Enter third integer: ");
    integers[2] = int.Parse(Console.ReadLine());
    return integers;
  }

  static void Main(string[] args) {
    int[] numbers = GetIntegers();
    Console.WriteLine(string.Join(", ", numbers));
  }
}