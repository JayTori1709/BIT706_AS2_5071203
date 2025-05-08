using Assessment2.Core;
using System.Windows;

namespace Assessment2.App
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Store.Instance.LoadData(); // Load data on app start
            RefreshCustomers();
        }

        private void RefreshCustomers()
        {
            CustomerListView.ItemsSource = null;
            CustomerListView.ItemsSource = Store.Instance.Customers;
        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            var editor = new CustomerEditorWindow();
            if (editor.ShowDialog() == true)
            {
                Store.Instance.Customers.Add(editor.Customer);
                Store.Instance.SaveData(); // Save changes
                RefreshCustomers();
            }
        }

        private void EditCustomer_Click(object sender, RoutedEventArgs e)
        {
            var selectedCustomer = (Customer)CustomerListView.SelectedItem;
            if (selectedCustomer != null)
            {
                var editor = new CustomerEditorWindow(selectedCustomer);
                if (editor.ShowDialog() == true)
                {
                    Store.Instance.SaveData(); // Save changes
                    RefreshCustomers();
                }
            }
        }
    }
}
