
using System;

class Program {
  public static void PrintFlippedNumber(int number) {
    string numberStr = number.ToString();
    for (int i = numberStr.Length - 1; i >= 0; i--) {
      Console.Write(numberStr[i]);
    }
    Console.WriteLine();
  }

  static void Main(string[] args) {
    Console.Write("Enter an integer: ");
    int inputNumber = int.Parse(Console.ReadLine());
    PrintFlippedNumber(inputNumber);
  }
}