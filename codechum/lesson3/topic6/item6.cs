using System;

public class Program {
  public static void printCodeChum(int n) {
    if (n <= 0) // Base case to stop recursion
    {
      return;
    }
    Console.WriteLine("CodeChum"); // Print "CodeChum"
    printCodeChum(n - 1);          // Recursive call with n decremented by 1
  }

  public static void Main(string[] args) {
    Console.Write("Enter n: ");
    int n = Convert.ToInt32(Console.ReadLine());

    printCodeChum(n);
  }
}