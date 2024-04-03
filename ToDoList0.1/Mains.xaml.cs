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

namespace ToDoList0._1
{
    /// <summary>
    /// Логика взаимодействия для Mains.xaml
    /// </summary>
    public partial class Mains : Window
    {
        public Mains()
        {
            InitializeComponent();
            //ListRasdelov.Items.Add(CreateButton("3", "мой текст"));

        }

        public Grid CreateButton(string idIcon, string nameZanetka)
        {
            Grid grid = new Grid();

            ColumnDefinition col1 = new ColumnDefinition();
            grid.ColumnDefinitions.Add(col1);

            ColumnDefinition col2 = new ColumnDefinition();
            col2.Width = new GridLength(4, GridUnitType.Star);
            grid.ColumnDefinitions.Add(col2);

            Image image = new Image();
            image.Source = new BitmapImage(new Uri("/image/icons/" + idIcon + ".png", UriKind.Relative));
            image.Width = 40;
            image.Height = 40;
            Grid.SetColumn(image, 0);
            grid.Children.Add(image);

            TextBlock textBlock = new TextBlock();
            textBlock.Text = nameZanetka;
            textBlock.TextAlignment = TextAlignment.Center;
            textBlock.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetColumn(textBlock, 1);
            grid.Children.Add(textBlock);
            return grid;
        }

        private void add1_Click(object sender, RoutedEventArgs e)
        {
            Rasdel rasdel = new Rasdel();
            CreateButton window = new CreateButton(rasdel);
            //CreateButton window = new CreateButton();
            window.ShowDialog();
            ListRasdelov.Items.Add(CreateButton(rasdel.IdIcon, rasdel.Name));
            //this.Close();
        }
    }
}
