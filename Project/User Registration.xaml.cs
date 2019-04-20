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
using System.Data.Sql;
using System.Data.SqlClient;

namespace Project
{
    /// <summary>
    /// Interaction logic for User_Registration.xaml
    /// </summary>
    public partial class User_Registration : Window
    {
        public User_Registration()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-2D1HUID;Initial Catalog=SeProject;Integrated Security=True");
        private void Regiser_Click(object sender, RoutedEventArgs e)
        {
            string u, p, q;
            u = txtUsername.Text.Trim();
            p = txtPassword.Password;

            q = "INSERT INTO [dbo].[Users]([Username],[Password],[Registered]) VALUES ('" + u + "','" + p + "',0)";
            SqlCommand query = new SqlCommand(q,conn);
            try
            {
                if (u != "" && p != "")
                {
                    conn.Open();
                    query.ExecuteNonQuery();
                    MessageBox.Show("User Registration Successful. Please Login to continue", "Registration Confirmed");
                    this.Hide();
                    MainWindow obj = new MainWindow();
                    obj.Show();
                }
                else
                    MessageBox.Show("Feilds cannot be empy", "Empty Feilds");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Thrown");
            }
            finally
            {
                conn.Close();
            }
           
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow obj = new MainWindow();
            this.Hide();
            obj.Show();
        }
    }
}
