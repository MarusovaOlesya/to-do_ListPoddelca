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
        public Home(SqlConnection bd, string Id)
        {
            InitializeComponent();
            //ListBox.Items.Add(Create());
            //ListBox.Items.Add(Create());
            SqlCommand cmd = new SqlCommand("select NicName from Users where id ="+Id,bd);

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
                Source = new BitmapImage(new Uri("/image/icons/"+ IdIcons+".png", UriKind.Relative))
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
        }
    }
}
