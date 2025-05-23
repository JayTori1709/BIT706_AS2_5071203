using System.Collections.Generic;
using System.IO;
using Assessment2.App.BusinessLayer;

namespace Assessment2.App.Services
{
    public class CsvCustomerService : ICustomerService
    {
        private const string FilePath = "customers.csv";

        public List<Customer> LoadCustomers()
        {
            var customers = new List<Customer>();

            if (!File.Exists(FilePath))
                return customers;

            using var reader = new StreamReader(FilePath);
            string? line;
            bool isFirst = true;

            while ((line = reader.ReadLine()) != null)
            {
                if (isFirst) { isFirst = false; continue; }
                customers.Add(Customer.FromCsv(line));
            }

            return customers;
        }

        public void SaveCustomers(List<Customer> customers)
        {
            using var writer = new StreamWriter(FilePath);
            Customer.WriteHeaderToCsv(writer);
            foreach (var customer in customers)
            {
                customer.WriteToCsv(writer);
            }
        }
    }
}
