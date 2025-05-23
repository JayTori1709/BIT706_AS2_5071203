using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assessment2.App.BusinessLayer;

namespace Assessment2.App.Repositories
{
    public interface IAnimalRepository
    {
        IEnumerable<Animal> GetAll();
        IEnumerable<Animal> FindByOwner(int ownerId);
        Animal? GetById(int animalId);
        void Add(Animal animal);
        void Update(Animal animal);
        void Delete(int animalId);
    }
}
