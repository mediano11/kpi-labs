namespace Classes;

class PremiumAccount : GameAccount
{
  public override void WinGame(Game typeGame, GameAccount opponent, string numberGame)
  {
    int rating = typeGame.Rating;
    CurrentRating += rating;
    GamesCount++;
    
    var game = new Games(opponent.UserName, numberGame, rating, "Win");
    allGames.Add(game);
  }
  public override void LoseGame(Game typeGame, GameAccount opponent, string numberGame)
  {
    int rating = typeGame.Rating/2;
    CurrentRating -= rating;
    GamesCount++;

    var game = new Games(opponent.UserName, numberGame, rating, "Lose");
    allGames.Add(game);
  }
  public PremiumAccount(string name) : base(name) {
    TypeAccount = "Premium";
   }
}