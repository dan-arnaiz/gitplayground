public class Money {
  public int amount { get; set; }
  public string denomination { get; set; }

  public Money() {
    amount = 0;
    denomination = "Unknown";
  }

  public Money(int amount) {
    this.amount = amount;
    denomination = "Unknown";
  }

  public Money(int amount, string denomination) {
    this.amount = amount;
    this.denomination = denomination;
  }
}