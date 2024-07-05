using System;
using System.Collections.Generic;

public abstract class Shape
{
    public abstract double GetArea();
    public abstract double GetPerimeter();
}

public class Square : Shape
{
    private double side;

    public Square(double side)
    {
        this.side = side;
    }

    public override double GetArea()
    {
        return side * side;
    }

    public override double GetPerimeter()
    {
        return 4 * side;
    }
}

public class Rectangle : Shape
{
    private double length;
    private double width;

    public Rectangle(double length, double width)
    {
        this.length = length;
        this.width = width;
    }

    public override double GetArea()
    {
        return length * width;
    }

    public override double GetPerimeter()
    {
        return 2 * (length + width);
    }
}

public class Triangle : Shape
{
    private double a;
    private double b;
    private double c;

    public Triangle(double a, double b, double c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public override double GetArea()
    {
        double s = (a + b + c) / 2;
        return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
    }

    public override double GetPerimeter()
    {
        return a + b + c;
    }
}

public class ShapeCollection
{
    private List<Shape> shapes;

    public ShapeCollection(List<Shape> shapes)
    {
        this.shapes = shapes;
    }

    public void CalculateAndPrintAreaAndPerimeter()
    {
        foreach (Shape shape in shapes)
        {
            double area = shape.GetArea();
            double perimeter = shape.GetPerimeter();
            Console.WriteLine($"Area: {area:F2}");
            Console.WriteLine($"Perimeter: {perimeter:F2}\n");
        }
    }
}