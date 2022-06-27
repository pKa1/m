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
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Data.SqlClient;
using System.Data;


namespace connectV2
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string sqlC = @"Data source=192.168.1.231; Initial Catalog=us9; User id=us9; Password=123;";

        DataTable dt;
        SqlConnection sqlConnection;
        SqlCommand command;
        SqlDataAdapter dataAdapter;
        DataSet dataSet;

        public MainWindow()
        {
           
            InitializeComponent();
            update();
            date();
            
        }

        public void update()
        {
            sqlConnection = new SqlConnection(sqlC);
            sqlConnection.Open();
            string cmd = "SELECT * FROM Client";
            command = new SqlCommand(cmd, sqlConnection);
            command.ExecuteNonQuery();
            dataAdapter = new SqlDataAdapter(command);
            dt = new DataTable("Client");
            dataAdapter.Fill(dt);
            DGrid.ItemsSource = dt.DefaultView;
            sqlConnection.Close();
            
        }

        public void date()
        {
            comboBox1.ItemsSource = new List<string> { "Да", "Нет" };
        }

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string a = null;
            string da = "Да";
            string net = "Нет";

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    a = da;
                    break;
                case 1:
                    a = net;
                    break;
                default:

                    break;
            }


            string ids_ = idS.Text;
            string por_ = por.Text;
            string st_ = st.Text;

            sqlConnection = new SqlConnection(sqlC);
            sqlConnection.Open();

            string cmd = "INSERT INTO Client (, , , ) VALUES ('" + 1 + "', '" + 1 + "', '" + 1 + "', '" + 1 + "');";
            command = new SqlCommand(cmd, sqlConnection);
            command.ExecuteNonQuery();

            sqlConnection.Close();
            update();


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            sqlConnection.Open();
            int sa = DGrid.SelectedIndex;
            DataRow dataRow = dt.Rows[sa];
            string row = dataRow[0].ToString();
            string cmd = "DELETE FROM Client WHERE id=" + row;
            command = new SqlCommand(cmd, sqlConnection);
            command.ExecuteNonQuery();
            sqlConnection.Close();
            update();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            string a = null;
            string da = "Да";
            string net = "Нет";

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    a = da;
                    break;
                case 1:
                    a = net;
                    break;
                default:

                    break;
            }


            string ids_ = idS.Text;
            string por_ = por.Text;
            string st_ = st.Text;


            sqlConnection.Open();
            int sa = DGrid.SelectedIndex;
            DataRow dataRow = dt.Rows[sa];
            string row = dataRow[0].ToString();

            string cmd = "UPDATE Client SET  = '" + 1 + "',  = '" + 1 + "',  = '" + 1 + "',  = '" + 1 + "' WHERE id = " + row;
            command = new SqlCommand(cmd, sqlConnection);
            command.ExecuteNonQuery();
            sqlConnection.Close();
            update();
        }

        private void TextBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBoxSearch.Text == "")
            {
                update();
            }
            else
            {
                sqlConnection = new SqlConnection(sqlC);
                sqlConnection.Open();

                string cmd1 = "SELECT * FROM Client WHERE 1 LIKE '%" + TextBoxSearch.Text + "%'";

                command = new SqlCommand(cmd1, sqlConnection);
                dataAdapter = new SqlDataAdapter(command);
                command.ExecuteNonQuery();

                dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                DGrid.ItemsSource = dataSet.Tables[0].DefaultView;
                sqlConnection.Close();
            }
        }
    }
}
