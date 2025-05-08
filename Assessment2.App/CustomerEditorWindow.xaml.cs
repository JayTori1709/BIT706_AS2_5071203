using System.Windows;
using Assessment2.App.BusinessLayer;

namespace Assessment2.App.BusinessLayer
{
    public partial class CustomerEditorWindow : Window
    {
        public Customer Customer { get; private set; }

        public CustomerEditorWindow(Customer? customer = null)
        {
            InitializeComponent();
            Customer = customer ?? new Customer();

            firstName.Text = Customer.FirstName ?? string.Empty;
            surname.Text = Customer.Surname ?? string.Empty;
            phoneNumber.Text = Customer.PhoneNumber ?? string.Empty;
            address.Text = Customer.Address ?? string.Empty;
            this.DataContext = Customer;
        }

        private void OnSave(object sender, RoutedEventArgs e)
        {
            Customer.FirstName = firstName.Text;
            Customer.Surname = surname.Text;
            Customer.PhoneNumber = phoneNumber.Text;
            Customer.Address = address.Text;
            DialogResult = true;
            Close();
        }

        private void OnCancel(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
