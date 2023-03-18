using System;
using System.Collections.Generic;
using System.Data.Common;
using Clinic.Data.Models;

namespace Clinic.Data.Helpers
{
    public static class DatabaseHelper
    {
        public static string ConvertToSqlString(string str)
        {
            return "'" + str + "'";
        }

        public static ADate BoxingDate(DbDataReader reader)
        {
            ADate date = new ADate();
            date.Text = reader["Text"].ToString();
            date.color = (int)reader["Color"];
            date.StartTime = (DateTime)reader["StartTime"];
            date.EndTime = (DateTime)reader["EndTime"];
            date.Id = (int)reader["IdCalendar"];
            return date;
        }

        public static string BuildStringCommandGettingFieldsFromTableWithoutCondition(string tableName, List<string> fields)
        {
            return "SELECT " + BuildStringFieldsInCommand(fields) + " FROM " + tableName;
        }

        private static string BuildStringFieldsInCommand(List<string> fields)
        {
            if (fields == null || fields.Count == 0)
            {
                return "*";
            }
            string result = "";
            for (int i = 0; i < fields.Count - 1; i++)
            {
                result += (fields[i] + ',');
            }
            result += fields[fields.Count - 1];
            return result;
        }

        public static string BuildFirstPartUpdateQuery(string nameOfTable, List<string> nameOfColumns, List<string> values)
        {
            string strCommand = "UPDATE " + nameOfTable + " SET ";
            for (int i = 0; i < nameOfColumns.Count; i++)
            {
                if (nameOfColumns[i] != "Id")
                {
                    strCommand += nameOfColumns[i] + "='" + values[i] + "',";
                }
            }
            strCommand = strCommand.Remove(strCommand.Length - 1);
            return strCommand;
        }
    }
}
