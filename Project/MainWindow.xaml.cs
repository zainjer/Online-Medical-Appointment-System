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
using System.Data.Sql;
using System.Data.SqlClient;

namespace Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool userExists = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Regiser_Click(object sender, RoutedEventArgs e)
        {

            this.Hide();
            User_Registration obj = new User_Registration();
            obj.Show();
        }
        SqlDataReader reader;
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-2D1HUID;Initial Catalog=SeProject;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        Profilebinder bind = new Profilebinder();
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                cmd.CommandText = "Select UserID,username,Password from Users where Username = '" + txtUsername.Text.Trim() + "' and password = '" + txtpassword.Password + "'";
                cmd.Connection = conn;
                conn.Open();
                reader = cmd.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    i++;
                }
                if (i == 1)
                {
                    userExists = true;
                }
                else
                {
                    MessageBox.Show("Incorrect Username or Password", "Invalid Login");
                }

               
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                MessageBox.Show(s, "Exception Thrown");
            }

            finally
            {
                conn.Close();
            }
            if (userExists)
            {

                bind.setUserName(txtUsername.Text);
                bind.setPassword(txtpassword.Password);
                bind.setUserID();
                Dashboard obj1 = new Dashboard();
                obj1.Show();
                this.Hide();
               
            }

        }
    }
}
