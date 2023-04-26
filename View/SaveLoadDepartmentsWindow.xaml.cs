using System.Collections.ObjectModel;
using System.Windows;
using WpfApp1.Model;
using WpfApp1.ViewModel;

namespace WpfApp1.View
{
    public partial class SaveLoadDepartmentsWindow : Window
    {
        SaveLoadDepartmentsViewModel viewModel;
        public SaveLoadDepartmentsWindow(ObservableCollection<Department> Departments)
        {
            InitializeComponent();
            viewModel = new SaveLoadDepartmentsViewModel(Departments);
            DataContext = viewModel;
        }
    }
}
