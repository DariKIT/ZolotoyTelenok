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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZolotoyTelenok
{
    /// <summary>
    /// Логика взаимодействия для ServicesAddEditPage.xaml
    /// </summary>
    public partial class ServicesAddEditPage : Page
    {
        private Услуги _CurServices = new Услуги();
        public ServicesAddEditPage(Услуги _SelectedServices)
        {
            InitializeComponent();
            if (_SelectedServices != null)
                _CurServices = _SelectedServices;
            DataContext = _CurServices;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void SaveCarBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder Errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_CurServices.Наименование))
                Errors.AppendLine("Введите наименование услуги!");
            if (string.IsNullOrWhiteSpace(_CurServices.Описание))
                Errors.AppendLine("Введите описание услуги!");
            if (string.IsNullOrWhiteSpace(Convert.ToString(_CurServices.Цена)))
                Errors.AppendLine("Введите цену услуги");
            if (Errors.Length > 0)
            {
                MessageBox.Show(Errors.ToString());
                return;
            }

            if (_CurServices.ИД_Услуги == 0)
                ZTDBEntities.GetContext().Услуги.Add(_CurServices);
            try
            {
                ZTDBEntities.GetContext().SaveChanges();
                MessageBox.Show("Сохранено");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {

        }
    }
}
