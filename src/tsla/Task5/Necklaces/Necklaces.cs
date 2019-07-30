using System;

namespace Task3
{
  public class Necklaces
  {
    public int Solution(int[] array)
    {
      var maxBeads = 0;

      if (array.Length == 1)
      {
        maxBeads = 1;
      }
      else
      {
        foreach (var beadIndex in array)
        {
          if (beadIndex != -1)
          {
            var foundBeads = this.FindBeads(array, beadIndex, beadIndex);
            maxBeads = Math.Max(maxBeads, foundBeads);
          }
        }
      }

      return maxBeads;
    }

    public int FindBeads(int[] array, int startIndex, int targetIndex)
    {
      var nextIndex = array[startIndex];

      // Mark to skip it next time.
      array[startIndex] = -1;

      if (nextIndex == targetIndex)
      {
        return 1;
      }

      return this.FindBeads(array, nextIndex, targetIndex) + 1;
    }
  }
}