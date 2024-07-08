public interface Clickable {
  void Click();
}

public interface Resizable {
  void Resize(int newWidth, int newHeight);
  void Resize(int multiplier);
}

public abstract class AbstractButton : Clickable, Resizable {
  protected string title;
  protected int width;
  protected int height;
  protected bool isClicked = false;

  public AbstractButton(string title, int width, int height) {
    this.title = title;
    this.width = width;
    this.height = height;
  }

  public string GetTitle() => title;
  public void SetTitle(string value) => title = value;

  public int GetWidth() => width;
  public void SetWidth(int value) => width = value;

  public int GetHeight() => height;
  public void SetHeight(int value) => height = value;

  public abstract void Click();
  public abstract void Resize(int newWidth, int newHeight);
  public abstract void Resize(int multiplier);
}

public class Checkbox : Clickable {
  private bool isChecked = false;
  private string text;

  public Checkbox(string text) { this.text = text; }

  public void Click() {
    isChecked = !isChecked;
    Console.WriteLine(isChecked ? "Checkbox is checked"
                                : "Checkbox is unchecked");
  }

  public override string ToString() {
    return $"Checkbox ({text} - Checked = {isChecked})";
  }
}

public class NormalButton : AbstractButton {
  public NormalButton(string title, int width, int height)
      : base(title, width, height) {}

  public override void Click() {
    isClicked = !isClicked;
    Console.WriteLine(isClicked ? "Button is clicked"
                                : "Button is not clicked anymore");
  }

  public override void Resize(int newWidth, int newHeight) {
    width = newWidth;
    height = newHeight;
  }

  public override void Resize(int multiplier) {
    width *= multiplier;
    height *= multiplier;
  }

  public override string ToString() {
    return $"NormalButton (({width}px, {height}px) - Clicked = {isClicked})";
  }
}