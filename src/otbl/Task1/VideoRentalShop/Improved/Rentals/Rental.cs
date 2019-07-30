using System;
using TechTasks.Improved.Customers;
using TechTasks.Improved.Movies;
using TechTasks.Improved.Rentals;

namespace TechTasks
{
  public class Rental : IRental
  {
    public ICustomer Customer { get; }

    public IMovie Movie { get; }

    public DateTime StartDate { get; }

    public Rental(ICustomer customer, IMovie movie)
    {
      this.Customer = customer;
      this.Movie = movie;

      this.StartDate = DateTime.UtcNow;
    }

    public double CalculateRental()
    {
      var daysRented = DateTime.UtcNow - this.StartDate;

      return this.Movie.CalculateRentalPrice(daysRented.Days);
    }

    public string PrintStatement()
    {
      return $"Movie: {this.Movie.Title} - Amount: {this.CalculateRental()}";
    }
  }
}