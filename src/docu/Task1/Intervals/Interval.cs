namespace Intervals
{  public class Interval
  {
    public int From { get; set; }

    public int To { get; set; }

    public static bool operator > (Interval i1, Interval i2)
    {
      return (i1.From > i2.From && i1.From > i2.To) ? true : false;
    }

    public static bool operator < (Interval i1, Interval i2)
    {
      return (i2.From > i1.From && i2.From > i1.To) ? true : false;
    }

    public static Interval Parse(string s)
    {
      var trimChar = new char[] { ' ', '(', ')' };
      var separator = '-';
      var boundries = s.Trim(trimChar).Split(separator);

      int from = int.Parse(boundries[0]);
      int to = int.Parse(boundries[1]);

      return new Interval(from, to);
    }

    public Interval(int low, int high)
    {
      this.From = low;
      this.To = high;
    }

    public override string ToString()
    {      
      return $"({this.From}-{this.To})";
    }

    public override bool Equals(object obj)
    {
      if (obj == null || GetType() != obj.GetType())
      {
        return false;
      }

      Interval i = (Interval) obj;

      return (this.From == i.From) && (this.To == i.To);
    }

    public override int GetHashCode()
    {
      return (this.From ^ this.To);
    }

    public bool IntersectWith(Interval i)
    {
      var result = false;

      if (this.IntersectAtLeftWith(i) || i.IntersectAtLeftWith(this))
      {
        result = true;
      }
      else if (this.IntersectAtRightWith(i) || i.IntersectAtRightWith(this))
      {
        result = true;
      }

      return result;
    }

    public bool IntersectWith(Interval i, out Intersection point)
    {
      point = Intersection.None;
      var result = false;

      if (this.IntersectAtLeftWith(i))
      {
        point = Intersection.Left;
        result = true;
      }

      if (this.IntersectAtRightWith(i))
      {
        point = (point == Intersection.None ? Intersection.Right : Intersection.Both);
        result = true;
      }
      
      if (!result)
      {
        if (i.IntersectAtLeftWith(this))
        {
          point = Intersection.Left;
          result = true;
        }

        if (i.IntersectAtRightWith(this))
        {
          point = (point == Intersection.None ? Intersection.Right : Intersection.Both);
          result = true;
        }
      }

      return result;
    }

    protected bool IntersectAtLeftWith(Interval i)
    {
      return (this.From <= i.To && i.To <= this.To); 
    }

    protected bool IntersectAtRightWith(Interval i)
    {
      return (this.From <= i.From && i.From <= this.To);
    }
  }
}