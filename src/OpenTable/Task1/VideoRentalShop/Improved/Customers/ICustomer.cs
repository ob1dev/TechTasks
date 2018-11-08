namespace TechTasks.Improved.Customers
{
  public interface ICustomer
  {
    string FirstName { get; }

    string LastName { get; }

    string Email { get; }

    string Phone { get; }
  }
}
