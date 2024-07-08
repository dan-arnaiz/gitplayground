using System;

public class Program {
  public static int MinValue(int[] array, int size) {
    if (size == 0)
      return int.MaxValue; // Return max value if array is empty

    int min = array[0];
    for (int i = 1; i < size; i++) {
      if (array[i] < min) {
        min = array[i];
      }
    }
    return min;
  }

  public static void Main(string[] args) {
    Console.Write("Enter size of array: ");
    int size = Convert.ToInt32(Console.ReadLine());
    int[] array = new int[size];

    Console.Write("Enter array values: "); // Changed from WriteLine to Write
    string[] inputs = Console.ReadLine().Split(' ');
    for (int i = 0; i < size; i++) {
      array[i] = Convert.ToInt32(inputs[i]);
    }

    int minValue = MinValue(array, size);
    Console.WriteLine("Minimum Value in the Array: " + minValue);
  }
}
