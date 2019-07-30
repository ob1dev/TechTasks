namespace TechTasks.Improved.Customers
{
  public class Customer : ICustomer
  {
    public string FirstName { get; }

    public string LastName { get;  }

    public string Email { get; }

    public string Phone { get; }

    public Customer(string firstName, string lastName, string email, string phone)
    {
      this.FirstName = firstName;
      this.LastName = lastName;
      this.Email = email;
      this.Phone = phone;
    }
  }
}