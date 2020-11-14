using System;
using System.Windows.Forms;

namespace Clinic.Extensions
{
    public partial class ProgressForm : Form
    {
        public ProgressForm()
        {
            InitializeComponent();
        }

        private void ProgressForm_Load(object sender, EventArgs e)
        {
            this.circularProgress1.Show();
            this.circularProgress1.IsRunning = true;
        }
    }
}
