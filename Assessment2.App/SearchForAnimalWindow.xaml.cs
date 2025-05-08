// SearchForAnimalWindow.xaml.cs
using System.Windows;
using System.Windows.Controls;
using Assessment2.App.BusinessLayer;

namespace Assessment2.App
{
    public partial class SearchForAnimalWindow : Window
    {
        private readonly Store dataStore;
        private Customer? customer;

        public SearchForAnimalWindow(Store dataStore)
        {
            InitializeComponent();
            this.dataStore = dataStore;
        }

        public Animal? Animal { get; private set; }

        public Customer? Customer
        {
            get => customer;
            set
            {
                customer = value;
                if (customer != null)
                {
                    var animals = dataStore.FindAnimals(customer.Id);
                    searchResults.Items.Clear();
                    foreach (var animal in animals)
                    {
                        searchResults.Items.Add(new ListBoxItem { Content = animal });
                    }
                }
                else
                {
                    searchResults.Items.Clear();
                }
            }
        }

        private void OnCancel(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void OnSelect(object sender, RoutedEventArgs e)
        {
            if (searchResults.SelectedItem is ListBoxItem selectedItem)
            {
                DialogResult = true;
                Animal = selectedItem.Content as Animal;
                Close();
            }
        }
    }
}