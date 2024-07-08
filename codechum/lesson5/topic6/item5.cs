public class Performer
{
    private string name;
    private int age;

    public Performer(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public string GetName() => name;
    public int GetAge() => age;
}

public class Singer : Performer
{
    private string vocalRange;

    public Singer(string name, int age, string vocalRange) : base(name, age)
    {
        this.vocalRange = vocalRange;
    }

    public string GetVocalRange() => vocalRange;

    public void Sing()
    {
        Console.WriteLine($"{GetName()} is singing with a {vocalRange} range.");
    }
}

public class Dancer : Performer
{
    private string danceStyle;

    public Dancer(string name, int age, string danceStyle) : base(name, age)
    {
        this.danceStyle = danceStyle;
    }

    public string GetDanceStyle() => danceStyle;

    public void Dance()
    {
        Console.WriteLine($"{GetName()} is performing {danceStyle} dance.");
    }
}