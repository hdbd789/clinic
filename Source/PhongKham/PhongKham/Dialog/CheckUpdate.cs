using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clinic.Business;
using Clinic.Helpers;
using log4net;
using Octokit;

namespace Clinic.Dialog
{
    public partial class CheckUpdate : Form
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private const string REPOSITORY_NAME = "clinic";
        private const string OWNER_NAME = "hdbd789";
        private string urlPackage;
        private string newVersion;
        public CheckUpdate()
        {
            InitializeComponent();
        }

        private async void CheckUpdate_Load(object sender, EventArgs e)
        {
            btnUpdate.Enabled = false;
            this.Enabled = false;
            string currentVersion = ApplicationHelper.GetCurrentVersion();
            var release = await GetNewVersion();
            newVersion = release.TagName;
            urlPackage = release.Assets[0].BrowserDownloadUrl;

            lblCurrentVersion.Text = currentVersion;
            lblNewVersion.Text = newVersion;
            btnUpdate.Enabled = currentVersion != newVersion;
            this.Enabled = true;
        }

        private async Task<Release> GetNewVersion()
        {
            try
            {
                var github = new GitHubClient(new ProductHeaderValue("clinicApp"));
                return await github.Repository.Release.GetLatest(OWNER_NAME, REPOSITORY_NAME);
            }
            catch(Exception ex)
            {
                Log.Error(ex.Message, ex);
                MessageBox.Show(ex.Message, "Lỗi");
                return null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo info = new ProcessStartInfo("Update\\UpdateNewVersion.exe", $"{urlPackage} {newVersion}");
                Process.Start(info);
                Close();
                StartApplication.Close();
            }
            catch(Exception ex)
            {
                Log.Error(ex.Message, ex);
            }
        }
    }
}
