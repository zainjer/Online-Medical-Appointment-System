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

namespace Project
{
    /// <summary>
    /// Interaction logic for JustUser.xaml
    /// </summary>
    public partial class JustUser : Page
    {
        
        public JustUser()
        {
            InitializeComponent();
        }

        private void CreateProfile_Click(object sender, RoutedEventArgs e)
        {
            Dashboard obj = new Dashboard();
            Registration ob = new Registration();
            if (MessageBox.Show("Are you a doctor?", "User Check", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                obj.Hide();
                ob.Show();
            }
            else
            {
                obj.Hide();
                ob.Userreg.Visibility = Visibility.Hidden;
                ob.Profile.Content = new DoctorReg();

                ob.Show();
            }
        }
    }
}
