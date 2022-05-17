using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZolotoyTelenok
{
    /// <summary>
    /// Логика взаимодействия для CarsAddEditPage.xaml
    /// </summary>
    public partial class CarsAddEditPage : Page
    {
        private Машина _CurCars = new Машина();
        public CarsAddEditPage(Машина SelectedCar)
        {
            InitializeComponent();
            if (SelectedCar != null)
                _CurCars = SelectedCar;
            DataContext = _CurCars;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void SaveCarBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder Errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_CurCars.Марка))
                Errors.AppendLine("Введите марку машины!");
            if (string.IsNullOrWhiteSpace(_CurCars.Модель))
                Errors.AppendLine("Введите модель машины!");
            if (_CurCars.Класс < 1 || _CurCars.Класс > 5)
                Errors.AppendLine("Класс машины от 1 до 5");
            if (Errors.Length > 0)
            {
                MessageBox.Show(Errors.ToString());
                return;
            }  
            
            if (_CurCars.ИД_Машины == 0)
                ZTDBEntities.GetContext().Машина.Add(_CurCars);
                try
                {
                ZTDBEntities.GetContext().SaveChanges();
                MessageBox.Show("Сохранено");
                Manager.MainFrame.GoBack();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    return;
                }
            
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^1-6]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
