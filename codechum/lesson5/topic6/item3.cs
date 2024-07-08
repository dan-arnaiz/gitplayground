public class Number {
  private int value;

  public Number(int value) { this.value = value; }

  public int GetValue() => value;
  public void SetValue(int value) => this.value = value;
}

public class WholeNumber : Number {
  public WholeNumber(int value) : base(value) {}

  public void Multiply(WholeNumber wholeNumber) {
    SetValue(GetValue() * wholeNumber.GetValue());
  }

  public override string ToString() { return GetValue().ToString(); }
}

public class DecimalNumber : Number {
  private int decimalPlaces;

  public DecimalNumber(int value, int decimalPlaces) : base(value) {
    this.decimalPlaces = decimalPlaces;
  }

  public int GetDecimalPlaces() => decimalPlaces;
  public void
  SetDecimalPlaces(int decimalPlaces) => this.decimalPlaces = decimalPlaces;

  public void Multiply(DecimalNumber decimalNumber) {
    SetValue(GetValue() * decimalNumber.GetValue());
    decimalPlaces += decimalNumber.GetDecimalPlaces();
  }

  public override string ToString() {
    string valueString = GetValue().ToString();
    if (decimalPlaces >= valueString.Length) {
      valueString = valueString.PadLeft(decimalPlaces + 1, '0');
    }
    return "0." + valueString.Substring(valueString.Length - decimalPlaces);
  }
}