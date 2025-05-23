using System.Windows;
using Assessment2.App.Services;
using Assessment2.App.ViewModels;

namespace Assessment2.App.Views
{
    public partial class CustomerEditor : Window
    {
        public CustomerEditor()
        {
            InitializeComponent();
            DataContext = new CustomerViewModel(new CsvCustomerService());
        }
    }
}
