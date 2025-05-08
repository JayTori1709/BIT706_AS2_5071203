using System.Windows;
using Assessment2.App.Models;
using Assessment2.App.BusinessLayer;

namespace Assessment2.App
{
    public partial class CustomerEditorWindow : Window
    {
        private readonly Store dataStore;
        private Customer? customer;

        public CustomerEditorWindow(Store dataStore)
        {
            InitializeComponent();
            this.dataStore = dataStore;
        }

        public Customer? Customer
        {
            get => customer;
            set
            {
                customer = value;
                firstName.Text = customer?.FirstName ?? "";
                surname.Text = customer?.Surname ?? "";
                phoneNumber.Text = customer?.PhoneNumber ?? "";
                address.Text = customer?.Address ?? "";
            }
        }

        private void OnSave(object sender, RoutedEventArgs e)
        {
            if (customer == null)
            {
                var newCustomer = new Customer
                {
                    FirstName = firstName.Text,
                    Surname = surname.Text,
                    PhoneNumber = phoneNumber.Text,
                    Address = address.Text
                };

                if (!newCustomer.CheckIfValid())
                {
                    MessageBox.Show("Invalid data.");
                    return;
                }

                dataStore.AddCustomer(newCustomer);
            }
            else
            {
                customer.FirstName = firstName.Text;
                customer.Surname = surname.Text;
                customer.PhoneNumber = phoneNumber.Text;
                customer.Address = address.Text;

                if (!customer.CheckIfValid())
                {
                    MessageBox.Show("Invalid data.");
                    return;
                }
            }

            dataStore.SaveData("data.json");
            Close();
        }

        private void OnCancel(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
