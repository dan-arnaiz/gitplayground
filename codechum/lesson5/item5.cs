using System;

public class ComplexCalculator {
  public double GetSquareRoot(int number) {
    if (number < 0)
      return 0;
    return Math.Sqrt(number);
  }

  public int GetFactorial(int number) {
    if (number < 0)
      return 0;
    int factorial = 1;
    for (int i = 1; i <= number; i++) {
      factorial *= i;
    }
    return factorial;
  }

  public double GetSum(int number1, int number2) { return number1 + number2; }

  public double GetProduct(int number1, int number2) {
    return number1 * number2;
  }

  public double GetDifference(int number1, int number2) {
    return number1 - number2;
  }

  public double GetQuotient(int number1, int number2) {
    if (number2 == 0)
      return 0;
    return (double)number1 / number2;
  }
}
