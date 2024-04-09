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

namespace ToDoList0._1
{
    /// <summary>
    /// Логика взаимодействия для Mains.xaml
    /// </summary>
    public partial class Mains : Window
    {
        private SqlConnection conn;
        private string id;
        private string idRasdel;

        public Mains(SqlConnection conn, string id)
        {
            InitializeComponent();

            this.conn = conn;
            this.id = id;
            WriteNickname();
            WriteKatigories();
            
           // createList();

            //ListRasdelov.Items.Add(CreateButton("3", "мой текст"));

        }

        private void createList()
        {
            SqlCommand cmd = new SqlCommand("select Title FROM Chapter", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ListRasdelov.Items.Add(reader[0]);
            }
            reader.Close();
        }

        private void ListRasdel_Selection(object sender, SelectionChangedEventArgs e)
        {
            Stac.Children.Clear();

            Button but = new Button() { Content = "Добавить" };
            but.Click += add2_Click;
            Stac.Children.Add(but);

            string a = ((TextBlock)((Grid)ListRasdelov.SelectedItem).Children[1]).Text;
            SqlCommand cmd = new SqlCommand($"select Description, StatusD from Case1 where id_Chapter = (select id from Chapter where Title = '"+a+"'); ", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Content = reader[0];
                checkBox.FontSize = 15;

                string b = reader[1].ToString();
                checkBox.IsChecked = (b == "True");
                Stac.Children.Add(checkBox);
            }
            reader.Close();

            cmd = new SqlCommand($"select id from Chapter where Title = '" + a + "' ", conn);
            reader = cmd.ExecuteReader();
            reader.Read();
            idRasdel = reader[0].ToString();
            reader.Close();
        }
        private void add2_Click(object sender, RoutedEventArgs e)
        {
            Delo delo = new Delo();
            
            AddCheckBox addCheckBox = new AddCheckBox(delo);
            addCheckBox.ShowDialog();

            Stac.Children.Add(new CheckBox { Content = delo.Name});
            SqlCommand sqlCommand = new SqlCommand($"insert into Case1 values ({idRasdel}, '{delo.Name}', 0);", conn);
            sqlCommand.ExecuteNonQuery();
        }

            private void WriteNickname()
        {
            SqlCommand cmd = new SqlCommand("SELECT FIO FROM Users WHERE id = " +id,conn);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            NikeName.Text = reader[0].ToString();
            reader.Close();
        }

        private void WriteKatigories()
        {
            SqlCommand cmd = new SqlCommand("SELECT Title, Id_icon FROM Chapter WHERE Id_Users = '" + id + "' ", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ListRasdelov.Items.Add(CreateButton(reader[1].ToString(), reader[0].ToString()));
            }
            reader.Close();

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
            window.ShowDialog();
            ListRasdelov.Items.Add(CreateButton(rasdel.IdIcon, rasdel.Name));
            SqlCommand sqlCommand = new SqlCommand($"insert into Chapter VALUES ( '{rasdel.Name}', {id}, {rasdel.IdIcon}, 2);", conn);
            sqlCommand.ExecuteNonQuery();
            
            //CreateButton window = new CreateButton();
            //window.ShowDialog();
            //this.Close();
        }
    }
}
