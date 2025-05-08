// CustomerEditorWindow.xaml.cs
using System.Windows;
using Assessment2.App.BusinessLayer;

namespace Assessment2.App.BusinessLayer
{
    public partial class CustomerEditorWindow : Window
    {
        public Customer? Customer { get; private set; } // Made nullable

        public CustomerEditorWindow(Customer? customer = null)
        {
            InitializeComponent();
            Customer = customer ?? new Customer();
            DataContext = Customer; // Set DataContext for binding
        }

        private void OnSave(object sender, RoutedEventArgs e)
        {
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
