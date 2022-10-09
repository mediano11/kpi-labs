using System;
using System.Collections.Generic;

namespace Classes;

public class GameAccount
{
  public string NumberAccount {get;}
  public string UserName { get; set; }
  public int CurrentRating {get;set;}
  public int GamesCount {get;set;}

  private static int initialRating = 1000;
  private static int inititalGamesCount = 0;
  private static int accountNumberSeed = 1234567890;
  public GameAccount(string name)
  {
    NumberAccount = accountNumberSeed.ToString();
    accountNumberSeed++;
    UserName = name;
    CurrentRating = initialRating;
    GamesCount = inititalGamesCount;
  }
  public String toString()
  {
    return $"Player {this.UserName} has {this.CurrentRating} points. His unique id is {this.NumberAccount}. Games played: {this.GamesCount}";
  }

  private List<Games> allGames = new List<Games>();
  public void WinGame(int rating, GameAccount opponent, string numberGame){
    CurrentRating +=rating;

    var game = new Games(opponent.UserName, numberGame, rating, "Win");
    allGames.Add(game);
  }
  public void LoseGame(int rating, GameAccount opponent,string numberGame)
  {
    CurrentRating -= rating;

    var game = new Games(opponent.UserName, numberGame, rating, "Lose");
    allGames.Add(game);
  }


  public string GetGamesHistory()
  {
    var history = new System.Text.StringBuilder();
    history.AppendLine($"\nPlayer: {this.UserName}\t\tCurrent rating: {this.CurrentRating}");
    history.AppendLine("GameID\tOpponent\tRating\tResult");
    foreach (var item in allGames)
    {
      history.AppendLine($"{item.NumberGame}\t{item.OpponentName}\t\t{item.RatingGame}\t{item.Result}");
    }

    return history.ToString();
  }
}