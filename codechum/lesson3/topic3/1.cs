using System;

class Program {
  static void Main(string[] args) {
    int result = MultiplyThreeNumbers(23, 5, 10);
    Console.WriteLine(result);
  }

  static int MultiplyThreeNumbers(int a, int b, int c) { return a * b * c; }
}