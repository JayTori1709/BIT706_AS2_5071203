using Assessment2.App.BusinessLayer;
using Xunit;

namespace Assessment2.Tests
{
    public class AnimalTests
    {
        [Theory]
        [InlineData("Bob", "Dog", "Male", 1, true)]
        [InlineData(null, "Dog", "Male", 1, false)]
        [InlineData("Bob", null, "Male", 1, false)]
        [InlineData("Bob", "Dog", null, 1, false)]
        [InlineData("Bob", "Dog", "Male", 0, false)]
        public void CheckIfValidChecksProperties(string? name, string? type, string? sex, int owner, bool isValid)
        {
            var animal = new Animal { Name = name, Type = type, Sex = sex, OwnerId = owner };
            var result = animal.CheckIfValid();
            Assert.Equal(isValid, result);
        }

        [Fact]
        public void ToStringContainsCorrectDetails()
        {
            var animal = new Animal { Name = "Bobby", Type = "Cat" };
            var textValue = animal.ToString();
            Assert.Equal("Bobby [Cat]", textValue);
        }

        [Fact]
        public void SaveToCSV_ReturnsCorrectFormat()
        {
            var animal = new Animal
            {
                Id = 1,
                Name = "Max",
                Type = "Dog",
                Breed = "", // Breed is optional
                Sex = "Male",
                OwnerId = 2
            };

            var csv = animal.ToCsv();

            // Note the empty value for Breed
            Assert.Equal("1,Max,Dog,,Male,2", csv);
        }

        [Fact]
        public void LoadFromCSV_ParsesCorrectly()
        {
            var csv = "2,Bella,Cat,Shorthair,Female,1";
            var animal = Animal.FromCsv(csv);
            Assert.Equal(2, animal.Id);
            Assert.Equal("Bella", animal.Name);
            Assert.Equal("Cat", animal.Type);
            Assert.Equal("Shorthair", animal.Breed);
            Assert.Equal("Female", animal.Sex);
            Assert.Equal(1, animal.OwnerId);
        }

        [Fact]
        public void CheckIfValid_EmptyType_ReturnsFalse()
        {
            var animal = new Animal { Name = "Whiskers", Type = "", Sex = "Female", OwnerId = 1 };
            Assert.False(animal.CheckIfValid());
        }
    }
}
