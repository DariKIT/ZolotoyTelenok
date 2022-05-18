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
    /// Логика взаимодействия для JournalPage.xaml
    /// </summary>
    public partial class JournalPage : Page
    {
        public JournalPage()
        {
            InitializeComponent();
            JournalList.ItemsSource = ZTDBEntities.GetContext().Запись.ToList();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void WorkerEditBtn_Click(object sender, RoutedEventArgs e)
        {

        }

       

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemBtn_Click(object sender, RoutedEventArgs e)
        {
            var WorkForRem = JournalList.SelectedItems.Cast<Запись>().ToList();
            if (MessageBox.Show($"Хотите ли вы удалить {WorkForRem.Count()} Элементы?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ZTDBEntities.GetContext().Запись.RemoveRange(WorkForRem);
                    ZTDBEntities.GetContext().SaveChanges();
                    JournalList.ItemsSource = ZTDBEntities.GetContext().Запись.ToList();
                    MessageBox.Show("Данные удалены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
