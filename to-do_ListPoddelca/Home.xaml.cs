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
using System.Windows.Shapes;

namespace to_do_ListPoddelca
{
    /// <summary>
    /// Логика взаимодействия для Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        private SqlConnection bd;
        private string Id;
        private string IdRazdel;
        public Home(SqlConnection bd, string Id)
        {
            InitializeComponent();
            this.bd = bd;
            this.Id = Id;
            WriteNickname();
            WriteKateories();
        }

        private void WriteNickname()
        {
            SqlCommand cmd = new SqlCommand("select NicName from Users where id =" + Id, bd);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            Nick.Text = reader[0].ToString();
            reader.Close();
        }

        private void WriteKateories()
        {
            SqlCommand cmd = new SqlCommand("select Name, Icon from Partition where User_id =" + Id, bd);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ListBox.Items.Add(Create(reader[1].ToString(), reader[0].ToString()));
            }
            reader.Close();
        }

        public Grid Create(string IdIcons, string IdText)
        {
            Grid myGrid = new Grid
            {
                Height = 36,
                Width = 149
            };

            ColumnDefinition col1 = new ColumnDefinition();
            ColumnDefinition col2 = new ColumnDefinition
            {
                Width = new GridLength(4, GridUnitType.Star)
            };

            myGrid.ColumnDefinitions.Add(col1);
            myGrid.ColumnDefinitions.Add(col2);

            Image myImage = new Image
            {
                Source = new BitmapImage(new Uri("/image/icons/" + IdIcons + ".png", UriKind.Relative))
            };
            Grid.SetColumn(myImage, 0);

            TextBlock myTextBlock = new TextBlock
            {
                Text = IdText,
                VerticalAlignment = VerticalAlignment.Center,
                TextAlignment = TextAlignment.Center
            };
            Grid.SetColumn(myTextBlock, 1);

            myGrid.Children.Add(myImage);
            myGrid.Children.Add(myTextBlock);
            return myGrid;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Razdel razdel = new Razdel();
            NewPartition newPartition = new NewPartition(razdel);
            newPartition.ShowDialog();
            ListBox.Items.Add(Create(razdel.IdIcon, razdel.IdText));
            SqlCommand cmd = new SqlCommand($"insert into Partition values ({Id},'{razdel.IdText}',{razdel.IdIcon},1);", bd);
            cmd.ExecuteNonQuery();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StackP.Children.Clear();
            Button but = new Button() { Content = "Добавить" };
            but.Click += Button_Click3;
            StackP.Children.Add(but);
            string aw = ((TextBlock)((Grid)ListBox.SelectedItem).Children[1]).Text;
            SqlCommand cmd = new SqlCommand($"select Description,Status from Cases where Partition_id =(select id from Partition where Name='{aw}');", bd);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            while(reader.Read())
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Content = reader[0];
                checkBox.FontSize = 15;
                checkBox.IsChecked = (reader[1].ToString()) == "True";
                StackP.Children.Add(checkBox);
            }
            reader.Close();

            cmd = new SqlCommand($"select Id from Partition Where Name = '{aw}'", bd);
            reader = cmd.ExecuteReader();
            reader.Read();
            IdRazdel = reader[0].ToString();
            reader.Close();

        }
        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            List list = new List();
            NewList newList = new NewList(list);
            newList.ShowDialog();
            StackP.Children.Add(new CheckBox() { Content = list.Name});
            SqlCommand sqlCommand = new SqlCommand($"insert into Cases values({IdRazdel},'{list.Name}',0);", bd);
            sqlCommand.ExecuteNonQuery();

        }
    }
}
