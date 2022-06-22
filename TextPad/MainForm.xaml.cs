using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TextPad
{
    /// <summary>
    /// Логика взаимодействия для MainForm.xaml
    /// </summary>
    public partial class MainForm : Window
    {
        //// Создание объекта класса ViewModel для реализации не жёсткой связанности (паттерн MVVM);
        //ViewModel vm = new ViewModel();

        public MainForm()
        {
            InitializeComponent();
        }

        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    TC_WindowDocument.ItemsSource = vm.GetDocumentCollection;
        //}

        //private void BTN_NewFile_Click(object sender, RoutedEventArgs e)
        //{
        //    vm.CreateNewDocument();
        //}

        //private void BTN_OpenFile_Click(object sender, RoutedEventArgs e)
        //{
        //    vm.OpenNewDocument();
        //}
    }
}
