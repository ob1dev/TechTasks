using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;
using TechTasks.Improved.Customers;
using TechTasks.Improved.Rentals;

namespace TechTasks.Improved
{
  class RentalManager
  {
    private List<IRental> RentalsList;

    public RentalManager()
    {
      this.RentalsList = new List<IRental>();
    }

    public void Add(Rental rental)
    {
      this.RentalsList.Add(rental);
    }

    public void Remove(Rental rental)
    {
      this.RentalsList.Remove(rental);
    }

    public IEnumerable<IRental> Find(ICustomer customer)
    {
      return this.RentalsList.Where(item => item.Customer == customer);
    }

    public double CalculateTotalAmount(ICustomer customer)
    {
      var result = 0.0;

      var customerRentals = this.Find(customer);

      if (customerRentals.Any())
      { 
        foreach (var rental in customerRentals)
        {
          var daysRented = DateTime.UtcNow - rental.StartDate;
          result += rental.Movie.CalculateRentalPrice(daysRented.Days);
        }
      }

      return result;
    }

    public string PrintStatement(ICustomer customer)
    {
      var result = new StringBuilder($"Rental record for '{customer.FirstName} {customer.LastName}' \n");

      var rentals = this.Find(customer);
      if (rentals.Any())
      {
        foreach (var rent in rentals)
        {
          result.Append(rent.PrintStatement());
        }
      }

      result.Append($"Amount owed is '{this.CalculateTotalAmount(customer)}'\n");

      return result.ToString();
    }
  }
}