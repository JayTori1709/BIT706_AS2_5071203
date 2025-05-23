using System;
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

            // Inject the real CSV service (IoC-style, manual for now)
            DataContext = new CustomerViewModel(new CsvCustomerService());
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }
    }
}
