using System;

class Program {
  public static void PrintAge(int age) {
    Console.WriteLine("Your age is " + age);
  }

  static void Main(string[] args) {
    Console.Write("Enter your age: ");
    int age = int.Parse(Console.ReadLine());
    PrintAge(age);
  }
}