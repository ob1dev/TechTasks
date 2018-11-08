using System;
using TechTasks.Improved.Customers;
using TechTasks.Improved.Movies;

namespace TechTasks.Improved.Rentals
{
  public interface IRental
  {
    ICustomer Customer { get; }

    IMovie Movie { get; }

    DateTime StartDate { get; }

    double CalculateRental();

    string PrintStatement();
  }
}
