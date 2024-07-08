using System;

public class Program {
  public static int SumAtRange(int rows, int cols, float[,] array, int start,
                               int end) {
    // Ensure start and end are within the bounds of the array
    if (start < 0)
      start = 0;
    int maxIndex = rows * cols - 1;
    if (end > maxIndex)
      end = maxIndex;

    int sum = 0;
    int currentIndex = 0;

    for (int i = 0; i < rows; i++) {
      for (int j = 0; j < cols; j++) {
        if (currentIndex >= start && currentIndex <= end) {
          sum += (int)Math.Floor(array[i, j]);
        }
        currentIndex++;
      }
    }

    return sum;
  }

  public static void Main(string[] args) {
    Console.Write("Enter number of rows: ");
    int rows = Convert.ToInt32(Console.ReadLine());

    Console.Write("Enter number of columns: ");
    int cols = Convert.ToInt32(Console.ReadLine());

    float[,] array = new float[rows, cols];

    Console.WriteLine("Enter the elements of the array:");
    for (int i = 0; i < rows; i++) {
      string[] inputs = Console.ReadLine().Split(' ');
      for (int j = 0; j < cols; j++) {
        array[i, j] = float.Parse(inputs[j]);
      }
    }

    Console.Write("Enter start index: ");
    int start = Convert.ToInt32(Console.ReadLine());

    Console.Write("Enter end index: ");
    int end = Convert.ToInt32(Console.ReadLine());

    int result = SumAtRange(rows, cols, array, start, end);

    Console.WriteLine($"Sum: {result}");
  }
}