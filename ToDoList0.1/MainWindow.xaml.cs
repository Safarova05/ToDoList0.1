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
        private SqlConnection conn;
        public MainWindow()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source=3205EC02\SQLEXPRESS; Initial Catalog=ToDoList; Integrated Security=True");
            conn.Open();          
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("select Id FROM Users WHERE Login = '"+ Login.Text+"' and Password = '"+ Password.Password+"';",conn);            
            SqlDataReader reader = sqlCommand.ExecuteReader();        

            if (reader.Read())
            {
                var id = reader[0].ToString();
                reader.Close();
                Mains mains = new Mains(conn, id);
                mains.Show();
                this.Close();
            }           
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            Registr registr = new Registr();
            registr.Show();
            this.Close();
        }
    }
}
