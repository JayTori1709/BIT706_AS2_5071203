// AnimalEditorWindow.xaml.cs
using System.Windows;
using Assessment2.App.BusinessLayer;

namespace Assessment2.App
{

    public partial class AnimalEditorWindow : Window
    {
        public Animal? Animal { get; set; }
        private readonly Store dataStore;

        public AnimalEditorWindow(Store dataStore, Animal? animal = null)
        {
            InitializeComponent();
            this.dataStore = dataStore;
            Animal = animal ?? new Animal();
            DataContext = Animal; // For data binding in XAML
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