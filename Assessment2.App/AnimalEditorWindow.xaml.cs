using Assessment2.Core; // Access to the Animal class
using System.Windows;

namespace Assessment2.App
{
    public partial class AnimalEditorWindow : Window
    {
        public Animal Animal { get; private set; }

        private bool isEditMode;

        // Constructor for adding a new animal
        public AnimalEditorWindow()
        {
            InitializeComponent();
            this.Title = "Add Animal";
            Animal = new Animal();
            isEditMode = false;
        }

        // Constructor for editing an existing animal
        public AnimalEditorWindow(Animal animalToEdit)
        {
            InitializeComponent();
            this.Title = "Edit Animal";
            Animal = animalToEdit;
            txtName.Text = Animal.Name;
            txtSpecies.Text = Animal.Species;
            txtBreed.Text = Animal.Breed;
            txtAge.Text = Animal.Age.ToString();
            isEditMode = true;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Basic validation
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtSpecies.Text) ||
                string.IsNullOrWhiteSpace(txtBreed.Text) ||
                !int.TryParse(txtAge.Text, out int parsedAge))
            {
                MessageBox.Show("Please enter valid details. Age must be a number.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Animal.Name = txtName.Text.Trim();
            Animal.Species = txtSpecies.Text.Trim();
            Animal.Breed = txtBreed.Text.Trim();
            Animal.Age = parsedAge;

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
