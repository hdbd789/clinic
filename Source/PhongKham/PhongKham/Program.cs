using System;
using System.Windows.Forms;
using Clinic.Helpers;
using Clinic;
using MySql.Data.MySqlClient;
using System.IO;
using Clinic.Database;
using log4net;
using System.Reflection;
using Clinic.Business;

namespace PhongKham
{
    static class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static MySqlConnection conn;

        [STAThread]
        static void Main()
        {
            log4net.Config.XmlConfigurator.Configure();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!File.Exists("WriteLines.txt"))
            {
                PassSQL SqlForm = new PassSQL();
                SqlForm.ShowDialog();
                if (SqlForm.DialogResult == DialogResult.Cancel)
                {
                    return;
                }
            }
            try
            {
                string[] lines = System.IO.File.ReadAllLines("WriteLines.txt");
                DatabaseFactory.CreateNewDatabase("", GetConnectionString(lines[0], lines[1]));
            }
            catch(Exception e)
            {
                File.Delete("WriteLines.txt");
                MessageBox.Show("Lỗi database! Xin chạy lại chương trình!");
                Log.Error(e.Message, e);
            }
            if (!Helper.CheckAdminExists())
            {
                CreateUserForm createUserForm = new CreateUserForm();
                if (createUserForm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }
            StartApplication.StartApp();
        }

        private static DbConStringBuilder GetConnectionString(string passSql, string IPAddress)
        {
            DbConStringBuilder strBuilder = new DbConStringBuilder
            {
                Server = IPAddress == "..." ? "localhost" : IPAddress,
                UserID = "root",
                Password = passSql,
                Database = "clinic"
            };
            return strBuilder;
        }
    }
}
