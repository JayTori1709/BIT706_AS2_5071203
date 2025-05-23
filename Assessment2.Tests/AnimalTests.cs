using System.IO;
using Assessment2.App.BusinessLayer;
using Xunit;

namespace Assessment2.Tests
{
    public class AnimalTests
    {
        [Fact]
        public void LoadFromCSV_ParsesCorrectly()
        {
            string csv = "1,Max,Dog,Labrador,Male,2";
            var animal = Animal.FromCsv(csv);

            Assert.Equal(1, animal.Id);
            Assert.Equal("Max", animal.Name);
            Assert.Equal("Dog", animal.Type);
            Assert.Equal("Labrador", animal.Breed);
            Assert.Equal("Male", animal.Sex);
            Assert.Equal(2, animal.OwnerId);
        }

        [Fact]
        public void SaveToCSV_ReturnsCorrectFormat()
        {
            var animal = new Animal
            {
                Id = 1,
                Name = "Max",
                Type = "Dog",
                Breed = "Labrador",
                Sex = "Male",
                OwnerId = 2
            };

            using var writer = new StringWriter();
            animal.WriteToCsv(writer);
            var output = writer.ToString().Trim();

            Assert.Equal("1,Max,Dog,Labrador,Male,2", output);
        }
    }
}
