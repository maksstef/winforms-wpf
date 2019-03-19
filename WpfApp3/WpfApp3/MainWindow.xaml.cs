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

namespace WpfApp3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static string str;
        
        public static async Task ConnectWithDB()
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=SHOP;Integrated Security=True";
            string sqlExpression = "SELECT * FROM good";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                   str = $"{reader.GetName(0)}\t{reader.GetName(1)}\t{reader.GetName(2)}\t\n";

                    while (await reader.ReadAsync())
                    {
                        object name = reader.GetValue(0);
                        object id = reader.GetValue(1);
                        object size = reader.GetValue(2);
                        str += $"{name}\t{id}\t{size}\t\n";
                    }
                }
                MessageBox.Show(str);
                reader.Close();
            }
        }

        public static async Task Sort()
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=SHOP;Integrated Security=True";
            string sqlExpression = "SELECT * FROM good order by Size";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    str = $"{reader.GetName(0)}\t{reader.GetName(1)}\t{reader.GetName(2)}\t\n";

                    while (await reader.ReadAsync())
                    {
                        object name = reader.GetValue(0);
                        object id = reader.GetValue(1);
                        object size = reader.GetValue(2);
                        str += $"{name}\t{id}\t{size}\t\n";
                    }
                }
                MessageBox.Show(str);
                reader.Close();
            }
        }

        public static async Task AddObject()
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=SHOP;Integrated Security=True";
            string sqlExpression = $"INSERT INTO good (Name, ID, Size) VALUES ('{name}',{id},{size})";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
                MessageBox.Show($"added objects: {number}");
            }
        }

        public static async Task EditObject()
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=SHOP;Integrated Security=True";
            string sqlExpression2 = $"Update good SET Name='{sqlWxp1}' where ID={sqlWxp2}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(sqlExpression2, connection);
                int number = command.ExecuteNonQuery();
                MessageBox.Show($"edit objects: {number}");
            }
        }

        public static async Task DeleteObject()
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=SHOP;Integrated Security=True";
            string sqlExpression = $"delete from good where ID={delId}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
                MessageBox.Show($"deleted objects: {number}");
            }
        }

        private static void GetGoods()
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=SHOP;Integrated Security=True";
            string sqlExpression = "sp_GetGoods";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    str = $"{reader.GetName(0)}\t{reader.GetName(1)}\t{reader.GetName(2)}\t\n";

                    while (reader.Read())
                    {
                        object name = reader.GetValue(0);
                        object id = reader.GetValue(1);
                        object size = reader.GetValue(2);
                        str += $"{name}\t{id}\t{size}\t\n";
                    }
                }
                MessageBox.Show(str);
                reader.Close();
            }
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            ConnectWithDB().GetAwaiter();
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            AddObject().GetAwaiter();
        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            EditObject().GetAwaiter();
        }

        private void Btn4_Click(object sender, RoutedEventArgs e)
        {
            DeleteObject().GetAwaiter();
        }

        public static string sqlWxp2 = "";
        private void Txtbx3_TextChanged(object sender, TextChangedEventArgs e)
        {
            sqlWxp2 = txtbx3.Text;
        }

        public static string sqlWxp1 = "";
        private void Txtbx32_TextChanged(object sender, TextChangedEventArgs e)
        {
            sqlWxp1 = txtbx32.Text;
        }

        //size
        public static string size = "";
        private void Txtbx23_TextChanged(object sender, TextChangedEventArgs e)
        {
            size = txtbx23.Text;
        }

        //id
        public static string id = "";
        private void Txtbx22_TextChanged(object sender, TextChangedEventArgs e)
        {
            id = txtbx22.Text;
        }

        //name
        public static string name = "";
        private void Txtbx2_TextChanged(object sender, TextChangedEventArgs e)
        {
            name = txtbx2.Text;
        }

        //deleted id
        public static string delId = ""; 
        private void Txtbx4_TextChanged(object sender, TextChangedEventArgs e)
        {
            delId = txtbx4.Text;
        }

        private void Btn_sort_Click(object sender, RoutedEventArgs e)
        {
            Sort().GetAwaiter();
        }

        private void Stored_Procedure_Click(object sender, RoutedEventArgs e)
        {
            GetGoods();
        }

        private void Script_Click(object sender, RoutedEventArgs e)
        {
            if (script != "")
            {
                string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=SHOP;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(script, connection);
                    int number = command.ExecuteNonQuery();
                    MessageBox.Show($"script comlete!");
                }
            }
            else
            {
                MessageBox.Show("enter script!");
            }
        }

        //script text
        string script = "";
        private void TxtScript_TextChanged(object sender, TextChangedEventArgs e)
        {
            script = txtScript.Text;
        }
    }
}
