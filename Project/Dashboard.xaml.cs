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

namespace Project
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();
            using (var db = new DataClasses1DataContext())
            {
               
               var check = (from User in db.Users
               where User.UserID == ProfileIdentifier.userID
               select User.Registered).SingleOrDefault();
                
                if (check)
                {
                    PageView.Content = new Profile();
                }
                else {
                    PageView.Content = new JustUser();
                }
                    

            }
                
        }

        private void Profile_Click(object sender, MouseButtonEventArgs e)
        {
            using (var db = new DataClasses1DataContext())
            {

                var check = (from User in db.Users
                             where User.UserID == ProfileIdentifier.userID
                             select User.Registered).SingleOrDefault();

                if (check)
                {
                    PageView.Content = new Profile();
                }
                else
                {
                    PageView.Content = new JustUser();
                }
            }

            }

        private void drag(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void closeImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            if (MessageBox.Show("Are you sure you want to Quit?", "Quit Medico" , MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                
            }
            else
            {
                Environment.Exit(0);
            }
            
        }
        public void CloseDashboard()
        {
            this.Hide();
        }
    }
}
