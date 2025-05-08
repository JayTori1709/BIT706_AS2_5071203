using System.Windows;
using Assessment2.App.BusinessLayer; 

namespace Assessment2.App.BusinessLayer
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

      private void EditCustomer_Click(object sender, RoutedEventArgs e)
{
    var selectedCustomer = lstCustomers.SelectedItem as Customer;
    if (selectedCustomer != null)
    {
        var customerEditor = new CustomerEditorWindow(selectedCustomer);
        if (customerEditor.ShowDialog() == true)
        {
            Store.Instance.UpdateCustomer(selectedCustomer, customerEditor.Customer);
            lstCustomers.Items.Refresh(); // Refresh the list
        }
    }
}

        private void OnAddAnimal(object sender, RoutedEventArgs e)
        {
            EditAnimal(null);
        }

       private void AddCustomer_Click(object sender, RoutedEventArgs e)
{
    var customerEditor = new CustomerEditorWindow();
    if (customerEditor.ShowDialog() == true)
    {
        Store.Instance.AddCustomer(customerEditor.Customer);
        lstCustomers.Items.Refresh(); // Refresh the list
    }
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
