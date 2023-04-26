using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    class SaveLoadDepartmentsViewModel : PropertyChanged
    {
        public ICommand SerializeDataCommand { get; }
        public ICommand DeserializeDataCommand { get; set; }
        public Window Window { get; set; }
        public ObservableCollection<Department> Departments { get; set; }
        public SaveLoadDepartmentsViewModel(ObservableCollection<Department> Departments)
        {
            this.Departments = Departments;
            SerializeDataCommand = new RelayCommand(SerializeData);
            DeserializeDataCommand = new RelayCommand(DeserializeData);
        }

        private void SerializeData()
        {
            string filename = "data.json";
            string json = JsonConvert.SerializeObject(Departments);
            File.WriteAllText(filename, json);
        }

        private void DeserializeData()
        {
            using (StreamReader file = File.OpenText("data.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                ObservableCollection<Department> data = (ObservableCollection<Department>)serializer.Deserialize(file, typeof(ObservableCollection<Department>));

                Departments.Clear();
                foreach (Department item in data)
                {
                    Departments.Add(item);
                }
            }
        }
    }
}
