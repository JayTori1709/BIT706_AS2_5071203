// Microchip.cs
using System.ComponentModel;
using Assessment2.App.BusinessLayer;

namespace Assessment2.App.BusinessLayer
{
    public class Microchip : INotifyPropertyChanged
    {
        private string _chipId = string.Empty;
        public string ChipId
        {
            get => _chipId;
            set
            {
                if (_chipId != value)
                {
                    _chipId = value;
                    OnPropertyChanged(nameof(ChipId));
                }
            }
        }

        private string _manufacturer = string.Empty;
        public string Manufacturer
        {
            get => _manufacturer;
            set
            {
                if (_manufacturer != value)
                {
                    _manufacturer = value;
                    OnPropertyChanged(nameof(Manufacturer));
                }
            }
        }

        // Parameterless constructor
        public Microchip() { }

        public override string ToString()
        {
            return $"{Manufacturer} ({ChipId})";
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string? propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}