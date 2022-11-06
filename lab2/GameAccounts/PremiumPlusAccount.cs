namespace Classes;

class PremiumPlusAccount : GameAccount
{
  private int streak = 0;
  private int AdditionalPoints = 5;
  public override void WinGame(Game typeGame, GameAccount opponent, string numberGame)
  {
    int rating = typeGame.Rating;
    if(typeGame.GetType().Name != "TrainingGame") {
      streak += 1;

      if (streak >= 3)
      {
        rating += AdditionalPoints;
      }
    }
    
    CurrentRating += rating;
    GamesCount++;

    var game = new Games(opponent.UserName, numberGame, rating, "Win");
    allGames.Add(game);
  }
  public override void LoseGame(Game typeGame, GameAccount opponent, string numberGame)
  {
    if (typeGame.GetType().Name != "TrainingGame"){
      streak=0;
    }
    int rating = typeGame.Rating / 2;

    CurrentRating -= rating;
    GamesCount++;

    var game = new Games(opponent.UserName, numberGame, rating, "Lose");
    allGames.Add(game);
  }
  public PremiumPlusAccount(string name) : base(name) {
    TypeAccount = "Premium+";
  }
}