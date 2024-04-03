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

namespace ToDoList0._1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=3205EC02; Initial Catalog=ToDoList; Integrated Security=True");
            conn.Open();

            Mains window = new Mains();

            
            string map = "SELECT Login FROM Users WHERE Login = '"+Login+"'and Password ='"+Password+"'";
            SqlCommand cmd = new SqlCommand(map, conn);

            string login = Login.Text;
            string pas = Password.Password;

            //cmd.Parameters.AddWithValue("@Login", Login);
            //cmd.Parameters.AddWithValue("@Password", Password);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                 window.Show();
                 this.Close();
            }
            else
            {
                Text.Text = "ERROR";
            }
            conn.Close();
           
           
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            Registr registr = new Registr();
            registr.Show();
            this.Close();
        }
    }
}
