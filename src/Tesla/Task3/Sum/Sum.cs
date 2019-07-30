using System.Linq;

namespace Task1
{
  public class Sum
  {
    public int Solution(int[] array)
    {
      return array.Where(item => ((item >= 10) && (item < 100)) || ((item <= -10) && (item > -100))).Sum();
    }
  }
}