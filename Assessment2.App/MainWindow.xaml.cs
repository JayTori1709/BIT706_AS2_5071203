// MainWindow.xaml.cs
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Assessment2.App.BusinessLayer;

namespace Assessment2.App
{
    public partial class MainWindow : Window
    {
        private readonly Store dataStore = Store.Instance;
        public ObservableCollection<Customer> Customers { get; set; }
        public ObservableCollection<Animal> Animals { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Customers = new ObservableCollection<Customer>(dataStore.Customers);
            Animals = new ObservableCollection<Animal>(dataStore.Animals);
            lstCustomers.ItemsSource = Customers;
            lstAnimals.ItemsSource = Animals;
            DataContext = this; // Set DataContext for binding if needed later
        }

        private void EditAnimal(Animal? animal)
        {
            var window = new AnimalEditorWindow(dataStore, animal) // Pass the animal to edit
            {
                Owner = this,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
            };
            if (window.ShowDialog() == true && window.Animal != null)
            {
                if (animal == null) // This condition will now likely be false in edit mode
                {
                    Animals.Add(window.Animal);
                    dataStore.Animals.Add(window.Animal);
                }
                else
                {
                    // Assuming AnimalEditorWindow updates the passed animal object
                    Animals.RefreshCollection();
                }
                dataStore.SaveData();
            }
        }
        private void EditCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (lstCustomers.SelectedItem is Customer selectedCustomer)
            {
                var customerEditor = new CustomerEditorWindow(selectedCustomer);
                if (customerEditor.ShowDialog() == true && customerEditor.Customer != null)
                {
                    var updatedCustomer = customerEditor.Customer;
                    int index = Customers.IndexOf(selectedCustomer);
                    if (index != -1)
                    {
                        Customers[index] = updatedCustomer;
                        dataStore.UpdateCustomer(selectedCustomer, updatedCustomer);
                        Customers.RefreshCollection();
                    }
                }
            }
        }

        private void AddAnimal_Click(object sender, RoutedEventArgs e)
        {
            var window = new AnimalEditorWindow(dataStore, null) // Pass null for a new animal
            {
                Owner = this,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
            };
            if (window.ShowDialog() == true && window.Animal != null)
            {
                Animals.Add(window.Animal);
                dataStore.Animals.Add(window.Animal);
                dataStore.SaveData();
            }
        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            var customerEditor = new CustomerEditorWindow();
            if (customerEditor.ShowDialog() == true && customerEditor.Customer != null)
            {
                Customers.Add(customerEditor.Customer);
                dataStore.AddCustomer(customerEditor.Customer);
            }
        }

        private void EditAnimal_Click(object sender, RoutedEventArgs e)
        {
            if (lstAnimals.SelectedItem is Animal selectedAnimal)
            {
                EditAnimal(selectedAnimal);
            }
            else
            {
                MessageBox.Show("Please select an animal to edit.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void OnEditAnimal(object sender, RoutedEventArgs e)
        {
            if (lstCustomers.SelectedItem is Customer selectedCustomer)
            {
                var animalSearch = new SearchForAnimalWindow(dataStore)
                {
                    Customer = selectedCustomer,
                    Owner = this,
                    WindowStartupLocation = WindowStartupLocation.CenterOwner,
                };

                if (animalSearch.ShowDialog() == true && animalSearch.Animal != null)
                {
                    EditAnimal(animalSearch.Animal);
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to find their animals.", "No Customer Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void OnEditCustomer(object sender, RoutedEventArgs e)
        {
            EditCustomer_Click(sender, e); // Reuse the existing edit customer logic
        }

        private void OnExitApplication(object sender, RoutedEventArgs e)
        {
            dataStore.SaveData(); // Ensure data is saved on exit
            Close();
        }
    }
}
    // Helper extension method to refresh ObservableCollection
    public static class ObservableCollectionExtensions
{
    public static void RefreshCollection<T>(this ObservableCollection<T> collection)
    {
        collection.CollectionView().Refresh();
    }

    public static ICollectionView CollectionView<T>(this ObservableCollection<T> collection)
    {
        return System.Windows.Data.CollectionViewSource.GetDefaultView(collection);
    }
}