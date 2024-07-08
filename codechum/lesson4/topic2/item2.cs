using System;

public class Program {
  public static int Max(int[,] array, int rows, int cols) {
    int max = array[0, 0];
    for (int i = 0; i < rows; i++) {
      for (int j = 0; j < cols; j++) {
        if (array[i, j] > max) {
          max = array[i, j];
        }
      }
    }
    return max;
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

    Console.WriteLine($"Maximum Value: {Max(array, rows, cols)}");
  }
}
