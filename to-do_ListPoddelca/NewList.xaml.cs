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
    /// Логика взаимодействия для NewList.xaml
    /// </summary>
    public partial class NewList : Window
    {
        List list;
        public NewList(List list)
        {
            InitializeComponent();
            this.list = list;
        }

        private void Click_Dobavit(object sender, RoutedEventArgs e)
        {
            list.Name = TextBox.Text;
            this.Close();
        }
    }
}
