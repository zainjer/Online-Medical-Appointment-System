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
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        Boolean profilecheck;


        public void hide()
        {
            this.Hide();
        }
      
        public Registration()
        {
            InitializeComponent();
           
        }
        

        private void Register(object sender, RoutedEventArgs e)
        {
            try
            {
                Int64 ph = Convert.ToInt64(txtPhone.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid Info");
            }
            string bio = new TextRange(txtbio.Document.ContentStart, txtbio.Document.ContentEnd).ToString();
            try
            {
                using (var db = new DataClasses1DataContext())
                {

                    Customer c = new Customer()
                    {
                        Full_Name = txtfullname.Text,
                        Father_Name = txtfathername.Text,
                        Email = TxtEmail.Text,
                        Sex = comboGender.Text.ToString(),
                        Phone = txtPhone.Text,
                        Marital_Status = comboMartial.Text.ToString(),
                        Address = txtaddress.Text,
                        Occupation = txtoccupation.Text,
                        BloodGroup = comboBlood.Text.ToString(),
                        Diagnosis = txtDiagnosis.Text,
                        bio = bio,
                        uid = ProfileIdentifier.userID
                    };
                    db.Customers.InsertOnSubmit(c);
                    db.SubmitChanges();

                    string query = "update Users set Registered = 1, Doctor = 0 Where Username='" + ProfileIdentifier.username + "'";
                    SqlConnection conn = new SqlConnection("Data Source=DESKTOP-2D1HUID;Initial Catalog=SeProject;Integrated Security=True");
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                }
                profilecheck = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid Info");
            }

            finally
            {
                if (profilecheck) {                
                MessageBox.Show("Profile Created. Restarting Application", "Success");
                System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                Application.Current.Shutdown();
            }

            }
        }
          
        }
    }

