using System.Collections.Generic;
using System.IO;
using Assessment2.App.BusinessLayer;

namespace Assessment2.App.Services
{
    public class CsvAnimalService : IAnimalService
    {
        private const string FilePath = "animals.csv";

        public List<Animal> LoadAnimals()
        {
            var animals = new List<Animal>();

            if (!File.Exists(FilePath))
                return animals;

            using var reader = new StreamReader(FilePath);
            string? line;
            bool isFirst = true;

            while ((line = reader.ReadLine()) != null)
            {
                if (isFirst) { isFirst = false; continue; }
                animals.Add(Animal.FromCsv(line));
            }

            return animals;
        }

        public void SaveAnimals(List<Animal> animals)
        {
            using var writer = new StreamWriter(FilePath);
            Animal.WriteHeaderToCsv(writer);
            foreach (var animal in animals)
            {
                animal.WriteToCsv(writer);
            }
        }
    }
}
