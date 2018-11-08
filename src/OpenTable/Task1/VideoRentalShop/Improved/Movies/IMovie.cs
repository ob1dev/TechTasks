using System;

namespace TechTasks.Improved.Movies
{
  public interface IMovie
  {
    string Title { get; }

    DateTime ReleaseDate { get; } 

    bool IsNewRelease { get; }

    double CalculateRentalPrice(int daysRented);
  }
}