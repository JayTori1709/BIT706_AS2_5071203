// Store.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assessment2.Core;

namespace Assessment2.App
{
    public class Store
    {
        public List<Customer> Customers { get; private set; } = new List<Customer>();
        public List<Animal> Animals { get; private set; } = new List<Animal>();
        public List<Microchip> Microchips { get; private set; } = new List<Microchip>();

        // Load sample data
        public void Load()
        {
            Customers = new List<Customer>
            {
                new Customer("John", "Doe", "john.doe@example.com", "123-4567"),
                new Customer("Jane", "Smith", "jane.smith@example.com", "987-6543")
            };

            Animals = new List<Animal>
            {
                new Animal("Buddy", "Dog", "Labrador", new DateTime(2019, 5, 1), Customers[0]),
                new Animal("Whiskers", "Cat", "Siamese", new DateTime(2020, 3, 12), Customers[1])
            };

            Microchips = new List<Microchip>
            {
                new Microchip("MC12345", Animals[0]),
                new Microchip("MC67890", Animals[1])
            };
        }

        public void AddCustomer(Customer customer)
        {
            if (!Customers.Contains(customer))
            {
                Customers.Add(customer);
            }
        }

        public void RemoveCustomer(Customer customer)
        {
            Animals.RemoveAll(a => a.Owner == customer);
            Customers.Remove(customer);
        }

        public void UpdateCustomer(Customer oldCustomer, Customer updatedCustomer)
        {
            var index = Customers.IndexOf(oldCustomer);
            if (index != -1)
            {
                Customers[index] = updatedCustomer;
                foreach (var animal in Animals)
                {
                    if (animal.Owner == oldCustomer)
                    {
                        animal.Owner = updatedCustomer;
                    }
                }
            }
        }
    }
}