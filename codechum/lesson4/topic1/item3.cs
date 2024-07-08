using System;

public class Program {
  public static float SumGreaterThan(float[] array, int size, float x) {
    float sum = 0;
    for (int i = 0; i < size; i++) {
      if (array[i] > x) {
        sum += array[i];
      }
    }
    return sum;
  }

  public static void Main(string[] args) {
    Console.Write("Enter array size: ");
    int size = Convert.ToInt32(Console.ReadLine());
    float[] array = new float[size];

    Console.Write("Enter array values: ");
    string[] inputs = Console.ReadLine().Split(' ');
    for (int i = 0; i < size; i++) {
      array[i] = float.Parse(inputs[i]);
    }

    Console.Write("Enter x value: ");
    float x = float.Parse(Console.ReadLine());

    float sum = SumGreaterThan(array, size, x);
    Console.WriteLine($"Sum of values greater than {x:0.00}: {sum:0.00}");
  }
}