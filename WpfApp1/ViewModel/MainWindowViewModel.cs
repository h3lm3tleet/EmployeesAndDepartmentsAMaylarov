using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using WpfApp1.Model;
using WpfApp1.View;

namespace WpfApp1.ViewModel
{
    public class MainWindowViewModel : PropertyChanged
    {
        private ObservableCollection<Employee> _employees;
        public ObservableCollection<Employee> Employees
        {
            get { return _employees; }
            set
            {
                _employees = value;
                OnPropertyChanged("Employees");
            }
        }


        private Employee _selectedEmployee;
        public Employee SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged("SelectedEmployee");
                (EditSalaryCommand as RelayCommand).RaiseCanExecuteChanged();
                (EditJobCommand as RelayCommand).RaiseCanExecuteChanged();
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public ICommand AddEmployeeCommand { get; set; }
        public ICommand EditSalaryCommand { get; set; }
        public ICommand EditJobCommand { get; set; }

        public MainWindowViewModel()
        {
            Employees = new ObservableCollection<Employee>
            {
                new Employee
                {
                    FirstName = "Арктур",
                    LastName = "Менгкс",
                    Position = "Менеджер",
                    Salary = 40000,
                    Department = "Отдел продаж"
                },
                new Employee
                { FirstName = "Эцио",
                    LastName = "Аудиторе",
                    Position = "Программист",
                    Salary = 80000,
                    Department = "IT отдел"
                },
                new Employee
                {
                    FirstName = "Джон",
                    LastName = "Шепард",
                    Position = "Экономист",
                    Salary = 70000,
                    Department = "Бухгалтерия"
                },
            };

            AddEmployeeCommand = new RelayCommand(AddEmployee);
            EditSalaryCommand = new RelayCommand(EditSalary, IsSelectedEmployee);
            EditJobCommand = new RelayCommand(EditJob, IsSelectedEmployee);
        }

        private void AddEmployee()
        {
            var employee = new Employee();
            var addEmployeeWindow = new AddEmployeeWindow(employee);
            if (addEmployeeWindow.ShowDialog() == true)
            {
                Employees.Add(employee);
            }
        }

        private void EditSalary()
        {
            var editSalaryWindow = new EditSalaryWindow(this, SelectedEmployee);
            editSalaryWindow.ShowDialog();
        }

        private void EditJob()
        {
            var editJobWindow = new EditJobWindow(this, SelectedEmployee);
            editJobWindow.ShowDialog();
        }

        private bool IsSelectedEmployee()
        {
            return SelectedEmployee != null;
        }
    }
}

