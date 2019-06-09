using System;

namespace Sort
{
  public class Slice
  {
    public int Min { get; set; }

    public int Max { get; set; }

    public ArraySegment<int> Segment { get; set; }

    public Slice(int min, int max, ArraySegment<int> segment)
    {
      this.Min = min;
      this.Max = max;
      this.Segment = segment;
    }

    public bool IntersectWith(Slice s)
    {
      var result = false;

      if (this.Max >= s.Min && this.Min >= s.Min)
      {
        result = true;
      }

      return result;
    }

    public Slice MergeWith(Slice s, int[] originalArray)
    {
      var offset = Math.Min(this.Segment.Offset, s.Segment.Offset);
      var count = this.Segment.Count + s.Segment.Count;

      var newSegment = new ArraySegment<int>(originalArray, offset, count);

      var minValue = Math.Min(this.Min, s.Min);
      var maxValue = Math.Max(this.Max, s.Max);

      return new Slice(minValue, maxValue, newSegment);
    }

  }
}