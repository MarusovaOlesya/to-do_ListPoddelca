using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace to_do_ListPoddelca
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        private SqlConnection bd;
        public MainWindow()
        {
            bd = new SqlConnection(@"Data Source=3205EC12; Initial Catalog=to-do_list; Integrated Security=True");
            bd.Open();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
           
            string login = Login.Text;
            string pass = Password.Text;
            string zap = "SELECT Id FROM Users WHERE NicName = '" + login + "'and Password = '" + pass + "'";
            SqlCommand cmd = new SqlCommand(zap, bd);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                var Id = dr[0].ToString();
                dr.Close();
                Home home = new Home(bd, Id);
                home.Show();
                this.Close();
            }
            else
           
                Text.Text = "ERROR";
            }
        }
    }
}
