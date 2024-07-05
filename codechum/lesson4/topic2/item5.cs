using System;

public class Program
{
    public static float Average(int rows, int cols, float[,] array)
    {
        float sum = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                sum += array[i, j];
            }
        }
        return sum / (rows * cols);
    }

    public static void Main(string[] args)
    {
        Console.Write("Enter number of rows: ");
        int rows = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter number of columns: ");
        int cols = Convert.ToInt32(Console.ReadLine());

        float[,] array = new float[rows, cols];

        Console.WriteLine("Enter the elements of the array:");
        for (int i = 0; i < rows; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            for (int j = 0; j < cols; j++)
            {
                array[i, j] = float.Parse(inputs[j]);
            }
        }

        float average = Average(rows, cols, array);
        Console.WriteLine($"Average: {average:F2}");
    }
}