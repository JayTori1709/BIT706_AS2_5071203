using Assessment2.Core;
using System.Windows;

namespace Assessment2.App
{
    public partial class AnimalEditorWindow : Window
    {
        public Animal Animal { get; private set; }

        private bool isEditMode;

        public AnimalEditorWindow()
        {
            InitializeComponent();
            this.Title = "Add Animal";
            Animal = new Animal();
            isEditMode = false;
        }

        public AnimalEditorWindow(Animal animalToEdit)
        {
            InitializeComponent();
            this.Title = "Edit Animal";
            Animal = animalToEdit;
            txtName.Text = Animal.Name;
            txtSpecies.Text = Animal.Species;
            txtBreed.Text = Animal.Breed;
            isEditMode = true;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtSpecies.Text))
            {
                MessageBox.Show("Please enter at least a name and species.", "Missing Info", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Animal.Name = txtName.Text.Trim();
            Animal.Species = txtSpecies.Text.Trim();
            Animal.Breed = txtBreed.Text.Trim();

            // Save data
            Store.Instance.SaveData();

            this.DialogResult = true;
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
