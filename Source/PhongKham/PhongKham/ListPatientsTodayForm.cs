using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Clinic.Models;

namespace Clinic
{
    public partial class ListPatientsTodayForm : Form
    {
        public delegate void SendCommandKham(PatientToday patientToday);
        public delegate void AdvisoryClick(PatientToday patientToday);
        public event SendCommandKham sendCommandKham;

        public event AdvisoryClick advisoryClick;

        public ListPatientsTodayForm()
        {
            InitializeComponent();
        }

        private void Form2_MouseLeave(object sender, EventArgs e)
        {
            this.Hide();
        }

        internal void PutIntoGrid(List<PatientToday> listPatientToday)
        {
            dataGridView1.Rows.Clear();

            for (int i = 0; i < listPatientToday.Count; i++)
            {
                int index = dataGridView1.Rows.Add();
                DataGridViewRow row = dataGridView1.Rows[index];
                row.Cells[1].Value = listPatientToday[i].IdPatient;
                row.Cells[2].Value = listPatientToday[i].NamePatient;

                string[] stateParts = listPatientToday[i].State.Split(';');
                row.Cells["ColumnNhietDo"].Value = stateParts[0];
                row.Cells["ColumnHuyetAp"].Value = stateParts[1];
                row.Cells["ColWeight"].Value = stateParts[2];

                row.Tag = listPatientToday[i];
                if (listPatientToday[i].Type == RecordType.Advisory)
                {
                    row.Cells["ColAction"].Value = "Tư vấn";
                }
                else
                {
                    row.Cells["ColAction"].Value = "Khám và xóa";
                }
            }
        }

        void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks that are not on button cells.  
            if (e.RowIndex < 0 || e.ColumnIndex !=
                dataGridView1.Columns["ColAction"].Index)
            {
                return;
            }

            if (!(dataGridView1.Rows[e.RowIndex].Tag is PatientToday patientToday))
            {
                return;
            }
            if (patientToday.Type == RecordType.Examination)
            {
                sendCommandKham(patientToday);
            }
            else
            {
                advisoryClick(patientToday);
            }

            dataGridView1.Rows.RemoveAt(e.RowIndex);
        }
    }
}
