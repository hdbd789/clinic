using System;
using System.Windows.Forms;
using Clinic.Data.Models;

namespace Clinic
{
    public partial class SearchForm : Form
    {
        public static System.Windows.Forms.DataGridView dataGridView1;
        public delegate void SendCommandProcessFromSearchForm(string idHistory , RecordType recordType);
        public static SendCommandProcessFromSearchForm sendCommand;


        public SearchForm()
        {
            dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(dataGridView1)).BeginInit();
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridView1.Location = new System.Drawing.Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new System.Drawing.Size(1106, 562);
            dataGridView1.TabIndex = 0;
            this.Controls.Add(dataGridView1);
            dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            InitializeComponent();
            ((System.ComponentModel.ISupportInitialize)(dataGridView1)).EndInit();
            this.WindowState = Clinic.Properties.Settings.Default.State;
            if (this.WindowState == FormWindowState.Normal) this.Size = Clinic.Properties.Settings.Default.Size;
            this.ResizeEnd+=new EventHandler(SearchForm_ResizeEnd);
            this.KeyPress+=new KeyPressEventHandler(SearchForm_KeyPress);
            dataGridView1.KeyPress += new KeyPressEventHandler(SearchForm_KeyPress);
        }

        private void SearchForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }

        private void SearchForm_ResizeEnd(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            //if (this.WindowState == FormWindowState.Normal) Clinic.Properties.Settings.Default.Size = this.Size;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string IdHistory = dataGridView1.Rows[e.RowIndex].Cells["CollIDHistory"].Value.ToString();
                RecordType recordType = (RecordType)dataGridView1.Rows[e.RowIndex].Cells["ColTypeRecord"].Value;

                sendCommand(IdHistory, recordType);
                this.Close();
            }
        }
    }
}
