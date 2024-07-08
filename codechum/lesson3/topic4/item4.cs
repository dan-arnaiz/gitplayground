using System;

class Program {
  public static void PrintProduct(int a, int b) {
    Console.WriteLine("Product = " + (a * b));
  }

  static void Main(string[] args) {
    Console.Write("Enter x: ");
    int x = int.Parse(Console.ReadLine());
    Console.Write("Enter y: ");
    int y = int.Parse(Console.ReadLine());

    PrintProduct(x, y);
  }
}