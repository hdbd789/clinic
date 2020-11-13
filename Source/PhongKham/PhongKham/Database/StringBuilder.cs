using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace Clinic.Database
{
    public class DbConStringBuilder 
    {
        private string server;
        public string Server
        {
            get { return server; }
            set { server = value; }
        }
        private string userID;

        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private string database;

        public string Database
        {
            get { return database; }
            set { database = value; }
        }

    }
}
