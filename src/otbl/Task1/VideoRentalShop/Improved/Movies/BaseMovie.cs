using System;

namespace TechTasks.Improved.Movies
{
  public abstract class BaseMovie : IMovie
  {
    private static readonly TimeSpan BeingNewRelease = TimeSpan.FromDays(3.0 * 30);

    private const double Price = 3.0;

    public string Title { get; protected set; }

    public DateTime ReleaseDate { get; protected set; }

    public bool IsNewRelease
    {
      get
      {
        return (DateTime.UtcNow - this.ReleaseDate) < BeingNewRelease;
      }
    }

    public BaseMovie(string title, DateTime releaseDate)
    {
      this.Title = title;
      this.ReleaseDate = releaseDate;
    }

    public double CalculateRentalPrice(int daysRented)
    {
      return this.IsNewRelease ? this.CalculateNewReleaseRentalPrice(daysRented) :
                                 this.CalculateRegularRentalPrice(daysRented);
    }

    protected virtual double CalculateNewReleaseRentalPrice(int daysRented)
    {
      return daysRented * Price;
    }

    protected abstract double CalculateRegularRentalPrice(int daysRented);
  }
}
