using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinic.Helpers;
using Clinic.Database;
using System.Data.Common;

namespace Clinic.Extensions.LoaiKham
{
    public partial class themLoaiForm : Form
    {
        private IDatabase db = DatabaseFactory.Instance;
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
            if (DatabaseFactory.Instance != null)
            {
                DatabaseFactory.Instance.InsertRowToTable(ClinicConstant.LoaiKhamTable, new List<string>() { ClinicConstant.LoaiKhamTable_Nameloaikham }, new List<string>() {txt_type.Text });
                MessageBox.Show("Thêm thành công", "Thông báo");
                FillGridView();
            }
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
            string strcmd = "select * from loaikham";

            using (DbDataReader reader = db.ExecuteReader(strcmd,null) as DbDataReader)
            {
                while (reader.Read())
                {
                    int index = dataGridView1.Rows.Add();
                    DataGridViewRow row = dataGridView1.Rows[index];
                    row.Cells["id"].Value = reader[0].ToString();
                    row.Cells["NameType"].Value = reader[1].ToString();
                }
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
