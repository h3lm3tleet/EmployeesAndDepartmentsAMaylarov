using System.Windows;
using WpfApp1.Model;
using WpfApp1.ViewModel;

namespace WpfApp1.View
{
    public partial class EditJobWindow : Window
    {
        EditJobViewModel viewModel;
        public EditJobWindow(MainWindowViewModel mainWindowViewModel, Employee employee)
        {
            InitializeComponent();
            viewModel = new EditJobViewModel(mainWindowViewModel, employee, this);
            DataContext = viewModel;
        }
    }
}


