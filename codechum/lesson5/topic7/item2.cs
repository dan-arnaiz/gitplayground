public abstract class FamilyMember {
  private string type;

  public FamilyMember(string type) { this.type = type; }

  abstract public void Greet();

  public override string ToString() { return $"Family Member [{type}]"; }
}

public class Father : FamilyMember {
  public Father() : base("Father") {}

  public override void Greet() { Console.WriteLine("I am your father"); }
}

public class Mother : FamilyMember {
  public Mother() : base("Mother") {}

  public override void Greet() { Console.WriteLine("Mother knows best"); }
}

public class Son : FamilyMember {
  public Son() : base("Son") {}

  public override void Greet() {
    Console.WriteLine("My father and mother love me");
  }
}
