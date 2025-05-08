using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Assessment2.App.BusinessLayer;

namespace Assessment2.App
{
    public partial class SearchForCustomerWindow : Window
    {
        public Customer SelectedCustomer { get; private set; }

        private List<Customer> allCustomers;

        public SearchForCustomerWindow()
        {
            InitializeComponent();
            allCustomers = Store.Instance.Customers;
            customerListBox.ItemsSource = allCustomers;
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string query = searchBox.Text.ToLower();
            var filtered = allCustomers
                .Where(c => c.FirstName.ToLower().Contains(query)
                         || c.Surname.ToLower().Contains(query)
                         || c.PhoneNumber.ToLower().Contains(query))
                .ToList();
            customerListBox.ItemsSource = filtered;
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            if (customerListBox.SelectedItem is Customer customer)
            {
                SelectedCustomer = customer;
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Please select a customer.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
