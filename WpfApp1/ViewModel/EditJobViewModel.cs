using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    internal class EditJobViewModel : PropertyChanged
    {
        private MainWindowViewModel _mainWindowViewModel;
        private Employee _employee;
        public Employee Employee
        {
            get { return _employee; }
            set
            {
                _employee = value;
                OnPropertyChanged("Employee");
            }
        }

        public string Position
        {
            get { return Employee.Position; }
            set
            {
                Employee.Position = value;
                OnPropertyChanged("Position");
            }
        }

        public ICommand UpdateCommand { get; }
        public Window Window { get; set; }
        public EditJobViewModel(MainWindowViewModel mainWindowViewModel, Employee employee, Window window)
        {
            _mainWindowViewModel = mainWindowViewModel;
            Window = window;
            _employee = employee;
            UpdateCommand = new RelayCommand(Update);
        }

        private void Update()
        {
            _mainWindowViewModel.SelectedEmployee.Position = Position;
            Window.DialogResult = true;
            Window.Close();
        }
    }
}
