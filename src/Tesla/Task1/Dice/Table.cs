using DiceTable.Dice;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DiceTable
{
  public class Table
  {
    private List<Die> dice;

    public Table(int diceNumber)
    {
      this.ValidateDice(diceNumber);

      this.dice = new List<Die>(diceNumber);

      for (int index = 0; index < diceNumber; index++)
      {
        this.dice.Add(new Die());
      }
    }

    public Table(int[] dice)
    {
      this.ValidateDice(dice.Length);

      this.dice = new List<Die>(dice.Length);

      foreach (var die in dice)
      {
        if (Enum.IsDefined(typeof(SideType), die))
        {
          var side = (SideType)die;
          this.dice.Add(new Die(side));
        }
        else
        {
          throw new ArgumentOutOfRangeException(nameof(die), $"The die side must be between 1 and 6.");
        }
      }
    }

    public int FindMinMovesNecessary()
    {
      var moves = this.FindAllMoves();

      var move = moves.OrderBy(item => item.Value).First();

      return move.Value;
    }

    public Dictionary<SideType, int> FindAllMoves()
    {
      var moves = new Dictionary<SideType, int>(this.dice.Count);

      foreach (var die in this.dice)
      {
        var side = die.TopSide;

        if (!moves.ContainsKey(side))
        {
          moves.Add(side, this.FindMoves(side));
        }
      }

      return moves;
    }

    public int FindMoves(SideType side)
    {
      var totalMovesNecessary = 0;

      for (int index = 0; index < this.dice.Count; index++)
      {
        totalMovesNecessary += (int)this.dice[index].TryRotateTo(side);
      }

      return totalMovesNecessary;
    }

    private void ValidateDice(int number)
    {
      if (number < 1 || number > 100)
      {
        throw new ArgumentOutOfRangeException(nameof(number), $"The number of dice on a table must be between 1 and 100.");
      }
    }
  }
}