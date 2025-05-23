using System.Windows;
using Assessment2.App.Services;
using Assessment2.App.ViewModels;

namespace Assessment2.App.Views
{
    public partial class AnimalEditor : Window
    {
        public AnimalEditor()
        {
            InitializeComponent();
            DataContext = new AnimalViewModel(
                new CsvAnimalService(),
                new CsvCustomerService()
            );
        }
    }
}
