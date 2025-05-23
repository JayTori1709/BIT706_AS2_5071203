using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assessment2.App.BusinessLayer;

namespace Assessment2.App.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
        IEnumerable<Customer> FindByName(string name);
        Customer? GetById(int customerId);
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(int customerId);
    }
}
