using Assessment2.App;
using Assessment2.Core;
using System.Windows;

namespace Assessment2.App
{
    public partial class MainWindow : Window
    {
        private readonly Store dataStore = Store.Instance;

        public MainWindow()
        {
            InitializeComponent();
            dataStore.LoadData();
        }

        private void EditAnimal(Animal? animal)
        {
            var window = new AnimalEditorWindow(dataStore)
            {
                Animal = animal,
                Owner = this,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
            };
            if (window.ShowDialog() == true)
            {
                dataStore.SaveData(); // Save after adding/editing
            }
        }

        private void EditCustomer(Customer? customer)
        {
            var window = new CustomerEditorWindow(dataStore)
            {
                Customer = customer,
                Owner = this,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
            };
            if (window.ShowDialog() == true)
            {
                dataStore.SaveData(); // Save after adding/editing
            }
        }

        private void OnAddAnimal(object sender, RoutedEventArgs e)
        {
            EditAnimal(null);
        }

        private void OnAddCustomer(object sender, RoutedEventArgs e)
        {
            EditCustomer(null);
        }

        private void OnEditAnimal(object sender, RoutedEventArgs e)
        {
            var customerSearch = new SearchForCustomerWindow(dataStore)
            {
                Owner = this,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
            };

            if (customerSearch.ShowDialog() != true) return;
            var animalSearch = new SearchForAnimalWindow(dataStore)
            {
                Customer = customerSearch.Customer,
                Owner = this,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
            };

            if (animalSearch.ShowDialog() == true)
                EditAnimal(animalSearch.Animal);
        }

        private void OnEditCustomer(object sender, RoutedEventArgs e)
        {
            var customerSearch = new SearchForCustomerWindow(dataStore)
            {
                Owner = this,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
            };

            if (customerSearch.ShowDialog() == true)
            {
                EditCustomer(customerSearch.Customer);
            }
        }

        private void OnExitApplication(object sender, RoutedEventArgs e)
        {
            dataStore.SaveData(); // Ensure data is saved on exit
            Close();
        }
    }
}
