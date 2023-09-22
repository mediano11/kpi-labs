namespace Classes;

class TrainingGame : Game
{
  
  public override int Rating => 0;
  public TrainingGame(GameAccount player1, GameAccount player2) : base(player1, player2) { }

  public override String displayGameResult(GameAccount winner, GameAccount loser)
  {
    return $"\nTraining game finished. Unique id of the game is {this.NumberGame}. Winner: {winner.UserName}. Loser: {loser.UserName}\n";
  }

}