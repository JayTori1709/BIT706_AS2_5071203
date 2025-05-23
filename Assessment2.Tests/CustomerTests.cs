using Assessment2.App.BusinessLayer;
using Xunit;

namespace Assessment2.Tests
{
    public class CustomerTests
    {
        [Theory]
        [InlineData("John", "Doe", "123-4567", true)]
        [InlineData(null, "Doe", "123-4567", false)]
        [InlineData("John", null, "123-4567", false)]
        [InlineData("John", "Doe", null, false)]
        public void CheckIfValidChecksProperties(string? firstName, string? surname, string? phoneNumber, bool isValid)
        {
            var customer = new Customer { FirstName = firstName, Surname = surname, PhoneNumber = phoneNumber };
            var result = customer.CheckIfValid();
            Assert.Equal(isValid, result);
        }

        [Fact]
        public void ToStringContainsCorrectDetails()
        {
            var customer = new Customer { FirstName = "John", Surname = "Doe" };
            var textValue = customer.ToString();
            Assert.Equal("Doe, John", textValue);
        }

        [Fact]
        public void SaveToCSV_ReturnsCorrectFormat()
        {
            var customer = new Customer
            {
                Id = 1,
                FirstName = "Alice",
                Surname = "Smith",
                PhoneNumber = "555-1234"
            };

            var csv = customer.ToCsv();

            // Expect empty quoted address at the end
            Assert.Equal("1,Alice,Smith,555-1234,\"\"", csv);
        }

        [Fact]
        public void LoadFromCSV_ParsesCorrectly()
        {
            var csv = "2,Bob,White,444-5678,\"123 Farm Road\"";
            var customer = Customer.FromCsv(csv);
            Assert.Equal(2, customer.Id);
            Assert.Equal("Bob", customer.FirstName);
            Assert.Equal("White", customer.Surname);
            Assert.Equal("444-5678", customer.PhoneNumber);
            Assert.Equal("123 Farm Road", customer.Address);
        }

        [Fact]
        public void CheckIfValid_EmptyName_ReturnsFalse()
        {
            var customer = new Customer { FirstName = "", Surname = "", PhoneNumber = "0000" };
            Assert.False(customer.CheckIfValid());
        }
    }
}
