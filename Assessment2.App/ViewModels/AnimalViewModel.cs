using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Linq;
using Assessment2.App.BusinessLayer;
using Assessment2.App.Services;

namespace Assessment2.App.ViewModels
{
    public class AnimalViewModel : INotifyPropertyChanged
    {
        private readonly IAnimalService _animalService;
        private readonly ICustomerService _customerService;

        public ObservableCollection<Animal> Animals { get; set; }
        public ObservableCollection<Customer> Customers { get; set; }

        public Animal? SelectedAnimal { get; set; }
        public Customer? SelectedCustomer { get; set; }

        public ICommand AddAnimalCommand { get; }
        public ICommand EditAnimalCommand { get; }
        public ICommand DeleteAnimalCommand { get; }

        public AnimalViewModel(IAnimalService animalService, ICustomerService customerService)
        {
            _animalService = animalService;
            _customerService = customerService;

            Animals = new ObservableCollection<Animal>(_animalService.LoadAnimals());
            Customers = new ObservableCollection<Customer>(_customerService.LoadCustomers());

            AddAnimalCommand = new RelayCommand(AddAnimal);
            EditAnimalCommand = new RelayCommand(EditAnimal, () => SelectedAnimal != null);
            DeleteAnimalCommand = new RelayCommand(DeleteAnimal, () => SelectedAnimal != null);
        }

        private void AddAnimal()
        {
            if (SelectedCustomer == null) return;
            var animal = new Animal
            {
                Name = "New Pet",
                Type = "Type",
                Breed = "Breed",
                Sex = "Unknown",
                OwnerId = SelectedCustomer.Id
            };
            Animals.Add(animal);
            _animalService.SaveAnimals(Animals.ToList());
        }

        private void EditAnimal()
        {
            _animalService.SaveAnimals(Animals.ToList());
        }

        private void DeleteAnimal()
        {
            if (SelectedAnimal == null) return;

            var confirm = MessageBox.Show(
                $"Are you sure you want to delete '{SelectedAnimal.Name}'?",
                "Confirm Delete",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning
            );

            if (confirm == MessageBoxResult.Yes)
            {
                Animals.Remove(SelectedAnimal);
                _animalService.SaveAnimals(Animals.ToList());
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
