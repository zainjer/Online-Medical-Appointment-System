using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace Project
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Page 
    {

        public Profile(int uid,Boolean isUser)
        {
            InitializeComponent();
          profileDataBinderD(uid,isUser);

        }
        public Profile()
        {
            InitializeComponent();
            docOrNot();
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

      
        public void profileDataBinderC(int userID)
        {
            string fullname, fathername, email, gender, phone, address, occupation, diagnosis, bio;
            
            using (var db = new DataClasses1DataContext())
            {
                fullname = (from Customer in db.Customers
                            where Customer.uid == userID
                            select Customer.Full_Name).SingleOrDefault();

                fathername = (from Customer in db.Customers
                              where Customer.uid == userID
                              select Customer.Father_Name).SingleOrDefault();
                email = (from Customer in db.Customers
                         where Customer.uid == userID
                         select Customer.Email).SingleOrDefault();
                gender = (from Customer in db.Customers
                          where Customer.uid == userID
                          select Customer.Sex).SingleOrDefault();
                phone = (from Customer in db.Customers
                         where Customer.uid == userID
                         select Customer.Phone).SingleOrDefault();
                address = (from Customer in db.Customers
                           where Customer.uid == userID
                           select Customer.Address).SingleOrDefault();
                occupation = (from Customer in db.Customers
                              where Customer.uid == userID
                              select Customer.Occupation).SingleOrDefault();
                diagnosis = (from Customer in db.Customers
                             where Customer.uid == userID
                             select Customer.Diagnosis).SingleOrDefault();
                bio = (from Customer in db.Customers
                       where Customer.uid == userID
                       select Customer.bio).SingleOrDefault();
            }
            bindFullname.Text = lblFullname.Text = fullname;
            bindEmail.Text = lblMail.Text = email;
            bindSex.Text = gender;
            BindSpeciality_Occupation.Text = lblSpeciality_occupation.Text = occupation;
            BindContact.Text = lblphone.Text = phone;
            lblAddress.Text = address;
            BindExperience_Diagnosis.Text = lblExperience_Diagnosis.Text = diagnosis;
            BindLastDoctor.Visibility = Visibility.Visible;
        }
        private void profileDataBinderD(int userID, Boolean IsUser)
        {
            string fullname, fathername, email, gender, phone, address, occupation, diagnosis, bio;

            using (var db = new DataClasses1DataContext())
            {
                fullname = (from Doctor in db.Doctors
                            where Doctor.uid == userID
                            select Doctor.Full_Name).SingleOrDefault();

                fathername = (from Doctor in db.Doctors
                              where Doctor.uid == userID
                              select Doctor.Father_Name).SingleOrDefault();
                email = (from Doctor in db.Doctors
                         where Doctor.uid == userID
                         select Doctor.Email).SingleOrDefault();
                gender = (from Doctor in db.Doctors
                          where Doctor.uid == userID
                          select Doctor.Sex).SingleOrDefault();
                phone = (from Doctor in db.Doctors
                         where Doctor.uid == userID
                         select Doctor.Phone).SingleOrDefault();
                address = (from Doctor in db.Doctors
                           where Doctor.uid == userID
                           select Doctor.Address).SingleOrDefault();
                occupation = (from Doctor in db.Doctors
                              where Doctor.uid == userID
                              select Doctor.Specialization).SingleOrDefault();
                diagnosis = (from Doctor in db.Doctors
                             where Doctor.uid == userID
                             select Doctor.Experience).SingleOrDefault();
                bio = (from Doctor in db.Doctors
                       where Doctor.uid == userID
                       select Doctor.Bio).SingleOrDefault();
            }
            if(IsUser){ 
            bindFullname.Text = lblFullname.Text = fullname;
            bindEmail.Text = lblMail.Text = email;
            bindSex.Text = gender;
            BindSpeciality_Occupation.Text = lblSpeciality_occupation.Text = occupation;
            BindContact.Text = lblphone.Text = phone;
            lblAddress.Text = address;
            BindExperience_Diagnosis.Text = lblExperience_Diagnosis.Text = diagnosis;
            }
            else
            {
                lblFullname.Text = fullname;
                lblMail.Text = email;               
                lblSpeciality_occupation.Text = occupation;
                lblphone.Text = phone;
                lblAddress.Text = address;
                lblExperience_Diagnosis.Text = diagnosis;
            }
            BindLastDoctor.Visibility = Visibility.Hidden;
        }
        private void docOrNot()
        {

            using (var db = new DataClasses1DataContext())
            {

                var check = (from User in db.Users
                             where User.UserID == ProfileIdentifier.userID
                             select User.Doctor).SingleOrDefault();

                if (check == false)
                {
                    profileDataBinderC(ProfileIdentifier.userID);
                }
                else if (check == true)
                {
                    profileDataBinderD(ProfileIdentifier.userID,true);
                }
            } 
        }
        private void loaded(object sender, RoutedEventArgs e)
        {
          
        }
    }
}
