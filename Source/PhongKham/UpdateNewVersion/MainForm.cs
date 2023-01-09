using System;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using log4net;

namespace UpdateNewVersion
{
    public partial class MainForm : Form
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        string _urlPackage;
        string _version;
        string tempFileName;
        public MainForm(string urlPackage, string version)
        {
            _urlPackage = urlPackage;
            _version = version;
            InitializeComponent();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            btnDownload.Enabled = false;
            buttonX1.Enabled = false;
            progressBarX1.Value = 0;

            lblResult.Text = "Đang xử lí ...";
            tempFileName = Path.Combine(Path.GetTempPath(), $"{Path.GetRandomFileName()}.zip");
            WebClient webClient = new WebClient();
            webClient.DownloadProgressChanged += WebClient_DownloadProgressChanged;
            webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;
            webClient.DownloadFileAsync(new Uri(_urlPackage), tempFileName);
        }

        private void WebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            bool isSuccess = ExtractAndCopy();
            progressBarX1.Value = 100;

            if (isSuccess)
            {
                lblResult.Text = "Cập nhật thành công!.";
            }
            else
            {
                lblResult.Text = "Cập nhật thất bại, xin thử lại!.";
                btnDownload.Enabled = true;
            }

            buttonX1.Enabled = true;
        }

        private bool ExtractAndCopy()
        {
            try
            {
                if (File.Exists(tempFileName))
                {
                    string destinationDirectory = Directory.GetParent(Path.GetDirectoryName(Application.ExecutablePath)).FullName;
                    string destinationDirectoryTemp = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}");

                    ZipFile.ExtractToDirectory(tempFileName, destinationDirectoryTemp);
                    CopyDirectory(destinationDirectoryTemp, destinationDirectory);

                    File.Delete(tempFileName);
                    DeleteDirectory(destinationDirectoryTemp);
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                return false;
            }
        }

        private void CopyDirectory(string sourceDirectory, string destinationDirectory)
        {
            if (Directory.Exists(sourceDirectory))
            {
                if (Path.GetFileName(destinationDirectory).ToLower() == "update")
                {
                    return;
                }

                if (!Directory.Exists(destinationDirectory))
                {
                    Directory.CreateDirectory(destinationDirectory);
                }
                string[] files = Directory.GetFiles(sourceDirectory);
                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in files)
                {
                    File.Copy(s, Path.Combine(destinationDirectory, Path.GetFileName(s)), true);
                }

                string[] directories = Directory.GetDirectories(sourceDirectory);
                foreach (string d in directories)
                {
                    CopyDirectory(d, Path.Combine(destinationDirectory, Path.GetFileName(d)));
                }
            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }
        }

        private void DeleteDirectory(string directory)
        {
            if (Directory.Exists(directory))
            {
                string[] files = Directory.GetFiles(directory);
                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in files)
                {
                    File.Delete(s);
                }

                string[] directories = Directory.GetDirectories(directory);
                foreach (string d in directories)
                {
                    DeleteDirectory(Path.Combine(directory, Path.GetFileName(d)));
                }
            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }
        }

        private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBarX1.Value = e.ProgressPercentage;
        }

        private void progressBarX1_Click(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblVersion.Text = _version;
        }
    }
}
