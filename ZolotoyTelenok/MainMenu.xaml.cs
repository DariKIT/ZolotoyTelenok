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
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
            Manager.InfoFrame = InfoFrame;
        }

        private void CarsListPageBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.InfoFrame.Navigate(new CarsListPage());
        }

        private void ServicesListPageBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.InfoFrame.Navigate(new ServicesListPage());
        }

        private void WorkersListPageBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.InfoFrame.Navigate(new WorkersListPage());
        }

        private void JournalPageBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.InfoFrame.Navigate(new JournalPage());
        }
    }
}
