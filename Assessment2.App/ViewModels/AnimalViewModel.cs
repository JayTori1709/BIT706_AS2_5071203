using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
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
            EditAnimalCommand = new RelayCommand(EditAnimal, CanEditOrDelete);
            DeleteAnimalCommand = new RelayCommand(DeleteAnimal, CanEditOrDelete);
        }

        private void AddAnimal()
        {
            if (SelectedCustomer == null) return;

            var animal = new Animal
            {
                Name = "New Animal",
                Type = "Type",
                Sex = "Unknown",
                OwnerId = SelectedCustomer.Id
            };

            Animals.Add(animal);
            _animalService.SaveAnimals(Animals.ToList());
            OnPropertyChanged(nameof(Animals));
        }

        private void EditAnimal()
        {
            _animalService.SaveAnimals(Animals.ToList());
            OnPropertyChanged(nameof(Animals));
        }

        private void DeleteAnimal()
        {
            if (SelectedAnimal == null)
                return;

            var result = MessageBox.Show(
                $"Are you sure you want to delete '{SelectedAnimal.Name}'?",
                "Confirm Deletion",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                Animals.Remove(SelectedAnimal);
                _animalService.SaveAnimals(Animals.ToList());
                OnPropertyChanged(nameof(Animals));
            }
            else
            {
                // Optionally, notify cancellation
            }
        }

        private bool CanEditOrDelete()
        {
            return SelectedAnimal != null;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
