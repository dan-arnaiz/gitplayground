public class ChessPiece {
  private string pieceType;
  private bool isWhite;

  public ChessPiece(string pieceType, bool isWhite) {
    this.pieceType = pieceType;
    this.isWhite = isWhite;
  }

  public string GetPieceType() => pieceType;
  public bool GetIsWhite() => isWhite;
}

public class Pawn : ChessPiece {
  private bool hasMoved;

  public Pawn(bool isWhite) : base("Pawn", isWhite) { hasMoved = false; }

  public void Move(bool isTwoMoves) {
    if (hasMoved || (isTwoMoves && hasMoved))
      return;

    string color = GetIsWhite() ? "White" : "Black";
    if (isTwoMoves && !hasMoved) {
      Console.WriteLine($"{color} pawn has moved two steps");
      hasMoved = true;
    } else {
      Console.WriteLine($"{color} pawn has moved one step");
      hasMoved = true;
    }
  }

  public override string ToString() {
    string color = GetIsWhite() ? "White" : "Black";
    string movedStatus = hasMoved ? "already moved" : "not yet moved";
    return $"{color} pawn has {movedStatus}";
  }
}
