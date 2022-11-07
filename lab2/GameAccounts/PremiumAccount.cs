namespace Classes;

class PremiumAccount : GameAccount
{
  public override void WinGame(Game typeGame, GameAccount opponent)
  {
    int rating = typeGame.Rating;
    CurrentRating += rating;
    GamesCount++;
    
    var game = new Games(opponent.UserName, typeGame.NumberGame, rating, "Win");
    allGames.Add(game);
  }
  public override void LoseGame(Game typeGame, GameAccount opponent)
  {
    int rating = typeGame.Rating/2;
    CurrentRating -= rating;
    GamesCount++;

    var game = new Games(opponent.UserName, typeGame.NumberGame, rating, "Lose");
    allGames.Add(game);
  }
  public PremiumAccount(string name) : base(name) {
    TypeAccount = "Premium";
   }
}