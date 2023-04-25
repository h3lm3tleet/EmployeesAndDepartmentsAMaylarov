using System.Windows;
using WpfApp1.Model;
using WpfApp1.ViewModel;

namespace WpfApp1.View
{
    public partial class AddEmployeeWindow : Window
    {
        AddEmployeeViewModel viewModel;
        public AddEmployeeWindow(Employee employee)
        {
            InitializeComponent();
            viewModel = new AddEmployeeViewModel(employee, this);
            DataContext = viewModel;
        }      
    }
}
