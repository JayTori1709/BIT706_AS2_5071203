using System.Windows;
using Assessment2.App.ViewModels;

namespace Assessment2.App.Views
{
    public partial class AddAnimalWindow : Window
    {
        public AddAnimalWindow(AddAnimalViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;

            // Subscribe to the ViewModel's RequestClose event
            viewModel.RequestClose += OnRequestClose;
        }

        private void OnRequestClose()
        {
            // Close the window when the event is raised
            Close();
        }
    }
}
