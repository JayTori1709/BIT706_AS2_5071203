using System.Collections.Generic;
using System.IO;
using Assessment2.App.BusinessLayer;

namespace Assessment2.App.Services
{
    public class CsvAnimalService : IAnimalService
    {
        private readonly string filePath = "animals.csv";

        public List<Animal> LoadAnimals()
        {
            var animals = new List<Animal>();

            if (!File.Exists(filePath)) return animals;

            var lines = File.ReadAllLines(filePath);
            for (int i = 1; i < lines.Length; i++)
            {
                animals.Add(Animal.FromCsv(lines[i]));
            }

            return animals;
        }

        public void SaveAnimals(List<Animal> animals)
        {
            using var writer = new StreamWriter(filePath);
            Animal.WriteHeaderToCsv(writer);
            foreach (var animal in animals)
            {
                animal.WriteToCsv(writer);
            }
        }
    }
}
