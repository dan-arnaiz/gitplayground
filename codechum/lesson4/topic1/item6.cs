using System;

public class Program {
  public static int SumAtRange(int[] array, int size, int start, int end) {
    int sum = 0;
    // Adjusting for 1-based indexing
    start--;
    end--;
    for (int i = start; i <= end && i < size; i++) {
      sum += array[i];
    }
    return sum;
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

    Console.Write("Enter starting range: ");
    int start = Convert.ToInt32(Console.ReadLine());

    Console.Write("Enter end range: ");
    int end = Convert.ToInt32(Console.ReadLine());

    int sum = SumAtRange(array, size, start, end);
    Console.WriteLine($"Sum at range: {sum}");
  }
}