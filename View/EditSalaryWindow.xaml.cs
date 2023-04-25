using System.Windows;
using WpfApp1.Model;
using WpfApp1.ViewModel;

namespace WpfApp1.View
{
    public partial class EditSalaryWindow : Window
    {
        EditSalaryViewModel viewModel;
        public EditSalaryWindow(MainWindowViewModel mainWindowViewModel, Employee employee)
        {
            InitializeComponent();
            viewModel = new EditSalaryViewModel(mainWindowViewModel, employee, this);
            DataContext = viewModel;
        }
    }
}

