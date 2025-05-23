using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Assessment2.App.BusinessLayer;
using Assessment2.App.Services;

namespace Assessment2.App.ViewModels
{
    public class CustomerViewModel : INotifyPropertyChanged
    {
        private readonly ICustomerService _service;

        public ObservableCollection<Customer> Customers { get; set; }
        public Customer? SelectedCustomer { get; set; }

        public ICommand AddCustomerCommand { get; }
        public ICommand EditCustomerCommand { get; }
        public ICommand DeleteCustomerCommand { get; }

        public CustomerViewModel(ICustomerService service)
        {
            _service = service;
            Customers = new ObservableCollection<Customer>(_service.LoadCustomers());

            AddCustomerCommand = new RelayCommand(AddCustomer);
            EditCustomerCommand = new RelayCommand(EditCustomer, () => SelectedCustomer != null);
            DeleteCustomerCommand = new RelayCommand(DeleteCustomer, () => SelectedCustomer != null);
        }

        private void AddCustomer()
        {
            var customer = new Customer { FirstName = "New", Surname = "Customer", PhoneNumber = "000-0000" };
            Customers.Add(customer);
            _service.SaveCustomers(Customers.ToList());
        }

        private void EditCustomer()
        {
            _service.SaveCustomers(Customers.ToList());
        }

        private void DeleteCustomer()
        {
            if (SelectedCustomer != null)
            {
                Customers.Remove(SelectedCustomer);
                _service.SaveCustomers(Customers.ToList());
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
