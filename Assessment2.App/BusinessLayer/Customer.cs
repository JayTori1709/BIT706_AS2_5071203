using System;
using System.IO;

namespace Assessment2.App.BusinessLayer
{
    public class Customer
    {
        public string? Address { get; set; }
        public string? FirstName { get; set; }
        public int Id { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Surname { get; set; }

        public static Customer FromCsv(string line)
        {
            var parts = line.Split(',');

            var customer = new Customer
            {
                Id = int.Parse(parts[0]),
                FirstName = parts[1],
                Surname = parts[2],
                PhoneNumber = parts[3],
                Address = parts.Length > 4
                    ? parts[4].Trim('"').Replace("\\n", Environment.NewLine)
                    : string.Empty
            };

            return customer;
        }

        public static void WriteHeaderToCsv(TextWriter writer)
        {
            writer.WriteLine("Id,First Name,Surname,Phone,Address");
        }

        public bool CheckIfValid()
        {
            return !(string.IsNullOrEmpty(FirstName)
                || string.IsNullOrEmpty(PhoneNumber)
                || string.IsNullOrEmpty(Surname));
        }

        public override string ToString()
        {
            return $"{Surname}, {FirstName}".Trim();
        }

        public void WriteToCsv(TextWriter writer)
        {
            writer.WriteLine(ToCsv());
        }

        public string ToCsv()
        {
            var address = Address ?? string.Empty;
            address = address.Replace("\n", "\\n").Replace("\r", "");

            return string.Join(',', new[]
            {
                Id.ToString(),
                FirstName ?? string.Empty,
                Surname ?? string.Empty,
                PhoneNumber ?? string.Empty,
                "\"" + address + "\""
            });
        }
    }
}
