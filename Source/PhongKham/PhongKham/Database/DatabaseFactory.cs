using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clinic.Helpers;
using MySql.Data.MySqlClient;

namespace Clinic.Database
{
    public class DatabaseFactory
    {
        private static IDatabase instance;
        private static IDatabase instance2;
        private static IDatabase instance3;

        public static IDatabase Instance
        {
            get {
                if (instance == null)
                {
                    throw new Exception("Object not created");
                }
                return DatabaseFactory.instance; 
            }
        }
        public static IDatabase Instance2
        {
            get
            {
                if (instance == null)
                {
                    throw new Exception("Object not created");
                }
                return DatabaseFactory.instance2;
            }
        }

        public static IDatabase Instance3
        {
            get
            {
                if (instance3 == null)
                {
                    throw new Exception("Object not created");
                }
                return DatabaseFactory.instance3;
            }
        }
        
        public static void CreateNewDatabase(string kindOfDatabase,DbConStringBuilder strBuilder)
        {
            //if else here
            MySqlConnectionStringBuilder stringBuilder = new MySqlConnectionStringBuilder();
            StringBuilderCopy(strBuilder, stringBuilder);
            instance = new MySqlDatabase(stringBuilder.ConnectionString + ';' + "charset = utf8;");
            instance2 = new MySqlDatabase(stringBuilder.ConnectionString + ';' + "charset = utf8;");
            instance3 = new MySqlDatabase(stringBuilder.ConnectionString + ';' + "charset = utf8;");
        }

        private static void StringBuilderCopy(DbConStringBuilder strBuilder, MySqlConnectionStringBuilder stringBuilder)
        {
            stringBuilder.Server = strBuilder.Server;
            stringBuilder.UserID = strBuilder.UserID;
            stringBuilder.Password = strBuilder.Password;
            stringBuilder.Database = strBuilder.Database;
            if(Setting.SslModeDatabase)
                stringBuilder.SslMode = MySqlSslMode.Required;
            else
                stringBuilder.SslMode = MySqlSslMode.None;
            stringBuilder.Replication = false;
        }

        private DatabaseFactory()
        {
            
        }



    }
}
