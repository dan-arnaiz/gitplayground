
using System;

class Program {
  public static void PrintSum(int a, int b, int c) {
    Console.WriteLine(a + b + c);
  }

  static void Main(string[] args) {
    Console.Write("Enter first integer: ");
    int a = int.Parse(Console.ReadLine());
    Console.Write("Enter second integer: ");
    int b = int.Parse(Console.ReadLine());
    Console.Write("Enter third integer: ");
    int c = int.Parse(Console.ReadLine());

    PrintSum(a, b, c);
  }
}
