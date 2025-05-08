// Animal.cs
using System;
using System.ComponentModel;
using System.IO;
using Assessment2.App.BusinessLayer;

namespace Assessment2.App.BusinessLayer
{
    public class Animal : INotifyPropertyChanged
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

        private string? _name;
        public string? Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        private string? _type;
        public string? Type
        {
            get => _type;
            set
            {
                if (_type != value)
                {
                    _type = value;
                    OnPropertyChanged(nameof(Type));
                }
            }
        }

        private string? _breed;
        public string? Breed
        {
            get => _breed;
            set
            {
                if (_breed != value)
                {
                    _breed = value;
                    OnPropertyChanged(nameof(Breed));
                }
            }
        }

        private string? _sex;
        public string? Sex
        {
            get => _sex;
            set
            {
                if (_sex != value)
                {
                    _sex = value;
                    OnPropertyChanged(nameof(Sex));
                }
            }
        }

        private int _ownerId;
        public int OwnerId
        {
            get => _ownerId;
            set
            {
                if (_ownerId != value)
                {
                    _ownerId = value;
                    OnPropertyChanged(nameof(OwnerId));
                }
            }
        }

        // Constructor to match the LoadData in Store.cs
        public Animal() { }

        public static Animal FromCsv(string line)
        {
            var parts = line.Split(',');
            return new Animal
            {
                Id = int.Parse(parts[0]),
                Name = parts[1],
                Type = parts[2],
                Breed = parts[3],
                Sex = parts[4],
                OwnerId = int.Parse(parts[5]),
            };
        }

        public static void WriteHeaderToCsv(TextWriter writer)
        {
            writer.WriteLine("Id,Name,Type,Breed,Sex,OwnerId");
        }

        public bool CheckIfValid()
        {
            return !(string.IsNullOrEmpty(Name)
                     || string.IsNullOrEmpty(Type)
                     || string.IsNullOrEmpty(Sex)
                     || (OwnerId == 0));
        }

        public override string ToString()
        {
            return $"{Name} [{Type}]";
        }

        public void WriteToCsv(TextWriter writer)
        {
            writer.WriteLine(string.Join(',', new[]
            {
                Id.ToString(),
                Name ?? string.Empty,
                Type ?? string.Empty,
                Breed ?? string.Empty,
                Sex ?? string.Empty,
                OwnerId.ToString(),
            }));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string? propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}