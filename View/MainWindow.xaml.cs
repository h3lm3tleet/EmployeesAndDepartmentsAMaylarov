using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;
using WpfApp1.Model;
using WpfApp1.View;
using WpfApp1.ViewModel;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel viewModel;
        public ObservableCollection<Department> Departments { get; set; }


        public MainWindow()
        {
            viewModel = new MainWindowViewModel();

            InitializeComponent();
            DataContext = viewModel;
        }

        //private void SaveLoadDepartments(object sender, RoutedEventArgs e)
        //{
        //    var saveLoadData = new SaveLoadDepartmentsWindow();
        //    saveLoadData.ShowDialog();
        //    Button clickedButton = sender as Button;
        //    if (clickedButton.Name == "SaveData")
        //    {
        //        string filename = "F:\\data.json";
        //        string json = JsonConvert.SerializeObject(Departments);
        //        File.WriteAllText(filename, json);
        //    }
        //    else if (clickedButton.Name == "LoadData")
        //    {
        //        string filename = "F:\\data.json";
        //        if (File.Exists(filename))
        //        {
        //            string json = File.ReadAllText(filename);
        //            Departments = JsonConvert.DeserializeObject<ObservableCollection<Department>>(json);
        //        }
        //    }
        //}
    }
}
