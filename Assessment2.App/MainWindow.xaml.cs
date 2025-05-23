using System;
using System.Windows;
using Assessment2.App.Views;

namespace Assessment2.App
{
    /// <summary>
    /// Main entry point for the application.
    /// This launches the MVVM-based CustomerEditor window.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Launch the CustomerEditor (MVVM-based window)
            var customerWindow = new CustomerEditor
            {
                Owner = this,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            customerWindow.ShowDialog();

            // Optionally close MainWindow if CustomerEditor is your primary view
            this.Close();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }
    }
}
