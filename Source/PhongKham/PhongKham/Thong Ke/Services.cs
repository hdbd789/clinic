using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinic.Models;
using Clinic.Helpers;
using PhongKham;
using Clinic.Models.ItemMedicine;
using Clinic.Database;
using System.Data.Common;

namespace Clinic
{
    public partial class Services : Form
    {
        private IDatabase db = DatabaseFactory.Instance;
        public delegate void RefreshMedicines4MainForm();
        public static RefreshMedicines4MainForm refreshMedicines4MainForm;
        public Services()
        {
            InitializeComponent();
            this.FormClosing+=new FormClosingEventHandler(Services_FormClosing);
        }
        private void Services_FormClosing(object sender, FormClosingEventArgs e)
        {
            refreshMedicines4MainForm();
        }

        private void RefreshIdOfNewMedicine()
        {


            string strCommand = " SELECT ID FROM Medicine ORDER BY ID DESC LIMIT 1";
            using (DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader)
            {
                reader.Read();
                int intTemp = 0;
                if (reader.HasRows)
                {
                    string temp = reader.GetString(0);

                    try
                    {
                        intTemp = int.Parse(temp);

                    }
                    catch (Exception)
                    {
                    }
                }
                else
                {
                    intTemp = 0;
                }
                int newId = intTemp + 1;
                string strNewID = String.Format("{0:000000}", newId);

                lblNewIdService.Text = strNewID;
            }


        }

        private void Services_Load(object sender, EventArgs e)
        {
            RefreshIdOfNewMedicine();
            dataGridView1.Rows.Clear();
            List<IMedicine> listServices = Helper.GetAllServiceFromDb();
            for (int i = 0; i < listServices.Count; i++)
            {
                int index = dataGridView1.Rows.Add();
                DataGridViewRow row = dataGridView1.Rows[index];
                row.Cells["ColumnId"].Value = listServices[i].Id;
                row.Cells["ColumnName"].Value = listServices[i].Name;
                row.Cells["ColumnCostOut"].Value = listServices[i].CostOut.ToString();
                row.Cells[this.ColumnAdmin.Name].Value = listServices[i].Admin;
                row.Cells[this.ColumnUpdate.Name].Value ="Cập Nhật";
                row.Cells[this.ColumnDelete.Name].Value = "Xóa";
            }
        }



        private void buttonServicesOK_Click(object sender, EventArgs e)
        {
            int giaOut;
            if (textBoxServices.Text[0] != '@' || textBoxServices.Text == "")
            {
                MessageBox.Show("Tên dịch vụ phải bắt đầu với ký tự '@'", "Chú ý"); // phân biệt với thuốc
                return;
            }
            try
            {
                giaOut = int.Parse(textBoxServicesCost.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xin nhập lại giá. Giá không phù hợp!", "Chú ý");
                return;
            }
            string Id = lblNewIdService.Text;
            if (!Helper.CheckMedicineExists(db, Id))
            {
                List<string> columns = new List<string>() { "Name", "CostOut", "ID", ClinicConstant.MedicineTable_Admin };
                List<string> values = new List<string>() { textBoxServices.Text.Trim(), giaOut.ToString(), Id, textBoxAdminOfService.Text };

                db.InsertRowToTable(ClinicConstant.MedicineTable, columns, values);
                MessageBox.Show("Thêm mới dịch vụ thành công");
            }

            RefreshIdOfNewMedicine();
            buttonClear_Click(sender, e);
            Services_Load(sender, e);
        }

        void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks that are not on button cells.  
            if (e.RowIndex < 0)  return;
            if (e.ColumnIndex == dataGridView1.Columns[ColumnUpdate.Name].Index)
            {

                string giaOut = dataGridView1.Rows[e.RowIndex].Cells[this.ColumnCostOut.Name].Value.ToString();
                string adminOfService = dataGridView1.Rows[e.RowIndex].Cells[this.ColumnAdmin.Name].Value.ToString();
                string Id = dataGridView1.Rows[e.RowIndex].Cells[this.ColumnId.Name].Value.ToString();
                string name = dataGridView1.Rows[e.RowIndex].Cells[this.ColumnName.Name].Value.ToString();
                string strCommand = "Update Medicine Set CostOut =" + giaOut.ToString() + "," + ClinicConstant.MedicineTable_Name + " = " + Helper.ConvertToSqlString(name) + "," + ClinicConstant.MedicineTable_Admin + " = " + Helper.ConvertToSqlString(adminOfService) + " Where Id =" + Id;
                DatabaseFactory.Instance.ExecuteNonQuery(strCommand, null);
                MessageBox.Show("Cập nhật dịch vụ thành công");
                Services_Load(sender, e);
            }
            else if (e.ColumnIndex == dataGridView1.Columns[this.ColumnDelete.Name].Index)
            {
                string Id = dataGridView1.Rows[e.RowIndex].Cells[this.ColumnId.Name].Value.ToString();
                DialogResult dlgResult = MessageBox.Show("Có thật sự muốn xóa dịch vụ này?", "Chú ý", MessageBoxButtons.YesNo);
                if (dlgResult == System.Windows.Forms.DialogResult.Yes)
                {
                    string strCommand = "Delete From medicine Where Id =" + Id;
                    DatabaseFactory.Instance.ExecuteNonQuery(strCommand, null);
                    MessageBox.Show("Xóa dịch vụ thành công");
                    Services_Load(sender, e);
                }
            }
            
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxServicesCost.Text = "";
            textBoxServices.Text = "@";
            textBoxAdminOfService.Text = "";
        }




    }
}
