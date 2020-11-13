using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PhongKham;

namespace Clinic
{
    public partial class ListPatientsTodayForm : Form
    {


        public delegate void SendCommandKham(string id, string name,string nhietdo);
        public SendCommandKham sendCommandKham;

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


        internal void PutIntoGrid(Dictionary<string, string> listPatientToday)
        {
            dataGridView1.Rows.Clear();

            List<string> keys = listPatientToday.Keys.ToList();
            for (int i = 0; i < keys.Count; i++)
            {
                int index = dataGridView1.Rows.Add();
                DataGridViewRow row = dataGridView1.Rows[index];
                row.Cells[1].Value = keys[i];
                string[] nameAndState = listPatientToday[keys[i]].Split(';');
                row.Cells[2].Value = nameAndState[0];
                row.Cells["ColumnNhietDo"].Value = nameAndState[1];
                row.Cells["ColumnHuyetAp"].Value = nameAndState[2];
                row.Cells["ColWeight"].Value = nameAndState[3];
                row.Cells["ColHeight"].Value = nameAndState[4];
            }
        }
                    
        void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks that are not on button cells.  
            if (e.RowIndex < 0 || e.ColumnIndex !=
                dataGridView1.Columns["KhamVaXoa"].Index) return;

            //MessageBox.Show(dataGridView1.Rows[1].Cells[2].Value.ToString());
            string state = dataGridView1.Rows[e.RowIndex].Cells["ColumnNhietDo"].Value.ToString() + ';' + dataGridView1.Rows[e.RowIndex].Cells["ColumnHuyetAp"].Value.ToString() + ';' + dataGridView1.Rows[e.RowIndex].Cells["ColWeight"].Value.ToString() + ';' + dataGridView1.Rows[e.RowIndex].Cells["ColHeight"].Value.ToString();
            sendCommandKham(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(), state);
            dataGridView1.Rows.RemoveAt(e.RowIndex);
        }


    }
}
