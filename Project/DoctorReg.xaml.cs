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

namespace Project
{
    /// <summary>
    /// Interaction logic for DoctorReg.xaml
    /// </summary>
    public partial class DoctorReg : Page
    {
        Boolean profilecheck;
        public DoctorReg()
        {
            InitializeComponent();
        }

        private void picture_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Reg(object sender, RoutedEventArgs e)
        {
            try
            {
                Int64 ph = Convert.ToInt64(txtContact.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid Info");
            }
            string bio = new TextRange(RichBio.Document.ContentStart, RichBio.Document.ContentEnd).ToString();
            try
            {
                using (var db = new DataClasses1DataContext())
                {
                    Doctor D = new Doctor()
                    {
                        Full_Name = txtName.Text,
                        Father_Name = txtfather.Text,
                        Email = txtEmail.Text,
                        Phone = txtContact.Text,
                        Sex = ComboGender.Text.ToString(),
                        uid = ProfileIdentifier.userID,
                        Specialization = TxtSpecialize.Text,
                        Address = txtaddress.Text,
                        Experience = txtExperience.Text,
                        Bio = bio,
                    };
                    db.Doctors.InsertOnSubmit(D);
                    db.SubmitChanges();
                    string query = "update Users set Registered = 1, Doctor = 1 Where Username='" + ProfileIdentifier.username + "'";
                    SqlConnection conn = new SqlConnection("Data Source=DESKTOP-2D1HUID;Initial Catalog=SeProject;Integrated Security=True");
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid Info");
            }
            finally
            {

                if (profilecheck)
                {

                    MessageBox.Show("Profile Created. Restarting Application", "Success");
                    System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                    Application.Current.Shutdown();
                }
            }
        }
    }
}
