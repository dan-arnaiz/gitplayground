using System;

class Program {
  public static string CombineChars(char a, char b) { return $"{a}{b}"; }

  static void Main(string[] args) {
    Console.Write("Enter first character: ");
    char firstChar = Console.ReadLine()[0];
    Console.Write("Enter second character: ");
    char secondChar = Console.ReadLine()[0];

    string combined = CombineChars(firstChar, secondChar);
    Console.WriteLine(combined);
  }
}