using Classes;

public class Game {
  public string NumberGame{get;}
  private static int gameId = 31542;
 
  public Game(GameAccount player1, GameAccount player2, int rating){
    if (rating < 0)
    {
      throw new ArgumentOutOfRangeException(nameof(rating), "The rating value of the game should be positive!");
    }
    if (player1.CurrentRating - rating < 1 || player2.CurrentRating - rating < 1)
    {
      throw new InvalidOperationException("The rating value of players can`t be less than 1!");
    }

    NumberGame = gameId.ToString();
    gameId++;
    player1.GamesCount++;
    player2.GamesCount++;
    
    Random rnd = new Random();
    var result = rnd.Next(0, 2);
    if(result == 0){
      player1.WinGame(rating, player2, NumberGame);
      player2.LoseGame(rating, player1, NumberGame);
      Console.WriteLine(displayGameResult(player1, player2, rating));
    }
    else{
      player2.WinGame(rating, player1, NumberGame);
      player1.LoseGame(rating, player2, NumberGame);
      Console.WriteLine(displayGameResult(player2, player1, rating));
    }
    
  }
  public String displayGameResult(GameAccount winner, GameAccount loser, int rating)
  {
    return $"\nGame finished. Game value: {rating} points. Unique id of the game is {this.NumberGame}. Winner: {winner.UserName}. Loser: {loser.UserName}\n";
  }
}