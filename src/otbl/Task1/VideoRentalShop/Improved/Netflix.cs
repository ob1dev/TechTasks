using TechTasks.Improved.Customers;
using TechTasks.Improved.Movies;

namespace TechTasks.Improved
{
  class Netflix
  {
    private CustomerManager customerManager;
    private MovieManager movieManager;
    private RentalManager rentalManager;

    public Netflix()
    {
      this.customerManager = new CustomerManager();
      this.movieManager = new MovieManager();
      this.rentalManager = new RentalManager();
    }

    public void AddCustomer(Customer customer)
    {
      this.customerManager.Add(customer);
    }

    public void FindCustomer(Customer customer)
    {
      this.customerManager.Find(customer);
    }

    public void AddMovie(IMovie movie)
    {
      this.movieManager.Add(movie);
    }

    public void AddRental(Rental rental)
    {
      this.rentalManager.Add(rental);
    }

    public string PrintRentalStatement(Customer customer)
    {
      return this.rentalManager.PrintStatement(customer);
    }
  }
}