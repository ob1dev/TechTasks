using System;
using System.Collections.Generic;
using System.Linq;

namespace Sort
{
  public class SliceSort
  {
    public static int[] Sort(int[] array)
    {
      var unsortedSlices = FindSlices(array);
      var sortedSlices = Array.CreateInstance(typeof(int), array.Length);
      var offset = 0;

      foreach (var slice in unsortedSlices)
      {
        Array.Sort(slice.Segment.Array);
        Array.Copy(slice.Segment.Array, 0, sortedSlices, offset, slice.Segment.Array.Length);
        offset += slice.Segment.Array.Length;
      }

      return (int[])sortedSlices;
    }

    public static List<Slice> FindSlices(int[] array)
    {
      ValidateArray(array.Length);

      int index = 0;
      int offset = index;

      int minValue = array[index];
      int maxValue = array[index];

      var slices = new LinkedList<Slice>();

      do
      {
        var currentNumber = array[index];
        ValidateElement(currentNumber);
        var nextNumber = ++index != array.Length ? array[index] : 0;

        if (currentNumber < minValue)
        {
          minValue = currentNumber;
        }

        if (nextNumber == 0 || nextNumber > maxValue)
        {
          var segment = new ArraySegment<int>(array, offset, index - offset);
          var newSlice = new Slice(minValue, maxValue, segment.ToArray());

          if (slices.Any() && slices.Last.Value.IntersectWith(newSlice))
          {
            var mergedSlice = slices.Last.Value.MergeWith(newSlice, array);
            slices.RemoveLast();
            slices.AddLast(mergedSlice);
          }
          else
          {
            slices.AddLast(newSlice);
          }

          minValue = maxValue = nextNumber;
          offset = index;
        }

      }
      while (index < array.Length);

      return slices.ToList();
    }

    private static void ValidateArray(int length)
    {
      if (length < 1 || length > 100000)
      {
        throw new ArgumentOutOfRangeException(nameof(length), $"The length of the array must be between 1 and 100000.");
      }
    }

    private static void ValidateElement(int element)
    {
      if (element < 1 || element > 100000000)
      {
        throw new ArgumentOutOfRangeException(nameof(element), $"The values of the array elements must be between 1 and 100000000.");
      }
    }
  }
}