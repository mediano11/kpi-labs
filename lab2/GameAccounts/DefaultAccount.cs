namespace Classes;
class DefaultAccount : GameAccount{
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
    int rating = typeGame.Rating;

    CurrentRating -= rating;
    GamesCount++;

    var game = new Games(opponent.UserName, numberGame, rating, "Lose");
    allGames.Add(game);
  }
  public DefaultAccount(string name) : base(name) {
    TypeAccount = "Player";
   }

}