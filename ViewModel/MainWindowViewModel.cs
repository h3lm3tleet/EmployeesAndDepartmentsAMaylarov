using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using WpfApp1.Model;
using WpfApp1.View;

namespace WpfApp1.ViewModel
{
    public class MainWindowViewModel : PropertyChanged
    {
        private ObservableCollection<Department> _departments;
        private ObservableCollection<Employee> _employees;
        private Employee _selectedEmployee;

        public ObservableCollection<Employee> Employees
        {
            get => _employees;
            set
            {
                _employees = value;
                OnPropertyChanged("Employees");
            }
        }

        public ObservableCollection<Department> Departments
        {
            get => _departments;
            set
            {
                _departments = value;
                OnPropertyChanged("Departments");
            }
        }

        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
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
        public ICommand CreateDepartmentCommand { get; set; }

        public MainWindowViewModel()
        {
            SetCollections();
            SetCommands();
        }

        private void SetCollections()
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
                {   FirstName = "Эцио",
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

            Departments = new ObservableCollection<Department>()
            {
                new Department()
                {
                    DepartmentName = "Бухгалтерия",
                    Rooms = new ObservableCollection<string>() { "101", "102", "103" },
                },
                new Department()
                {
                    DepartmentName = "IT отдел",
                    Rooms = new ObservableCollection<string>() { "201", "202", "203" },
                }
            };

            foreach (var departmens in Departments)
            {
                departmens.Employees = new ObservableCollection<Employee>(Employees
                                    .Where(e => e.Department == departmens.DepartmentName)
                                    .Select(e => new Employee()
                                    {
                                        department = e.department,
                                        FirstName = e.FirstName,
                                        LastName = e.LastName,
                                        Position = e.Position,
                                        Salary = e.Salary
                                    }));
            }
        }

        private void SetCommands()
        {
            AddEmployeeCommand = new RelayCommand(AddEmployee);
            EditSalaryCommand = new RelayCommand(EditSalary, IsSelectedEmployee);
            EditJobCommand = new RelayCommand(EditJob, IsSelectedEmployee);
            CreateDepartmentCommand = new RelayCommand(CreateDepartment);
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

        private bool IsSelectedEmployee() => SelectedEmployee != null;

        private void CreateDepartment()
        {
            var department = new Department();
            var createDepartmentWindow = new CreateDepartmentWindow(department);

            if (createDepartmentWindow.ShowDialog() == true)
            {
                Departments.Add(department);
            }
        }
    }
}

