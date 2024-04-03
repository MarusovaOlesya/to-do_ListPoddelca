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

namespace to_do_ListPoddelca
{
    /// <summary>
    /// Логика взаимодействия для NewPartition.xaml
    /// </summary>
    public partial class NewPartition : Window
    {
        Razdel razdel;
        public NewPartition(Razdel razdel)
        {
            InitializeComponent();
            this.razdel = razdel;
        }

        private void RadioButton_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }

        private void Click_Dobavit(object sender, RoutedEventArgs e)
        {
            razdel.IdText = TextBox.Text;
            this.Close();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            razdel.IdIcon = "1";
        }

        private void RadioButton_Checked1(object sender, RoutedEventArgs e)
        {
            razdel.IdIcon = "2";
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            razdel.IdIcon = "3";
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            razdel.IdIcon= "4";
        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            razdel.IdIcon = "5";
        }
    }
}
