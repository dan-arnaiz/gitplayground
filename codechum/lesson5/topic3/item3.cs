public class Beverage {
  public string flavor { get; set; }
  public string color { get; set; }

  public Beverage() {
    flavor = "Unknown";
    color = "Unknown";
  }

  public Beverage(string flavor, string color) {
    this.flavor = flavor;
    this.color = color;
  }
}

public class Bottle {
  public int mL { get; set; }
  public Beverage beverage { get; set; }

  public Bottle(int mL, Beverage beverage) {
    this.mL = mL;
    this.beverage = beverage;
  }

  public Bottle(int mL, string flavor, string color) {
    this.mL = mL;
    this.beverage = new Beverage(flavor, color);
  }
}