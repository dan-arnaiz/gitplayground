public abstract class Shape {
  private string name;
  private string color;
  private bool isFlat;

  public Shape(string name, string color, bool isFlat) {
    this.name = name;
    this.color = color;
    this.isFlat = isFlat;
  }

  public string GetName() => name;
  public string GetColor() => color;
  public bool GetIsFlat() => isFlat;
  public void SetColor(string color) => this.color = color;
}

public abstract class TwoDShape : Shape {
  private int numberOfSides;

  public TwoDShape(string name, string color, int numberOfSides)
      : base(name, color, true) {
    this.numberOfSides = numberOfSides;
  }

  public int GetNumberOfSides() => numberOfSides;
  public abstract double GetArea();
  public abstract double GetPerimeter();
}

public abstract class ThreeDShape : Shape {
  public ThreeDShape(string name, string color) : base(name, color, false) {}

  public abstract double GetSurfaceArea();
  public abstract double GetVolume();
}

public class Square : TwoDShape {
  private double lengthOfSide;

  public Square(string color, double lengthOfSide) : base("Square", color, 4) {
    this.lengthOfSide = lengthOfSide;
  }

  public double GetLengthOfSide() => lengthOfSide;
  public override double GetArea() => lengthOfSide * lengthOfSide;
  public override double GetPerimeter() => 4 * lengthOfSide;
}

public class RectangularPrism : ThreeDShape {
  private double length;
  private double width;
  private double height;

  public RectangularPrism(string color, double length, double width,
                          double height)
      : base("Rectangular Prism", color) {
    this.length = length;
    this.width = width;
    this.height = height;
  }

  public double GetLength() => length;
  public double GetWidth() => width;
  public double GetHeight() => height;
  public override double
  GetSurfaceArea() => 2 * (width * length + height * length + height * width);
  public override double GetVolume() => width * height * length;
}