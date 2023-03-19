using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Clinic.Data.Database;
using Clinic.Helpers;

namespace Clinic.Extensions.LoaiKham
{
    public partial class themLoaiForm : Form
    {
        private readonly IDatabase database = DatabaseFactory.Instance;
        public themLoaiForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(ErrorProviderHelper.GetInstance.GetError(txt_type)))
            {
                MessageBox.Show(ErrorProviderHelper.GetInstance.GetError(txt_type), "Thông báo");
                return;
            }
            database.InsertRowToTable(DatabaseContants.tables.loaikham, new List<string>() { DatabaseContants.LoaiKham.Nameloaikham }, new List<string>() { txt_type.Text });
            MessageBox.Show("Thêm thành công", "Thông báo");
            FillGridView();
        }

        private void themLoaiForm_Load(object sender, EventArgs e)
        {
            FillGridView();
            if (string.IsNullOrEmpty(txt_type.Text))
            {
                ErrorProviderHelper.GetInstance.SetError(txt_type, "Bạn không được để trống ô này..");
            }
            else
                ErrorProviderHelper.GetInstance.SetError(txt_type, "");
        }
        private void FillGridView()
        {
            dataGridView1.Rows.Clear();
            foreach (var loaiKham in database.GetAllLoaiKham())
            {
                int index = dataGridView1.Rows.Add();
                DataGridViewRow row = dataGridView1.Rows[index];
                row.Cells["id"].Value = loaiKham.Id;
                row.Cells["NameType"].Value = loaiKham.TenLoaiKham;
            }
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_type.Text))
            {
                ErrorProviderHelper.GetInstance.SetError(txt_type, "Bạn không được để trống ô này..");
            }
            else
                ErrorProviderHelper.GetInstance.SetError(txt_type, "");
        }

    }
}
