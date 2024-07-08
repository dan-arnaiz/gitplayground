using System;

public class Program {
  public static void printRecursively(int n) {
    if (n <= 0) {
      return;
    }
    Console.Write(n);
    if (n > 1) {
      Console.Write(", ");
    }
    printRecursively(n - 1);
  }

  public static void Main(string[] args) {
    int n;

    Console.Write("Enter n: ");
    n = Convert.ToInt32(Console.ReadLine());

    printRecursively(n);
  }
}