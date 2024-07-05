public class Person
{
    private string name;
    private int age;
    private char gender;

    public Person() { }

    public Person(string name, int age, char gender)
    {
        this.name = name;
        this.age = age;
        this.gender = gender;
    }

    public string GetName() => name;
    public void SetName(string name) => this.name = name;

    public int GetAge() => age;
    public void SetAge(int age) => this.age = age;

    public char GetGender() => gender;
    public void SetGender(char gender) => this.gender = gender;

    public bool IsMinor() => age < 18;

    public override string ToString() => $"{name} - {age} - {gender}";
}

public class Father : Person
{
    public Father(string name, int age) : base(name, age, 'M') { }

    public virtual void IntroduceWithStyle(int n)
    {
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(new string(' ', i) + "I am your father");
        }
    }
}

public class Son : Father
{
    public Son(string name, int age) : base(name, age) { }

    public Son(int age) : base("Unknown", age) { }

    public override void IntroduceWithStyle(int n)
    {
        for (int i = n - 1; i >= 0; i--)
        {
            Console.WriteLine(new string(' ', i) + "I am your son");
        }
    }
}