using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Clinic;
using Clinic.Business;
using Clinic.Data.Database;
using Clinic.Helpers;
using log4net;
using MySql.Data.MySqlClient;

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
                DatabaseFactory.CreateNewDatabase("", DatabaseFactory.GetConnectionString(lines[0], lines[1]));
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
    }
}
