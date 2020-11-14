using Clinic.Database;
using Clinic.Helpers;
using Clinic.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Clinic.Extensions
{
    public partial class ReasonAppointment : Form
    {
        private IDatabase db = DatabaseFactory.Instance;
        private List<ReasonApointmentModel> listReason = new List<ReasonApointmentModel>();
        public ReasonAppointment()
        {
            InitializeComponent();
        }

        private void txt_reason_Validated(object sender, EventArgs e)
        {
            TextBox txt_text = (TextBox)sender;
            CheckError(txt_text.Text, txt_text);
        }

        private void ReasonAppointment_Load(object sender, EventArgs e)
        {
            CheckError(txt_reason.Text, txt_reason);
            LoadData();
        }

        private void LoadData()
        {
            dataGridView1.Rows.Clear();
            listReason = db.GetListReason();

            for (int i = 0; i < listReason.Count; i++)
            {
                int index = dataGridView1.Rows.Add();
                DataGridViewRow row = dataGridView1.Rows[index];
                row.Cells[0].Value = listReason[i].ID;
                row.Cells[1].Value = listReason[i].Reason;
                row.Cells[2].Value = "Xóa";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!Validate())
            {
                MessageBox.Show("Bạn chưa nhập giá trị", "Thông báo");
            }
            ReasonApointmentModel reason = listReason.Where(m => m.Reason == txt_reason.Text).FirstOrDefault();
            if (reason != null)
            {
                MessageBox.Show("Lí do này đã tồn tại", "Thông báo");
            }
            else
            {
                List<string> columns = new List<string>() { "reason" };
                List<string> values = new List<string>() {txt_reason.Text};
                db.InsertRowToTable(DatabaseContants.tables.reasonapoinment, columns, values);
            }
            LoadData();
        }

        private void CheckError(string text,Control control)
        {
            if (string.IsNullOrEmpty(text))
            {
                ErrorProviderHelper.GetInstance.SetError(control, "Bạn không được để trống.!!");
            }
            else
            {
                ErrorProviderHelper.GetInstance.SetError(control, "");
            }
        }
        private bool Validate()
        {
            if (string.IsNullOrEmpty(ErrorProviderHelper.GetInstance.GetError(txt_reason)))
            {
                return true;
            }
            return false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex == 2)
            {
                db.DeleteRowInTableByID(DatabaseContants.tables.reasonapoinment, "ID", dataGridView1[0, e.RowIndex].Value.ToString());
                LoadData();
            }
        }
    }
}
