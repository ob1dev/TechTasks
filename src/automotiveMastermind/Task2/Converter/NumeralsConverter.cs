using System;
using System.Collections.Generic;
using System.Text;

namespace Converter
{
  public class NumeralsConverter
  {
    class NumeralsMap
    {
      public NumeralsMap(int arabicNumeral, string romanNumeral)
      {
        this.ArabicNumeral = arabicNumeral;
        this.RomanNumeral = romanNumeral;
      }

      public int ArabicNumeral { get; set; }
      public string RomanNumeral { get; set; }
    }

    public static string ToRoman(int number)
    {
      if (number < 1 || number > 1000)
      {
        throw new ArgumentOutOfRangeException(nameof(number), $"The value '{number}' must be between 1 and 1000.");
      }

      var mapping = new LinkedList<NumeralsMap>(new[] { new NumeralsMap(1,    "I"),
                                                        new NumeralsMap(5,    "V"),
                                                        new NumeralsMap(10,   "X"),
                                                        new NumeralsMap(50,   "L"),
                                                        new NumeralsMap(100,  "C"),
                                                        new NumeralsMap(500,  "D"),
                                                        new NumeralsMap(1000, "M") });
      var result = new StringBuilder();
      var enumerator = mapping.Last;

      do
      {
        if (number % enumerator.Value.ArabicNumeral != number)
        {
          var symbol = FindNearestSymbol(enumerator, number);

          if (number > 0)
          {
            result.Append(symbol.Value.RomanNumeral);
            number = number - symbol.Value.ArabicNumeral;
          }
          else if (number < 0)
          {
            result.Insert(0, symbol.Value.RomanNumeral);
            number = number + symbol.Value.ArabicNumeral;
          }
        }
        else
        {
          enumerator = enumerator.Previous;
        }

      }
      while (number != 0);

      return result.ToString();
    }

    private static LinkedListNode<NumeralsMap> FindNearestSymbol(LinkedListNode<NumeralsMap> curentNode, int number)
    {
      var result = curentNode;
      var nextNode = curentNode.Next;

      if (nextNode != null)
      {
        double sum = curentNode.Value.ArabicNumeral + nextNode.Value.ArabicNumeral;

        if (sum / 2.0 < number)
        { 
          result = nextNode;
        }
      }

      return result;
    }
  }
}