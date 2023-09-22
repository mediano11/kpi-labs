using Classes;

var player1 = new GameAccount("Dima");
Console.WriteLine(player1.toString());

var player2 = new GameAccount("Richard");
Console.WriteLine(player2.toString());

var game1 = new Game(player1,player2, 25);
Console.WriteLine(player1.toString());
Console.WriteLine(player2.toString());

var game2 = new Game(player1, player2, 30);
Console.WriteLine(player1.toString());
Console.WriteLine(player2.toString());

Console.WriteLine(player1.GetGamesHistory());
Console.WriteLine(player2.GetGamesHistory());