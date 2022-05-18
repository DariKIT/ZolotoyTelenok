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
    /// Логика взаимодействия для ServicesListPage.xaml
    /// </summary>
    public partial class ServicesListPage : Page
    {
        public ServicesListPage()
        {
            InitializeComponent();
            ServicesList.ItemsSource = ZTDBEntities.GetContext().Услуги.ToList();
            
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ServicesAddEditPage(null));
        }

        private void RemBtn_Click(object sender, RoutedEventArgs e)
        {
            var ServicesForRem = ServicesList.SelectedItems.Cast<Услуги>().ToList();
            if (MessageBox.Show($"Хотите ли вы удалить {ServicesForRem.Count()} Элементы?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ZTDBEntities.GetContext().Услуги.RemoveRange(ServicesForRem);
                    ZTDBEntities.GetContext().SaveChanges();
                    ServicesList.ItemsSource = ZTDBEntities.GetContext().Услуги.ToList();
                    MessageBox.Show("Данные удалены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        private void ServicesEditBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ServicesAddEditPage((sender as Button).DataContext as Услуги));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                ZTDBEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(i => i.Reload());
                ServicesList.ItemsSource = ZTDBEntities.GetContext().Услуги.ToList();
            }
        }
    }
}
