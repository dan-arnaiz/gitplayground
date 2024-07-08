public interface Lover {
  void SetLover(Lover lover);
  void ReceiveLove();
  void GiveLove();
}

public abstract class Friend : Lover {
  private char gender;
  private bool isLoved = false;

  public Friend(char gender) { this.gender = gender; }

  public void ReceiveLove() { isLoved = true; }

  public override string ToString() { return $"{gender} - {isLoved}"; }

  public abstract void SetLover(Lover lover);
  public abstract void GiveLove();
}

public interface BoyFriend {
  void GiveFlowers(int flowerCount);
}

public interface GirlFriend {
  void ReceiveFlowers(int flowerCount);
}

public class MaleFriend : Friend, BoyFriend {
  private int flowersGiven = 0;
  private FemaleFriend lover;

  public MaleFriend() : base('M') {}

  public override void SetLover(Lover lover) {
    this.lover = lover as FemaleFriend;
  }

  public override void GiveLove() {
    Console.WriteLine("mwamwa");
    lover?.ReceiveLove();
  }

  public void GiveFlowers(int flowerCount) {
    flowersGiven += flowerCount;
    lover?.ReceiveFlowers(flowerCount);
  }
}

public class FemaleFriend : Friend, GirlFriend {
  private int flowersReceived = 0;
  private MaleFriend lover;

  public FemaleFriend() : base('F') {}

  public override void SetLover(Lover lover) {
    this.lover = lover as MaleFriend;
  }

  public override void GiveLove() {
    Console.WriteLine("tsuptsup");
    lover?.ReceiveLove();
  }

  public void ReceiveFlowers(int flowerCount) {
    flowersReceived += flowerCount;
  }
}
