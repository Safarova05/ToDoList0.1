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
    /// Логика взаимодействия для CreateButton.xaml
    /// </summary>
    public partial class CreateButton : Window
    {
        Rasdel rasdel;
        public CreateButton(Rasdel rasdel)
        {
            InitializeComponent();
            this.rasdel = rasdel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            rasdel.Name = NameRasdel.Text;
            this.Close();

            //Mains window = new Mains();
            //window.Show();
        }
        //Иконки!!!

        private void RadioButton_Icons1(object sender, RoutedEventArgs e)
        {
            rasdel.IdIcon = "1";
        }

        private void RadioButton_Icons2(object sender, RoutedEventArgs e)
        {
            rasdel.IdIcon = "2";
        }

        private void RadioButton_Icons3(object sender, RoutedEventArgs e)
        {
            rasdel.IdIcon = "3";
        }

        private void RadioButton_Icons4(object sender, RoutedEventArgs e)
        {
            rasdel.IdIcon = "4";
        }

        private void RadioButton_Icons5(object sender, RoutedEventArgs e)
        {
            rasdel.IdIcon = "5";
        }
        //Фон!!!

        private void RadioButton_Fons1(object sender, RoutedEventArgs e)
        {
            rasdel.IdFons = "1";
        }

        private void RadioButton_Fons2(object sender, RoutedEventArgs e)
        {
            rasdel.IdFons = "2";
        }

        private void RadioButton_Fons3(object sender, RoutedEventArgs e)
        {
            rasdel.IdFons = "3";
        }

        private void RadioButton_Fons4(object sender, RoutedEventArgs e)
        {
            rasdel.IdFons = "4";
        }

        private void RadioButton_Fons5(object sender, RoutedEventArgs e)
        {
            rasdel.IdFons = "5";
        }

        
    }
}
