using System;
using System.Collections.Generic;

public abstract class Pet
{
    private string type;
    private bool isFriendly;

    protected Pet(string type, bool isFriendly)
    {
        this.type = type;
        this.isFriendly = isFriendly;
    }

    public abstract void MakeNoise();

    public override string ToString()
    {
        return $"Pet {type} is {(isFriendly ? "friendly" : "not friendly")}.";
    }
}

public class Cat : Pet
{
    public Cat() : base("cat", true) { }

    public override void MakeNoise()
    {
        Console.WriteLine("Meow!");
    }
}

public class Lion : Pet
{
    public Lion() : base("lion", false) { }

    public override void MakeNoise()
    {
        Console.WriteLine("Roar!");
    }
}

public class Dog : Pet
{
    private string breed;

    public Dog(string breed) : base("dog", true)
    {
        this.breed = breed;
    }

    public override void MakeNoise()
    {
        Console.WriteLine("Arf!");
    }

    public override string ToString()
    {
        return base.ToString() + $" Breed: {breed}.";
    }
}

public class PetHouse
{
    public void MakeNoise(List<Pet> pets)
    {
        foreach (Pet pet in pets)
        {
            pet.MakeNoise();
        }
    }
}