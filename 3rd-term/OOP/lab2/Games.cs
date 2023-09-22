namespace Classes;

public class Games
{
  public string OpponentName { get;}
  public string NumberGame { get; }
  public int RatingGame { get; }
  public string Result {get;}
  public Games(string opponentName,string numberGame, int rating, string result)
  {
    OpponentName = opponentName;
    NumberGame = numberGame;
    RatingGame = rating;
    Result = result;
  }
}