using Assessment2.Core; // For accessing the Customer class
using System.Windows;

namespace Assessment2.App
{
    public partial class CustomerEditorWindow : Window
    {
        public Customer Customer { get; private set; }

        private bool isEditMode;

        // Constructor for creating a new customer
        public CustomerEditorWindow()
        {
            InitializeComponent();
            this.Title = "Add Customer";
            Customer = new Customer();
            isEditMode = false;
        }

        // Constructor for editing an existing customer
        public CustomerEditorWindow(Customer customerToEdit)
        {
            InitializeComponent();
            this.Title = "Edit Customer";
            Customer = customerToEdit;
            txtName.Text = Customer.Name;
            txtPhone.Text = Customer.Phone;
            isEditMode = true;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Basic input validation
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Please enter both a name and a phone number.", "Missing Info", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Assign values to the Customer object
            Customer.Name = txtName.Text.Trim();
            Customer.Phone = txtPhone.Text.Trim();

            // Save to storage
            Store.Instance.SaveData();

            this.DialogResult = true;
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
