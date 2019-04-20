using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;

namespace Project
{
    class Profilebinder : INotifyPropertyChanged
    {
        public string Fullname;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
       
        public void setUserID()
        {
            
           
            
            using (var db = new DataClasses1DataContext())
            {
                var id = (from User in db.Users
                          where User.Username == ProfileIdentifier.username
                          select User.UserID).FirstOrDefault();  
                    
                ProfileIdentifier.userID = Convert.ToInt32(id);
               
            }

                

        }
        
        public void setUserName(string a)
        {
            ProfileIdentifier.username = a;        
        }

        internal void setPassword(string pass)
        {
            ProfileIdentifier obj = new ProfileIdentifier();
            ProfileIdentifier.password = pass;
        }

        public string fullname
        {
            set { Fullname = value;
                OnPropertyChanged("Fullname");
            }
            get { return Fullname;

            }
        }
        public static void profileDataBinderC()
        {
            string fullname, fathername, email, gender, phone, address, occupation, diagnosis, bio;
            Profile profile = new Profile();
            using (var db = new DataClasses1DataContext())
            {
                 fullname = (from Customer in db.Customers
                          where Customer.uid == ProfileIdentifier.userID
                          select Customer.Full_Name).SingleOrDefault();
                
                 fathername = (from Customer in db.Customers
                             where Customer.uid == ProfileIdentifier.userID
                             select Customer.Father_Name).SingleOrDefault();
                 email = (from Customer in db.Customers
                               where Customer.uid == ProfileIdentifier.userID
                               select Customer.Email).SingleOrDefault();
                 gender = (from Customer in db.Customers
                               where Customer.uid == ProfileIdentifier.userID
                               select Customer.Sex).SingleOrDefault();
                 phone = (from Customer in db.Customers
                               where Customer.uid == ProfileIdentifier.userID
                               select Customer.Phone).SingleOrDefault();
                 address = (from Customer in db.Customers
                     where Customer.uid == ProfileIdentifier.userID
                     select Customer.Address).SingleOrDefault();
                 occupation = (from Customer in db.Customers
                     where Customer.uid == ProfileIdentifier.userID
                     select Customer.Occupation).SingleOrDefault();
                 diagnosis = (from Customer in db.Customers
                     where Customer.uid == ProfileIdentifier.userID
                     select Customer.Diagnosis).SingleOrDefault();
                 bio = (from Customer in db.Customers
                           where Customer.uid == ProfileIdentifier.userID
                           select Customer.bio).SingleOrDefault();
            }
            
            
            
           
        }
    }
}
