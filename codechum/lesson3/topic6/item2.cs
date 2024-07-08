using System;

public class Program {
  public static void printRecursively(int current, int n) {
    if (current <= n) {
      Console.Write(current + " ");
      printRecursively(current + 1, n); // Corrected to increment current
    }
  }

  public static void Main(string[] args) {
    int n;

    Console.Write("Enter n: ");
    n = Convert.ToInt32(Console.ReadLine());

    printRecursively(1, n);
  }
}
