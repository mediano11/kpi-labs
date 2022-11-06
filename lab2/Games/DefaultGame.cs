namespace Classes;

class DefaultGame : Game
{
  private int _rating = 25;
  public override int Rating {
    get{
      return _rating;
    }
    set{
      if (value < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(Rating), "The rating value of the game should be positive!");
      } else {
        _rating = value;
      }
    }
  }
  public DefaultGame(GameAccount player1, GameAccount player2) : base(player1, player2) {
   }
  public DefaultGame(GameAccount player1, GameAccount player2, int rating) : base(player1, player2, rating) {
    Rating = rating;
  }

  public override String displayGameResult(GameAccount winner, GameAccount loser)
  {
    return $"\nGame finished. Game value: {this.Rating} points. Unique id of the game is {this.NumberGame}. Winner: {winner.UserName}. Loser: {loser.UserName}\n";
  }
}