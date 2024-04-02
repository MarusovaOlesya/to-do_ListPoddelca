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
    /// Логика взаимодействия для Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
            ListBox.Items.Add(Create());
            ListBox.Items.Add(Create());
            ListBox.Items.Add(Create());

        }
        public Grid Create()
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
                Source = new BitmapImage(new Uri("/image/icons/icons8-главная-страница-96.png", UriKind.Relative))
            };
            Grid.SetColumn(myImage, 0);

            TextBlock myTextBlock = new TextBlock
            {
                Text = "мой день",
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
            NewPartition newPartition = new NewPartition();
            newPartition.Show();
            this.Close();
        }
    }
}
