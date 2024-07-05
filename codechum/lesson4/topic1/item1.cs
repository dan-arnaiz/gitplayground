using System;

public class Program
{
    public static void PrintArrayValues(int[] array, int size)
    {
        for (int i = 0; i < size; i++)
        {
            Console.Write(array[i]);
            if (i < size - 1)
            {
                Console.Write(", ");
            }
        }
    }

    public static void Main(string[] args)
    {
        Console.Write("Enter size of array: ");
        int size = Convert.ToInt32(Console.ReadLine());
        int[] array = new int[size];

        Console.WriteLine("Enter array values:");
        for (int i = 0; i < size; i++)
        {
            array[i] = Convert.ToInt32(Console.ReadLine());
        }

        PrintArrayValues(array, size);
    }
}