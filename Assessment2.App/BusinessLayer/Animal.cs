using System.IO;

namespace Assessment2.App.BusinessLayer
{
    public class Animal
    {
        public string? Breed { get; set; }
        public int Id { get; set; }
        public string? Name { get; set; }
        public int OwnerId { get; set; }
        public string? Sex { get; set; }
        public string? Type { get; set; }

        public static Animal FromCsv(string line)
        {
            var parts = line.Split(',');
            return new Animal
            {
                Id = int.Parse(parts[0]),
                Name = parts[1],
                Type = parts[2],
                Breed = parts[3],
                Sex = parts[4],
                OwnerId = int.Parse(parts[5])
            };
        }

        public static void WriteHeaderToCsv(TextWriter writer) =>
            writer.WriteLine("Id,Name,Type,Breed,Sex,OwnerId");

        public bool CheckIfValid() =>
            !string.IsNullOrWhiteSpace(Name) &&
            !string.IsNullOrWhiteSpace(Type) &&
            !string.IsNullOrWhiteSpace(Sex) &&
            OwnerId != 0;

        public override string ToString() => $"{Name} [{Type}]";

        public void WriteToCsv(TextWriter writer) => writer.WriteLine(ToCsv());

        public string ToCsv() =>
            string.Join(",", new[] {
                Id.ToString(),
                Name ?? "",
                Type ?? "",
                Breed ?? "",
                Sex ?? "",
                OwnerId.ToString()
            });
    }
}
