using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Model;
using WpfApp1.View;

namespace WpfApp1.ViewModel
{
    internal class AddEmployeeViewModel : PropertyChanged
    {
        public Employee Employee { get; set; }
        public ICommand AddCommand { get; set; }
        public Window Window { get; set; } 

        public AddEmployeeViewModel(Employee employee, Window window)
        {
            Employee = employee;
            Window = window;
            AddCommand = new RelayCommand(AddEmployee);
        }

        private void AddEmployee()
        {
            Window.DialogResult = true;
            Window.Close();
        }
    }
}
