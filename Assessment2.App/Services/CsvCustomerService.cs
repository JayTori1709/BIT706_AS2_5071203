using System.Collections.Generic;
using System.IO;
using Assessment2.App.BusinessLayer;

namespace Assessment2.App.Services
{
    public class CsvCustomerService : ICustomerService
    {
        private readonly string filePath = "customers.csv";

        public List<Customer> LoadCustomers()
        {
            var customers = new List<Customer>();

            if (!File.Exists(filePath)) return customers;

            var lines = File.ReadAllLines(filePath);
            for (int i = 1; i < lines.Length; i++)
            {
                customers.Add(Customer.FromCsv(lines[i]));
            }

            return customers;
        }

        public void SaveCustomers(List<Customer> customers)
        {
            using var writer = new StreamWriter(filePath);
            Customer.WriteHeaderToCsv(writer);
            foreach (var customer in customers)
            {
                customer.WriteToCsv(writer);
            }
        }
    }
}
