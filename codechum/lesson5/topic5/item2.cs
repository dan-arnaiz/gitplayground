using System;

public class Car
{
    private string color;
    private double price;
    private char size;

    public Car(string color, double price, char size)
    {
        this.color = color;
        this.price = price;
        this.size = Char.ToUpper(size);
    }

    public string GetColor()
    {
        return color;
    }

    public double GetPrice()
    {
        return price;
    }

    public char GetSize()
    {
        return size;
    }

    public void SetColor(string color)
    {
        this.color = color;
    }

    public void SetPrice(double price)
    {
        this.price = price;
    }

    public void SetSize(char size)
    {
        if (size == 'S' || size == 'M' || size == 'L')
        {
            this.size = Char.ToUpper(size);
        }
    }

    public override string ToString()
    {
        string sizeDescriptor = "unknown"; // Default value
        switch (size)
        {
        case 'S':
            sizeDescriptor = "small";
            break;
        case 'M':
            sizeDescriptor = "medium";
            break;
        case 'L':
            sizeDescriptor = "large";
            break;
        }
        return $"Car ({color}) - P{price:0.00} - {sizeDescriptor}";
    }
}