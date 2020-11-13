using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using PhongKham;
using Clinic.Helpers;
using MySql.Data.MySqlClient;
using Clinic.Database;
using System.Text.RegularExpressions;

namespace Clinic
{
    public partial class PassSQL : Form
    {
        public PassSQL()
        {
            InitializeComponent();
            label3.Visible = false;
            maskedTextBox1.Visible = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string IP = maskedTextBox1.Text.Trim();
            IP = Regex.Replace(IP, @"\s", "");
            string[] lines = { textBox1.Text, IP };
            // WriteAllLines creates a file, writes a collection of strings to the file, 
            // and then closes the file.
            System.IO.File.WriteAllLines("WriteLines.txt", lines);
            File.SetAttributes(
               "WriteLines.txt",
               FileAttributes.Archive |
               FileAttributes.Hidden 
             
               );
            
            //test connection ;
            try
            {
 
                if (checkBox1.Checked == false)
                {
                    ///Old structure
                    DbConStringBuilder strBuilder = new DbConStringBuilder();
                    strBuilder.Server = "localhost";
                    strBuilder.UserID = "root";
                    strBuilder.Password = textBox1.Text;
                    //Program.conn = new MySqlConnection(strBuilder.ConnectionString);
                    //Program.conn.Open();
                    //InitDatabase(Program.conn, textBox1.Text);
                    
                    ///New Structure
                    ///
                    DatabaseFactory.CreateNewDatabase("", strBuilder);
                    IDatabase database = DatabaseFactory.Instance;
                    database.CreateDatabase(textBox1.Text);
                }
                else
                {
                   
                    DbConStringBuilder strBuilder = new DbConStringBuilder();
                    strBuilder.Server = IP == "   .   .   ." ? "localhost" : IP;
                    strBuilder.UserID = "root";
                    strBuilder.Password = textBox1.Text;
                    DatabaseFactory.CreateNewDatabase("", strBuilder);
                    IDatabase database = DatabaseFactory.Instance;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối SQl server thất bại , vui lòng thử lại !"+ex.Message);
                File.Delete("WriteLines.txt");
                return;
            }

            this.DialogResult = DialogResult.OK;

        }

        

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            // If the destination directory doesn't exist, create it. 
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location. 
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                label3.Visible = false;
                maskedTextBox1.Visible = false;
            }
            if (checkBox1.Checked == true)
            {
                label3.Visible = true;
                maskedTextBox1.Visible = true;
            }
        }
    }
}
