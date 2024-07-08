using System;

class Program {
  public static double Average(int[] numbers) {
    double sum = 0;
    foreach (int number in numbers) {
      sum += number;
    }
    return sum / numbers.Length;
  }

  static void Main(string[] args) {
    Console.Write("Enter size of array: ");
    int size = int.Parse(Console.ReadLine());
    int[] numbers = new int[size];

    Console.Write("Enter the numbers: ");
    string[] inputs = Console.ReadLine().Split(' ');
    for (int i = 0; i < size; i++) {
      numbers[i] = int.Parse(inputs[i]);
    }

    double average = Average(numbers);
    Console.WriteLine($"Average: {average:F2}");
  }
}