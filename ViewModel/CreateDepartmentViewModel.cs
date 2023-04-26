using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using WpfApp1.Model;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace WpfApp1.ViewModel
{
    public class CreateDepartmentViewModel : PropertyChanged
    {
        public Window Window { get; set; }
        public ICommand CreateDepartmentCommand { get; set; }
        private Department department;

        public Department Department
        {
            get { return department; }
            set
            {
                department = value;
                OnPropertyChanged("DepartmentName");
            }
        }

        private ObservableCollection<string> rooms;
        public ObservableCollection<string> Rooms
        {
            get { return rooms; }
            set
            {
                rooms = value;
                OnPropertyChanged("Rooms");
            }
        }

        private ObservableCollection<Employee> employees;
        public ObservableCollection<Employee> Employees
        {
            get { return employees; }
            set
            {
                employees = value;
                OnPropertyChanged("Employees");
            }
        }

        public CreateDepartmentViewModel(Department department,ObservableCollection<Employee> Employees, ObservableCollection<string> Rooms, Window window)
        {
            Employees = employees;
            Rooms = rooms;
            Department = department;
            //Rooms = new ObservableCollection<string>(department.Rooms);
            //Employees = new ObservableCollection<Employee>(department.Employees);
            Window = window;
            CreateDepartmentCommand = new RelayCommand(CreateDepartment);
        }
        private void CreateDepartment()
        {
            Window.DialogResult = true;
            Window.Close();
        }
    }
}
