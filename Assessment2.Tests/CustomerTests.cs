using System.IO;
using Assessment2.App.BusinessLayer;
using Xunit;

namespace Assessment2.Tests
{
    public class CustomerTests
    {
        [Fact]
        public void LoadFromCSV_ParsesCorrectly()
        {
            string csv = "1,Alice,Smith,555-1234,\"123 Main St\\nCity\"";
            var customer = Customer.FromCsv(csv);

            Assert.Equal(1, customer.Id);
            Assert.Equal("Alice", customer.FirstName);
            Assert.Equal("Smith", customer.Surname);
            Assert.Equal("555-1234", customer.PhoneNumber);
            Assert.Equal("123 Main St\nCity", customer.Address);
        }

        [Fact]
        public void SaveToCSV_ReturnsCorrectFormat()
        {
            var customer = new Customer
            {
                Id = 1,
                FirstName = "Alice",
                Surname = "Smith",
                PhoneNumber = "555-1234",
                Address = "123 Main St\nCity"
            };

            using var writer = new StringWriter();
            customer.WriteToCsv(writer);
            var output = writer.ToString().Trim();

            Assert.Equal("1,Alice,Smith,555-1234,\"123 Main St\\nCity\"", output);
        }
    }
}
