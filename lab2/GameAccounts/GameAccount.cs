using System;
using System.Collections.Generic;

namespace Classes;

public abstract class GameAccount
{
  public string NumberAccount {get;}
  public string UserName { get; set; }
  private int _rating;
  protected int CurrentRating {
    get{
      return _rating;
    }
    set{
      if(value < 1){
        _rating = 1;
      } else {
        _rating = value;
      }
    }
  }
  protected int GamesCount {get;set;}

  protected virtual String TypeAccount {get; set;}

  protected static int initialRating = 1000;
  protected static int inititalGamesCount = 0;
  protected static int accountNumberSeed = 1234567890;
  public GameAccount(string name)
  {
    NumberAccount = accountNumberSeed.ToString();
    accountNumberSeed++;
    UserName = name;
    CurrentRating = initialRating;
    GamesCount = inititalGamesCount;
    TypeAccount = "";
  }

  protected List<Games> allGames = new List<Games>();
  public abstract void WinGame(Game typeGame, GameAccount opponent, string numberGame);
  public abstract void LoseGame(Game typeGame, GameAccount opponent,string numberGame);


  public String toString()
  {
    int rating = this.allGames.Last().RatingGame;
    string difference = this.allGames.Last().Result=="Win" ? $"+{rating}" : $"-{rating}";

    return $"[{this.TypeAccount}] {this.UserName} has {this.CurrentRating}({difference}) points. His unique id is {this.NumberAccount}. Games played: {this.GamesCount}";
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
