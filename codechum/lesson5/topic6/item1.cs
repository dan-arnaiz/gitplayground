public class Beverage
{
    private string name;
    private int volume;
    private bool isChilled;

    public Beverage(string name, int volume, bool isChilled)
    {
        this.name = name;
        this.volume = volume;
        this.isChilled = isChilled;
    }

    public bool IsEmpty()
    {
        return volume == 0;
    }

    public override string ToString()
    {
        return $"{name} ({volume}mL) {(isChilled ? "is still chilled" : "is not chilled anymore")}";
    }

    public string GetName() => name;
    public int GetVolume() => volume;
    public bool GetIsChilled() => isChilled;
}

public class Water : Beverage
{
    private string waterType;

    public Water(int volume, bool isChilled, string type) : base("Water", volume, isChilled)
    {
        this.waterType = type;
    }

    public Water(int volume, bool isChilled) : this(volume, isChilled, "Regular") { }

    public string GetWaterType() => waterType;
}

public class Beer : Beverage
{
    private double alcoholicContent;

    public Beer(int volume, bool isChilled, double alcoholicContent) : base("Beer", volume, isChilled)
    {
        this.alcoholicContent = alcoholicContent;
    }

    public string GetAlcoholType()
    {
        if (alcoholicContent < 0.03) return "Flavored";
        else if (alcoholicContent < 0.06) return "Regular";
        else return "Strong";
    }

    public override string ToString()
    {
        return base.ToString() + $" ({alcoholicContent * 100:0.0}% alcoholic content)";
    }

    public double GetAlcoholicContent() => alcoholicContent;
}