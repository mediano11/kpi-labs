namespace Classes;

class CreateGames
{
  public Game getDefaultGame(GameAccount player1, GameAccount player2){
    return new DefaultGame(player1, player2);
  }
  public Game getDefaultGame(GameAccount player1, GameAccount player2, int rating)
  {
    return new DefaultGame(player1, player2, rating);
  }
  public Game getTrainingGame(GameAccount player1, GameAccount player2)
  {
    return new TrainingGame(player1, player2);
  }
}