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

namespace MQuoter
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : Window
    {
        public About()
        {
            InitializeComponent();
        }

        private void em_OK_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void em_OnResetClick(object sender, RoutedEventArgs e)
        {
           if(MessageBox.Show("Czy na pewno chcesz zresetować statystyki?","Pytanie",MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Properties.Settings.Default.AppRunCounter = 0;
                Properties.Settings.Default.Save();
            }
        }
    }
}
