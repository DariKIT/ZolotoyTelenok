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
    /// Логика взаимодействия для CarsListPage.xaml
    /// </summary>
    public partial class CarsListPage : Page
    {
     
        public CarsListPage()
        {
            InitializeComponent();
            CarsList.ItemsSource = ZTDBEntities.GetContext().Машина.ToList();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new CarsAddEditPage(null));
        }

        private void RemBtn_Click(object sender, RoutedEventArgs e)
        {
            var CarsForRem = CarsList.SelectedItems.Cast<Машина>().ToList();
            if (MessageBox.Show($"Хотите ли вы удалить {CarsForRem.Count()} Элементы?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ZTDBEntities.GetContext().Машина.RemoveRange(CarsForRem);
                    ZTDBEntities.GetContext().SaveChanges();
                    CarsList.ItemsSource = ZTDBEntities.GetContext().Машина.ToList();
                    MessageBox.Show("Данные удалены");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                ZTDBEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(i => i.Reload());
                CarsList.ItemsSource = ZTDBEntities.GetContext().Машина.ToList();
            }
        }

        private void CarsEditBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new CarsAddEditPage((sender as Button).DataContext as Машина));
        }
    }
}
