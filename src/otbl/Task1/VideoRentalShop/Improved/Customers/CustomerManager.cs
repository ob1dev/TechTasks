using System.Collections.Generic;

namespace TechTasks.Improved.Customers
{
  class CustomerManager
  {
    private List<ICustomer> customersList;

    public CustomerManager()
    {
      this.customersList = new List<ICustomer>();
    }

    public void Add(ICustomer customer)
    {
      this.customersList.Add(customer);
    }

    public void Remove(ICustomer customer)
    {
      this.customersList.Remove(customer);
    }

    public ICustomer Find(ICustomer customer)
    {
      return this.customersList.Find(item => item == customer);
    }
  }
}