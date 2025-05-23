using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Assessment2.App.BusinessLayer;
using Assessment2.App.Services;

namespace Assessment2.App.ViewModels
{
    public class CustomerViewModel : INotifyPropertyChanged
    {
        private readonly ICustomerService _customerService;

        public ObservableCollection<Customer> Customers { get; set; }
        public Customer? SelectedCustomer { get; set; }

        // Commands
        public ICommand AddCustomerCommand { get; }
        public ICommand EditCustomerCommand { get; }
        public ICommand DeleteCustomerCommand { get; }

        public CustomerViewModel(ICustomerService customerService)
        {
            _customerService = customerService;
            var loaded = _customerService.LoadCustomers();
            Customers = new ObservableCollection<Customer>(loaded);

            AddCustomerCommand = new RelayCommand(AddCustomer);
            EditCustomerCommand = new RelayCommand(EditCustomer, CanEditOrDelete);
            DeleteCustomerCommand = new RelayCommand(DeleteCustomer, CanEditOrDelete);
        }

        private void AddCustomer()
        {
            var newCustomer = new Customer
            {
                FirstName = "New",
                Surname = "Customer",
                PhoneNumber = "0000"
            };
            Customers.Add(newCustomer);
            _customerService.SaveCustomers(Customers.ToList());
            OnPropertyChanged(nameof(Customers));
        }

        private void EditCustomer()
        {
            _customerService.SaveCustomers(Customers.ToList());
            OnPropertyChanged(nameof(Customers));
        }

        private void DeleteCustomer()
        {
            if (SelectedCustomer != null)
            {
                Customers.Remove(SelectedCustomer);
                _customerService.SaveCustomers(Customers.ToList());
                OnPropertyChanged(nameof(Customers));
            }
        }

        private bool CanEditOrDelete()
        {
            return SelectedCustomer != null;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
