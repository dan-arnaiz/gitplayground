public class Bird {
  public string breed { get; set; }
  public bool isNocturnal { get; set; }

  public Bird() {
    breed = "Unknown";
    isNocturnal = false;
  }

  public Bird(string breed, bool isNocturnal) {
    this.breed = breed;
    this.isNocturnal = isNocturnal;
  }
}
