using System;

public class Program {
  public static void PrintEven(int[] array, int size) {
    Console.Write("Even values: ");
    for (int i = 0; i < size; i++) {
      if (array[i] % 2 == 0) {
        Console.Write(array[i] + " ");
      }
    }
    Console.WriteLine();
  }

  public static void Main(string[] args) {
    Console.Write("Enter size of array: ");
    int size = Convert.ToInt32(Console.ReadLine());
    int[] array = new int[size];

    Console.Write("Enter array values: ");
    string[] inputs = Console.ReadLine().Split(' ');
    for (int i = 0; i < size; i++) {
      array[i] = Convert.ToInt32(inputs[i]);
    }

    PrintEven(array, size);
  }
}
