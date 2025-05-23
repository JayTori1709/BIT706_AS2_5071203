using System.Collections.Generic;
using Assessment2.App.BusinessLayer;

namespace Assessment2.App.Services
{
    public interface IAnimalService
    {
        List<Animal> LoadAnimals();
        void SaveAnimals(List<Animal> animals);
    }
}
