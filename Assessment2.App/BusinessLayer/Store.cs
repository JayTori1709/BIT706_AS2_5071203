// Store.cs
using System.Collections.Generic;
using System.Linq;
using Assessment2.App.BusinessLayer;

namespace Assessment2.App.BusinessLayer
{
    public class Store
    {
        public List<Customer> Customers { get; private set; } = new List<Customer>();
        public List<Animal> Animals { get; private set; } = new List<Animal>();
        public List<Microchip> Microchips { get; private set; } = new List<Microchip>();

        // Load sample data
        public void LoadData() // Renamed to be consistent with MainWindow
        {
            Customers.AddRange(new List<Customer>
            {
                new Customer { FirstName = "John", Surname = "Doe", PhoneNumber = "123-4567", Address = "Some Address" },
                new Customer { FirstName = "Jane", Surname = "Smith", PhoneNumber = "987-6543", Address = "Another Address" }
            });

            Animals.AddRange(new List<Animal>
            {
                new Animal { Name = "Buddy", Type = "Dog", Breed = "Labrador", OwnerId = Customers[0].Id },
                new Animal { Name = "Whiskers", Type = "Cat", Breed = "Siamese", OwnerId = Customers[1].Id }
            });

            Microchips.AddRange(new List<Microchip>
            {
                new Microchip { ChipId = "MC12345" },
                new Microchip { ChipId = "MC67890" }
            });

            // You might need to link Microchips to Animals based on some logic
        }

        public static Store Instance { get; } = new Store();

        private Store() { } // Private constructor for singleton pattern

        public void SaveData()
        {
            // Here, save the data to a file or database as needed
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
            Animals.RemoveAll(a => a.OwnerId == customer.Id);
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
                    if (animal.OwnerId == oldCustomer.Id)
                    {
                        animal.OwnerId = updatedCustomer.Id;
                    }
                }
            }
        }

        public List<Animal> FindAnimals(int customerId)
        {
            return Animals.Where(a => a.OwnerId == customerId).ToList();
        }

        // You'll likely need methods to add, remove, and update animals as well.
    }
}