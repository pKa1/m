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
using System.Data.SqlClient;
using System.Data;

namespace connectV2
{
    /// <summary>
    /// Логика взаимодействия для auth.xaml
    /// </summary>
    public partial class auth : Window
    {


        string sqlC = @"Data source=192.168.1.231; Initial Catalog=us9; User id=us9; Password=123;";

       
        SqlConnection sqlConnection;
        SqlCommand command;
       

        public auth()
        {
            InitializeComponent();
        }

        public void log()
        {
            try
            {
                sqlConnection = new SqlConnection(sqlC);
                sqlConnection.Open();

                string cmd = "Select * From Users WHERE login='" + login.Text + "'"
                    + "AND pass='" + pass.Text + "'";
                command = new SqlCommand(cmd, sqlConnection);


                if (command.ExecuteScalar() != null)
                {
                    MainWindow main = new MainWindow();
                    main.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пороль");
                }
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            log();
        }
    }
}
