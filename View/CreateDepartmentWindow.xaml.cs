using System.Collections.ObjectModel;
using System.Windows;
using WpfApp1.Model;
using WpfApp1.ViewModel;

namespace WpfApp1.View
{
    public partial class CreateDepartmentWindow : Window
    {
        CreateDepartmentViewModel viewModel;
        public CreateDepartmentWindow(Department department, ObservableCollection<Employee> Employees, ObservableCollection<string> Rooms)
        {
            InitializeComponent();
            viewModel = new CreateDepartmentViewModel(department, Employees, Rooms, this);
            DataContext = viewModel;
        }
    }
}
