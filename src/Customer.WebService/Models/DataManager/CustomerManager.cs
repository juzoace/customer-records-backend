using CustomerCRUD.WebService.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerCRUD.WebService.Models.DataManager
{
    public class CustomerManager : IDataRepository<Customer>
    {
        readonly CustomerContext _customerContext;

        public CustomerManager(CustomerContext customerContext)
        {
            _customerContext = customerContext;
        }
        public void Add(Customer entity)
        {
            _customerContext.Customers.Add(entity);
            _customerContext.SaveChanges();
        }

        public void Delete(Customer customer)
        {
            _customerContext.Customers.Remove(customer);
            _customerContext.SaveChanges();
        }

        public Customer Get(long id)
        {
            return _customerContext.Customers
                  .FirstOrDefault(e => e.CustomerId == id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customerContext.Customers.ToList();
        }

        public void Update(Customer customer, Customer entity)
        {
            customer.FirstName = entity.FirstName;
            customer.LastName = entity.LastName;
            customer.HairColour = entity.HairColour;
            customer.Height = entity.Height;
            customer.Weight = entity.Weight;
            customer.DateOfBirth = entity.DateOfBirth;

            _customerContext.SaveChanges();
        }
    }
}
