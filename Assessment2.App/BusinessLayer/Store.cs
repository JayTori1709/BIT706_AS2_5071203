using Assessment2.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Assessment2.Data
{
    public class Store
    {
        private readonly string dataFolder = "data";
        private readonly string customersFile = "data/customers.json";
        private readonly string animalsFile = "data/animals.json";
        private readonly string microchipsFile = "data/microchips.json";

        public List<Customer> Customers { get; private set; } = new List<Customer>();
        public List<Animal> Animals { get; private set; } = new List<Animal>();
        public List<Microchip> Microchips { get; private set; } = new List<Microchip>();

        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
            Save(); // Auto-save
        }

        public void AddAnimal(Animal animal)
        {
            Animals.Add(animal);
            Save(); // Auto-save
        }

        public void AddMicrochip(Microchip microchip)
        {
            Microchips.Add(microchip);
            Save(); // Auto-save
        }

        public void RemoveCustomer(Customer customer)
        {
            Customers.Remove(customer);
            Save(); // Auto-save
        }

        public void RemoveAnimal(Animal animal)
        {
            Animals.Remove(animal);
            Save(); // Auto-save
        }

        public void RemoveMicrochip(Microchip microchip)
        {
            Microchips.Remove(microchip);
            Save(); // Auto-save
        }

        public void Save()
        {
            if (!Directory.Exists(dataFolder))
                Directory.CreateDirectory(dataFolder);

            File.WriteAllText(customersFile, JsonSerializer.Serialize(Customers));
            File.WriteAllText(animalsFile, JsonSerializer.Serialize(Animals));
            File.WriteAllText(microchipsFile, JsonSerializer.Serialize(Microchips));
        }

        public void Load()
        {
            if (File.Exists(customersFile))
                Customers = JsonSerializer.Deserialize<List<Customer>>(File.ReadAllText(customersFile)) ?? new List<Customer>();
            else
                Customers = new List<Customer>();

            if (File.Exists(animalsFile))
                Animals = JsonSerializer.Deserialize<List<Animal>>(File.ReadAllText(animalsFile)) ?? new List<Animal>();
            else
                Animals = new List<Animal>();

            if (File.Exists(microchipsFile))
                Microchips = JsonSerializer.Deserialize<List<Microchip>>(File.ReadAllText(microchipsFile)) ?? new List<Microchip>();
            else
                Microchips = new List<Microchip>();
        }
    }
}
