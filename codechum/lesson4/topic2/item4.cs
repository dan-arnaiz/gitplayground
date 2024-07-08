using System;

public class Program {
  public static void PrintEven(int rows, int cols, int[,] array) {
    Console.WriteLine("Even Values:"); // Moved to a new line
    bool isFirst = true;
    for (int i = 0; i < rows; i++) {
      for (int j = 0; j < cols; j++) {
        if (array[i, j] % 2 == 0) {
          if (!isFirst) {
            Console.Write(", ");
          }
          Console.Write(array[i, j]);
          isFirst = false;
        }
      }
    }
    Console.WriteLine();
  }

  public static void Main(string[] args) {
    Console.Write("Enter number of rows: ");
    int rows = Convert.ToInt32(Console.ReadLine());

    Console.Write("Enter number of columns: ");
    int cols = Convert.ToInt32(Console.ReadLine());

    int[,] array = new int[rows, cols];

    Console.WriteLine("Enter the elements of the array:");
    for (int i = 0; i < rows; i++) {
      string[] inputs = Console.ReadLine().Split(' ');
      for (int j = 0; j < cols; j++) {
        array[i, j] = Convert.ToInt32(inputs[j]);
      }
    }

    PrintEven(rows, cols, array);
  }
}