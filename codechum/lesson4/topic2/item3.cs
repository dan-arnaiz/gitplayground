using System;

public class Program
{
    public static int Exists(int[,] array, int rows, int cols, int x)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (array[i, j] == x)
                {
                    return 1;
                }
            }
        }
        return 0;
    }

    public static void Main(string[] args)
    {
        Console.Write("Enter number of rows: ");
        int rows = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter number of columns: ");
        int cols = Convert.ToInt32(Console.ReadLine());

        int[,] array = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            for (int j = 0; j < cols; j++)
            {
                array[i, j] = Convert.ToInt32(inputs[j]);
            }
        }

        Console.Write("Enter value to find: ");
        int x = Convert.ToInt32(Console.ReadLine());

        int result = Exists(array, rows, cols, x);

        if (result == 1)
        {
            Console.WriteLine("yes");
        }
        else
        {
            Console.WriteLine("no");
        }
    }
}