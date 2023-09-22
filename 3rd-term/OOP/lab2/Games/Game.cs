using Classes;

public abstract class Game {
  public string NumberGame{get;}
  protected static int gameId = 31542;
  public virtual int Rating {get; set;}
  public Game(GameAccount player1, GameAccount player2){
    NumberGame = gameId.ToString();
    gameId++;
    FindWinner(player1, player2);
  }
  public Game(GameAccount player1, GameAccount player2, int rating){
    Rating = rating;
    NumberGame = gameId.ToString();
    gameId++;
    FindWinner(player1, player2);
  }

  public void FindWinner(GameAccount player1, GameAccount player2){
    Random rnd = new Random();
    var result = rnd.Next(0, 2);
    if (result == 0)
    {
      player1.WinGame(this, player2);
      player2.LoseGame(this, player1);
      Console.WriteLine(displayGameResult(player1, player2));
    }
    else
    {
      player2.WinGame(this, player1);
      player1.LoseGame(this, player2);
      Console.WriteLine(displayGameResult(player2, player1));
    }
  }
  public abstract String displayGameResult(GameAccount winner, GameAccount loser);
}