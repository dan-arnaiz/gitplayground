using System;

class Program {
  public static void PrintCharacterAndLowercase(char character) {
    Console.WriteLine($"{character}{char.ToLower(character)}");
  }

  static void Main(string[] args) {
    Console.Write("Enter a character: ");
    char character = Console.ReadLine()[0];
    PrintCharacterAndLowercase(character);
  }
}
