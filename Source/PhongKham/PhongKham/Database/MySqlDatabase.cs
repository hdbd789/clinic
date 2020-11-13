using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Clinic.Database
{
    public class MySqlDatabase : Database<MySqlParameter, MySqlDataReader, MySqlConnection, MySqlTransaction, MySqlDataAdapter, MySqlCommand, MySqlConnectionStringBuilder>
    {
        public MySqlDatabase(string strCon)
            : base(strCon)
        {

        }



        
    }
}
