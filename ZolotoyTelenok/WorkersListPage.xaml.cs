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
    /// Логика взаимодействия для WorkersListPage.xaml
    /// </summary>
    public partial class WorkersListPage : Page
    {
        public WorkersListPage()
        {
            InitializeComponent();
            WorkerList.ItemsSource = ZTDBEntities.GetContext().Работник.ToList();
            
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new WorkersAddEddPage(null));
        }

        private void RemBtn_Click(object sender, RoutedEventArgs e)
        {
            var WorkersForRem = WorkerList.SelectedItems.Cast<Работник>().ToList();
            if (MessageBox.Show($"Хотите ли вы удалить {WorkersForRem.Count()} Элементы?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ZTDBEntities.GetContext().Работник.RemoveRange(WorkersForRem);
                    ZTDBEntities.GetContext().SaveChanges();
                    WorkerList.ItemsSource = ZTDBEntities.GetContext().Работник.ToList();
                    MessageBox.Show("Данные удалены");
                }
                catch (Exception ex)
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
                WorkerList.ItemsSource = ZTDBEntities.GetContext().Работник.ToList();
            }
        }

        private void WorkerEditBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new WorkersAddEddPage((sender as Button).DataContext as Работник));
        }
    }
}
