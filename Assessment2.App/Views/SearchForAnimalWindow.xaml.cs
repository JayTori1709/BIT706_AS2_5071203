using Assessment2.App.ViewModels;
using System.Windows;

namespace Assessment2.App.Views
{
    public partial class SearchForAnimalWindow : Window
    {
        public SearchForAnimalWindow(SearchForAnimalViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;

            viewModel.RequestClose += OnRequestClose;
        }

        public void LoadAnimals(int ownerId)
        {
            if (DataContext is SearchForAnimalViewModel viewModel)
            {
                viewModel.LoadAnimalsByOwner(ownerId);
            }
        }

        private void OnRequestClose()
        {
            DialogResult = true;
            Close();
        }
    }
}
