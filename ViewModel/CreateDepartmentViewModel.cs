using System.Collections.ObjectModel;
using System.ComponentModel;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    public class CreateDepartmentViewModel : INotifyPropertyChanged
    {
        private string _departmentName;
        public string DepartmentName
        {
            get { return _departmentName; }
            set
            {
                _departmentName = value;
                OnPropertyChanged("DepartmentName");
            }
        }

        private ObservableCollection<string> _rooms;
        public ObservableCollection<string> Rooms
        {
            get { return _rooms; }
            set
            {
                _rooms = value;
                OnPropertyChanged("Rooms");
            }
        }

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

        public CreateDepartmentViewModel(Department department)
        {
            DepartmentName = department.DepartmentName;
            Rooms = new ObservableCollection<string>(department.Rooms);
            Employees = new ObservableCollection<Employee>(department.Employees);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
