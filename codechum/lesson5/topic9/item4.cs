using System;
using System.Collections.Generic;

public abstract class Bird
{
    public abstract void MakeSound();
}

public class Sparrow : Bird
{
    public override void MakeSound()
    {
        Console.WriteLine("Chirp Chirp");
    }
}

public class Parrot : Bird
{
    public override void MakeSound()
    {
        Console.WriteLine("Tweet Tweet");
    }
}

public class BirdCage
{
    public void MakeBirdSounds(List<Bird> birds)
    {
        foreach (Bird bird in birds)
        {
            bird.MakeSound();
        }
    }
}