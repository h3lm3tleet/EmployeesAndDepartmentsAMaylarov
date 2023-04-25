using System.Windows;
using WpfApp1.Model;
using WpfApp1.ViewModel;

namespace WpfApp1.View
{
    public partial class CreateDepartmentWindow : Window
    {
        CreateDepartmentViewModel viewModel;
        public CreateDepartmentWindow(Department department)
        {
            InitializeComponent();
            viewModel = new CreateDepartmentViewModel(department, this);
            DataContext = viewModel;
        }
    }
}
