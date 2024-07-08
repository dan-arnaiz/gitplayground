using System;

class Program
{
    public static int Return10()
    {
        return 10;
    }

    static void Main(string[] args)
    {
        int total = 0;
        total += Return10();
        total += Return10();
        total += Return10();
        Console.WriteLine("Total: " + total);
    }
}