using System.Collections.ObjectModel;
using System.Windows;
using WpfApp1.Model;
using WpfApp1.View;
using WpfApp1.ViewModel;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel viewModel;

        public MainWindow()
        {
            viewModel = new MainWindowViewModel();

            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
