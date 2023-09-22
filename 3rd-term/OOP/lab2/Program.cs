using Classes;

internal class Program
{
  private static void Main(string[] args)
  {
    GameAccount player1 = new DefaultAccount("Dima");
    GameAccount player2 = new PremiumPlusAccount("Richard");

    var games = new CreateGames();
    games.getDefaultGame(player1,player2);
    Console.WriteLine(player1.toString());
    Console.WriteLine(player2.toString());

    games.getTrainingGame(player1, player2);
    Console.WriteLine(player1.toString());
    Console.WriteLine(player2.toString());

    games.getDefaultGame(player1, player2, 40);
    Console.WriteLine(player1.toString());
    Console.WriteLine(player2.toString());

    games.getDefaultGame(player1, player2);
    Console.WriteLine(player1.toString());
    Console.WriteLine(player2.toString());
    
    games.getDefaultGame(player1, player2);
    Console.WriteLine(player1.toString());
    Console.WriteLine(player2.toString());

    Console.WriteLine(player1.GetGamesHistory());
    Console.WriteLine(player2.GetGamesHistory());

    try {
      games.getDefaultGame(player1, player2, -20);
    }
    catch (System.Exception e) {
      Console.WriteLine(e);
    }
  }
}