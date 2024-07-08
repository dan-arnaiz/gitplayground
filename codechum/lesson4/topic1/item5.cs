using System;

public class Program
{
    public static void PrintOdd(int[] array1, int[] array2, int size1, int size2)
    {
        bool firstOddPrinted = false;
        for (int i = 0; i < size1; i++)
        {
            if (array1[i] % 2 != 0)
            {
                if (firstOddPrinted)
                {
                    Console.Write(", ");
                }
                Console.Write(array1[i]);
                firstOddPrinted = true;
            }
        }

        for (int j = 0; j < size2; j++)
        {
            if (array2[j] % 2 != 0)
            {
                if (firstOddPrinted)
                {
                    Console.Write(", ");
                }
                Console.Write(array2[j]);
                firstOddPrinted = true;
            }
        }
    }

    public static void Main(string[] args)
    {
        Console.Write("Enter first array size: ");
        int size1 = Convert.ToInt32(Console.ReadLine());
        int[] array1 = new int[size1];

        Console.Write("Enter second array size: ");
        int size2 = Convert.ToInt32(Console.ReadLine());
        int[] array2 = new int[size2];

        Console.Write("Enter first array values: ");
        string[] inputs1 = Console.ReadLine().Split(' ');
        for (int i = 0; i < size1; i++)
        {
            array1[i] = Convert.ToInt32(inputs1[i]);
        }

        Console.Write("Enter second array values: ");
        string[] inputs2 = Console.ReadLine().Split(' ');
        for (int j = 0; j < size2; j++)
        {
            array2[j] = Convert.ToInt32(inputs2[j]);
        }

        PrintOdd(array1, array2, size1, size2);
    }
}