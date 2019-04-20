using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class ProfileIdentifier
    {
        private static Int32 UserID;
        private static string Password;
        public static string password
        {
            get { return Password; }
            set { Password = value;}

        }
        public static int userID
        {

            get { return UserID; }
            set { UserID = value; }

        }
        private static string Username;
        public static string username {

            get {  return Username;}
            set { Username = value; }

        }
        
    }
}
