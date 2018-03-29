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

      var result = new StringBuilder();

      var mapping = new List<NumeralsMap>() { new NumeralsMap(1,    "I"),
                                              new NumeralsMap(5,    "V"),
                                              new NumeralsMap(10,   "X"),
                                              new NumeralsMap(50,   "L"),
                                              new NumeralsMap(100,  "C"),
                                              new NumeralsMap(500,  "D"),
                                              new NumeralsMap(1000, "M") };
      mapping.Reverse();

      var enumerator = mapping.GetEnumerator();
      enumerator.MoveNext();

      do
      {
        if (number % enumerator.Current.ArabicNumeral != number)
        {
          number -= enumerator.Current.ArabicNumeral;
          result.Append(enumerator.Current.RomanNumeral);
        }
        else
        {
          enumerator.MoveNext();
        }

      }
      while (number != 0);

      return result.ToString();
    }
  }
}