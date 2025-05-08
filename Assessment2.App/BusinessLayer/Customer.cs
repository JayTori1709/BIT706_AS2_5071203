// Customer.cs
using System;
using System.ComponentModel;
using System.IO;
using Assessment2.App.BusinessLayer;

namespace Assessment2.App.BusinessLayer
{
    public class Customer : INotifyPropertyChanged
    {
        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        private string? _firstName;
        public string? FirstName
        {
            get => _firstName;
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged(nameof(FirstName));
                    OnPropertyChanged(nameof(FullName)); // Update FullName on change
                }
            }
        }

        private string? _surname;
        public string? Surname
        {
            get => _surname;
            set
            {
                if (_surname != value)
                {
                    _surname = value;
                    OnPropertyChanged(nameof(Surname));
                    OnPropertyChanged(nameof(FullName)); // Update FullName on change
                }
            }
        }

        private string? _phoneNumber;
        public string? PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                if (_phoneNumber != value)
                {
                    _phoneNumber = value;
                    OnPropertyChanged(nameof(PhoneNumber));
                }
            }
        }

        private string? _address;
        public string? Address
        {
            get => _address;
            set
            {
                if (_address != value)
                {
                    _address = value;
                    OnPropertyChanged(nameof(Address));
                }
            }
        }

        public string FullName => $"{Surname}, {FirstName}".Trim();

        // Constructor to match the LoadData in Store.cs
        public Customer() { }

        public static Customer FromCsv(string line)
        {
            var parts = line.Split(',');
            return new Customer
            {
                Id = int.Parse(parts[0]),
                FirstName = parts[1],
                Surname = parts[2],
                PhoneNumber = parts[3],
                Address = parts[4][1..^1].Replace("\\n", Environment.NewLine),
            };
        }

        public static void WriteHeaderToCsv(TextWriter writer)
        {
            writer.WriteLine("Id,First Name,Surname,Phone,Address");
        }

        public bool CheckIfValid()
        {
            return !(string.IsNullOrEmpty(FirstName)
                     || string.IsNullOrEmpty(PhoneNumber)
                     || string.IsNullOrEmpty(Surname));
        }

        public override string ToString()
        {
            return FullName;
        }

        public void WriteToCsv(TextWriter writer)
        {
            var address = Address ?? string.Empty;
            address = address.Replace("\n", "\\n").Replace("\r", "");
            writer.WriteLine(string.Join(',', new[]
            {
                Id.ToString(),
                FirstName ?? string.Empty,
                Surname ?? string.Empty,
                PhoneNumber ?? string.Empty,
                $"\"{address}\"",
            }));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string? propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}