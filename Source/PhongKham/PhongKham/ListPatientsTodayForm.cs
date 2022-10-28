using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinic.Models;
using PhongKham;

namespace Clinic
{
    public partial class ListPatientsTodayForm : Form
    {
        public delegate void SendCommandKham(string id, string name,string state);
        public delegate void AdvisoryClick(string id, string name, string state);
        public event SendCommandKham sendCommandKham;

        public event AdvisoryClick advisoryClick;

        public ListPatientsTodayForm()
        {
            InitializeComponent();
        }

        //protected override void OnMouseLeave(EventArgs e)
        //{
        //    if (this.ClientRectangle.Contains(this.PointToClient(Control.MousePosition)))
        //    {
        //        return;
        //    }
        //    else
        //    {
        //        base.OnMouseLeave(e);
        //    }
        //}
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
                row.Tag = listPatientToday[i].Type;
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
                dataGridView1.Columns["ColAction"].Index) return;

            //MessageBox.Show(dataGridView1.Rows[1].Cells[2].Value.ToString());
            string state = dataGridView1.Rows[e.RowIndex].Cells["ColumnNhietDo"].Value.ToString() + ';' + dataGridView1.Rows[e.RowIndex].Cells["ColumnHuyetAp"].Value.ToString() + ';' + dataGridView1.Rows[e.RowIndex].Cells["ColWeight"].Value.ToString();

            RecordType recordType = (RecordType)dataGridView1.Rows[e.RowIndex].Tag;
            if(recordType == RecordType.Examination)
            {
                sendCommandKham(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(), state);
            }
            else
            {
                advisoryClick(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(), state);
            }
            
            dataGridView1.Rows.RemoveAt(e.RowIndex);
        }


    }
}
