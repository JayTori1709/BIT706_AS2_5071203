using System.Collections.Generic;
using Assessment2.App.BusinessLayer;

namespace Assessment2.App.Services
{
    public interface ICustomerService
    {
        List<Customer> LoadCustomers();
        void SaveCustomers(List<Customer> customers);
    }
}
