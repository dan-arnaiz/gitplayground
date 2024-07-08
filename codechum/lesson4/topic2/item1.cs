using System;

public class Program {
  public static void Print2DArray(int[,] array, int rows, int cols) {
    Console.WriteLine("Array Values:");
    for (int i = 0; i < rows; i++) {
      for (int j = 0; j < cols; j++) {
        Console.Write(array[i, j] + " ");
      }
      Console.WriteLine();
    }
  }

  public static void Main(string[] args) {
    Console.Write("Enter number of rows: ");
    int rows = Convert.ToInt32(Console.ReadLine());

    Console.Write("Enter number of columns: ");
    int cols = Convert.ToInt32(Console.ReadLine());

    int[,] array = new int[rows, cols];

    for (int i = 0; i < rows; i++) {
      string[] inputs = Console.ReadLine().Split(' ');
      for (int j = 0; j < cols; j++) {
        array[i, j] = Convert.ToInt32(inputs[j]);
      }
    }

    Print2DArray(array, rows, cols);
  }
}