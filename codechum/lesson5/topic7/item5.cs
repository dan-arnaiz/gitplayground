public abstract class Animal
{
    private string name;

    public Animal(string name)
    {
        this.name = name;
    }

    public string GetName()
    {
        return name;
    }

    public abstract void MakeSound();
}

public class Dog : Animal
{
    public Dog(string name) : base(name) { }

    public override void MakeSound()
    {
        Console.WriteLine("Woof! My name is " + GetName());
    }
}