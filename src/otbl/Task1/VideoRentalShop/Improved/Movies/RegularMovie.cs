using System;

namespace TechTasks.Improved.Movies
{
  public class RegularMovie : BaseMovie
  {
    private const double StartPrice = 2.0;
    private const double Price = 1.5;
    private const int DaysRentedFactor = 2;

    public RegularMovie(string title, DateTime releaseDate) : base (title, releaseDate)
    {
    }

    protected override double CalculateRegularRentalPrice(int daysRented)
    {
      var result = StartPrice;

      if (daysRented > DaysRentedFactor)
      {
        result += (daysRented - DaysRentedFactor) * Price;
      }

      return result;
    }
  }
}
