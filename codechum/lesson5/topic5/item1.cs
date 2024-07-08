public class Person {
  private string name;
  private int age;
  private char gender;

  public string GetName() { return name; }

  public void SetName(string name) { this.name = name; }

  public int GetAge() { return age; }

  public void SetAge(int age) {
    if (age >= 0) // Example validation: age should be positive
    {
      this.age = age;
    }
  }

  public char GetGender() { return gender; }

  public void SetGender(char gender) {
    if (gender == 'M' || gender == 'F') // Ensuring gender is either 'M' or 'F'
    {
      this.gender = gender;
    }
  }
}