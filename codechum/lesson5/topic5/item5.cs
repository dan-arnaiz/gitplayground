public class SecureBankAccount {
  private string accountNumber;
  private double balance;
  private string pin;
  private bool isLocked;

  public SecureBankAccount(string accountNumber, double initialBalance,
                           string pin) {
    this.accountNumber = accountNumber;
    this.balance = initialBalance;
    this.pin = pin;
    this.isLocked = false;
  }

  public string GetAccountNumber() { return accountNumber; }

  public double GetBalance() { return balance; }

  public void Deposit(double amount) {
    if (!isLocked) {
      balance += amount;
    }
  }

  public string Withdraw(double amount, string enteredPin) {
    if (isLocked) {
      return "Account is locked. Withdrawal not allowed.";
    } else if (enteredPin != pin) {
      return "Incorrect PIN.";
    } else if (balance < amount) {
      return "Insufficient balance for withdrawal.";
    } else {
      balance -= amount;
      return $"Withdrawal successful. New balance: {balance:0.00}";
    }
  }

  public void LockAccount() { isLocked = true; }

  public override string ToString() {
    return $"{accountNumber} - P{balance:0.00} - {isLocked}";
  }
}