using System;
using Clinic.Data.Setting;
using MySql.Data.MySqlClient;

namespace Clinic.Data.Database
{
    public class DatabaseFactory
    {
        private static IDatabase instance;
        private static IDatabase instance2;
        private static IDatabase instance3;
        private static MySqlConnectionStringBuilder stringBuilderData;

        public static IDatabase Instance
        {
            get
            {
                if (instance == null)
                {
                    throw new Exception("Object not created");
                }
                return instance;
            }
        }
        public static IDatabase Instance2
        {
            get
            {
                if (instance2 == null)
                {
                    throw new Exception("Object not created");
                }
                return instance2;
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
                return instance3;
            }
        }

        public static IDatabase GetNewInstance()
        {
            return new MySqlDatabase(stringBuilderData.ConnectionString + ';' + "charset = utf8;");
        }

        public static void CreateNewDatabase(string kindOfDatabase, DbConStringBuilder strBuilder)
        {
            //if else here
            stringBuilderData = new MySqlConnectionStringBuilder();
            StringBuilderCopy(strBuilder, stringBuilderData);
            instance = new MySqlDatabase(stringBuilderData.ConnectionString + ';' + "charset = utf8;");
            instance2 = new MySqlDatabase(stringBuilderData.ConnectionString + ';' + "charset = utf8;");
            instance3 = new MySqlDatabase(stringBuilderData.ConnectionString + ';' + "charset = utf8;");
        }

        private static void StringBuilderCopy(DbConStringBuilder strBuilder, MySqlConnectionStringBuilder stringBuilder)
        {
            stringBuilder.Server = strBuilder.Server;
            stringBuilder.UserID = strBuilder.UserID;
            stringBuilder.Password = strBuilder.Password;
            stringBuilder.Database = strBuilder.Database;
            if (DatabaseSetting.SslModeDatabase)
                stringBuilder.SslMode = MySqlSslMode.Required;
            else
                stringBuilder.SslMode = MySqlSslMode.Disabled;
            stringBuilder.Replication = false;
        }

        private DatabaseFactory()
        {

        }
        public static DbConStringBuilder GetConnectionString(string passSql, string IPAddress)
        {
            DbConStringBuilder strBuilder = new DbConStringBuilder
            {
                Server = IPAddress == "..." ? "localhost" : IPAddress,
                UserID = "root",
                Password = passSql,
                Database = DatabaseSetting.DatabaseName
            };
            return strBuilder;
        }


    }
}
