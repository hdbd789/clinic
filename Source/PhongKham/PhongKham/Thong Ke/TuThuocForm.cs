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
using Clinic.Thong_Ke;
using Clinic.MessageBoxControl;
using Clinic.Gui;

namespace Clinic
{
    public partial class TuThuocForm : Form
    {

        public delegate void RefreshMedicines4MainForm();
        public static RefreshMedicines4MainForm refreshMedicines4MainForm;
        private IDatabase db = DatabaseFactory.Instance;
        public TuThuocForm()
        {
            InitializeComponent();
            this.FormClosing+=new FormClosingEventHandler(TuThuocForm_FormClosing);
        }
        private void TuThuocForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            refreshMedicines4MainForm();
        }

        private void TuThuocForm_Load(object sender, EventArgs e)
        {
            RefreshIdOfNewMedicine();
            dataGridView1.Rows.Clear();
            List<IMedicine> listMedicines = Helper.GetAllMedicineFromDb();

            for (int i = 0; i < listMedicines.Count; i++)
            {
                int index = dataGridView1.Rows.Add();
                DataGridViewRow row = dataGridView1.Rows[index];
                row.Cells["ColumnId"].Value = listMedicines[i].Id;
                row.Cells["ColumnName"].Value = listMedicines[i].Name;
                row.Cells["ColumnCount"].Value = listMedicines[i].Count.ToString();
                row.Cells["ColumnCostIn"].Value = listMedicines[i].CostIn.ToString();
                row.Cells["ColumnCostOut"].Value = listMedicines[i].CostOut.ToString();
                row.Cells["ColumnInputDay"].Value = listMedicines[i].InputDay.ToString("dd-MM-yyyy");
                row.Cells[this.ColumnHDSD.Name].Value = listMedicines[i].HDSD.ToString();
                row.Cells[this.ColumnAddCount.Name].Value = "Thêm số lượng";
                row.Cells[this.ColumnUpdate.Name].Value = "Cập Nhật";
                row.Cells[this.ColumnDelete.Name].Value = "Xóa";
                row.Cells[this.col_history.Name].Value = "Xem thêm";
            }
        }
        private void ClearInputNewMedicine()
        {
            txtBoxInputMedicineNewName.Clear();
            txtBoxInputMedicineNewCount.Clear();
            txtBoxInputMedicineNewCostOut.Clear();
            txtBoxInputMedicineNewCostIn.Clear();
        }


        private void btnInputMedicineNewOk_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                MessageBox.Show("Bạn nhập không đúng định dạng");
                return;
            }

            if (txtBoxInputMedicineNewName.Text.Contains(','))
            {
                MessageBox.Show("Tên thuốc không được chứa dấu phẩy .Gợi ý: dấu chấm ");
                return;
            }
            if (string.IsNullOrEmpty(txtBoxInputMedicineNewName.Text))
            {
                MessageBox.Show("Tên thuốc không được để trống ");
                return;
            }
            string strCommand = "Select Name From medicine  Where Name = " + Helper.ConvertToSqlString(this.txtBoxInputMedicineNewName.Text);
            using (DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader)
            {
                reader.Read();
                if (reader.HasRows == true) //level 2
                {
                    MessageBox.Show("Ten Thuoc Bi Trung, Xin Nhap Lai Ten Khac");
                    return;
                }
            }

            Medicine medicine = new Medicine();
            medicine.Name = txtBoxInputMedicineNewName.Text.Trim();
            medicine.InputDay = dateTimePicker3.Value;
            try
            {
                medicine.CostOut = int.Parse(txtBoxInputMedicineNewCostOut.Text);
                medicine.CostIn = int.Parse(txtBoxInputMedicineNewCostIn.Text);
                medicine.Count = int.Parse(txtBoxInputMedicineNewCount.Text);
                medicine.Id = lblInputMedicineNewId.Text;
                medicine.HDSD = textBoxMedicineHdsd.Text;
            }
            catch (Exception)
            {
            }


            if (medicine.CostOut < medicine.CostIn)
            {
                MessageBox.Show("Giá Out không thể nhỏ hơn giá In!", "Lỗi");
                return;
            }

            // Add into table history medicine
            AddMedicineIntoHistory(medicine.Id,medicine.Count.ToString(),medicine.Count.ToString(),medicine.CostIn.ToString(),medicine.CostOut.ToString());

            List<string> columns = new List<string>() { "Name", "Count", "CostIn", "CostOut", "InputDay", "ID", "Hdsd" };
            List<string> values = new List<string>() { medicine.Name, medicine.Count.ToString(), medicine.CostIn.ToString(), medicine.CostOut.ToString(), medicine.InputDay.ToString("yyyy-MM-dd"), medicine.Id, medicine.HDSD };
            db.InsertRowToTable("Medicine", columns, values);
            MessageBox.Show("Thêm mới thuốc thành công");
            //InitInputMedicineMySql();
            //InitComboboxMedicinesMySql();
            RefreshIdOfNewMedicine();
            ClearInputNewMedicine();
            TuThuocForm_Load(sender, e);
        }

        private void RefreshIdOfNewMedicine()
        {
            string strCommand = string.Format("SELECT Id FROM {0} ORDER BY Id DESC LIMIT 1", DatabaseContants.tables.medicine);
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

                lblInputMedicineNewId.Text = strNewID;
            }


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string namePDF = "TuThuoc";
            Helper.CreateAPdfThongKe(this.dataGridView1, namePDF);
            this.PDFShowMedicines.LoadFile("TuThuoc.pdf");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks that are not on button cells.  
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex == dataGridView1.Columns[ColumnUpdate.Name].Index)
            {
                if (!ValidateGridForm(e.RowIndex))
                {
                    MessageBox.Show("Bạn nhập rỗng hoặc sai định dạng", "Thông báo");
                    return;
                }
                string giaIn = dataGridView1.Rows[e.RowIndex].Cells[this.ColumnCostIn.Name].Value.ToString();
                string giaOut = dataGridView1.Rows[e.RowIndex].Cells[this.ColumnCostOut.Name].Value.ToString();
                string count = dataGridView1.Rows[e.RowIndex].Cells[this.ColumnCount.Name].Value.ToString();
                string hdsd = dataGridView1.Rows[e.RowIndex].Cells[this.ColumnHDSD.Name].Value.ToString();
                string Id = dataGridView1.Rows[e.RowIndex].Cells[this.ColumnId.Name].Value.ToString();
                string name = dataGridView1.Rows[e.RowIndex].Cells[this.ColumnName.Name].Value.ToString();

                int countHistory = db.GetCountFromMecidicByName(name);
                int countInput = int.Parse(count);

                if (countInput < countHistory)
                {
                    MessageBox.Show("Bạn update số lượng nhỏ hơn tồn kho","Thông báo");
                    return;
                }
                
                string strCommand = "Update " + DatabaseContants.tables.medicine +
                    " Set CostOut =" + giaOut.ToString()
                    + "," +
                    DatabaseContants.medicine.Name + " = " + Helper.ConvertToSqlString(name)
                    + "," +
                    DatabaseContants.medicine.Hdsd + " = " + Helper.ConvertToSqlString(hdsd)
                    + "," +
                    DatabaseContants.medicine.Count + " = " + Helper.ConvertToSqlString(count)
                    + "," +
                    DatabaseContants.medicine.CostIn + " = " + Helper.ConvertToSqlString(giaIn)
                    + "," +
                    DatabaseContants.medicine.InputDay + " = " + Helper.ConvertToSqlString(DateTime.Now.ToString("yyyy-MM-dd"))
                    + " Where Id =" + Id;
                DatabaseFactory.Instance.ExecuteNonQuery(strCommand, null);
                MessageBox.Show("Cập nhật thuốc thành công");
                // Add into table history medicine
                AddMedicineIntoHistory(Id, (countInput - countHistory).ToString(), countInput.ToString(), giaIn, giaOut);
                TuThuocForm_Load(sender, e);
            }
            else if (e.ColumnIndex == dataGridView1.Columns[this.ColumnDelete.Name].Index)
            {
                string Id = dataGridView1.Rows[e.RowIndex].Cells[this.ColumnId.Name].Value.ToString();
                DialogResult dlgResult = MessageBox.Show("Có thật sự muốn xóa dịch vụ này?", "Chú ý", MessageBoxButtons.YesNo);
                if (dlgResult == System.Windows.Forms.DialogResult.Yes)
                {
                    string strCommand = string.Format("Delete From {0} Where Id ={1}", DatabaseContants.tables.medicine, Id);
                    DatabaseFactory.Instance.ExecuteNonQuery(strCommand, null);
                    MessageBox.Show("Xóa thuốc thành công");
                    TuThuocForm_Load(sender, e);
                }
            }
            else if (e.ColumnIndex == dataGridView1.Columns[col_history.Name].Index)
            {
                string Id = dataGridView1.Rows[e.RowIndex].Cells[this.ColumnId.Name].Value.ToString();
                string name = dataGridView1.Rows[e.RowIndex].Cells[this.ColumnName.Name].Value.ToString();
                FormSeemoreMedicine control = new FormSeemoreMedicine(Id, name);
                control.ShowDialog();
            }
            else if (e.ColumnIndex == dataGridView1.Columns[this.ColumnAddCount.Name].Index)
            {
                long countInput = 0;
                if (MessageBoxNumberInput.ShowDialog("Nhập số lượng", ref countInput) == DialogResult.OK)
                {
                    string giaIn = dataGridView1.Rows[e.RowIndex].Cells[this.ColumnCostIn.Name].Value.ToString();
                    string giaOut = dataGridView1.Rows[e.RowIndex].Cells[this.ColumnCostOut.Name].Value.ToString();
                    string count = dataGridView1.Rows[e.RowIndex].Cells[this.ColumnCount.Name].Value.ToString();
                    string Id = dataGridView1.Rows[e.RowIndex].Cells[this.ColumnId.Name].Value.ToString();

                    long countCurrent = long.Parse(count);
                    string strCommand = string.Format("Update {0} set {1} = {2} where {3} = {4}", DatabaseContants.tables.medicine, DatabaseContants.medicine.Count, (countInput + countCurrent).ToString(), DatabaseContants.medicine.Id, Id);
                    DatabaseFactory.Instance.ExecuteNonQuery(strCommand, null);
                    MessageBox.Show("Thêm số lượng thành công");
                    // Add into table history medicine
                    AddMedicineIntoHistory(Id, countInput.ToString(), (countInput + countCurrent).ToString(), giaIn, giaOut);
                    dataGridView1.Rows[e.RowIndex].Cells[this.ColumnCount.Name].Value = (countInput + countCurrent);
                }
            }

        }

        private void AddMedicineIntoHistory(string ID,string count,string countStore, string giaIn, string giaOut)
        {
            // Add into table history medicine
            List<string> columns = new List<string>() { "IdMedicine", "Count", "CostIn", "CostOut", "InputDay", DatabaseContants.lichsunhapthuoc.CountStore };
            List<string> values = new List<string>() { ID, count, giaIn, giaOut, DateTime.Now.ToString("yyyy-MM-dd"),countStore };
            db.InsertRowToTable(DatabaseContants.tables.lichsunhapthuoc, columns, values);
        }
        private void txtBoxInputMedicineNewCount_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            try
            {
                long count = long.Parse(textBox.Text);
                ErrorProviderHelper.GetInstance.SetError(textBox, "");
            }
            catch
            {
                ErrorProviderHelper.GetInstance.SetError(textBox, "Bạn nhập không phải là số.");
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrEmpty(txtBoxInputMedicineNewCount.Text) || !string.IsNullOrEmpty(ErrorProviderHelper.GetInstance.GetError(txtBoxInputMedicineNewCount)))
            {
                return false;
            }

            if (string.IsNullOrEmpty(txtBoxInputMedicineNewCostIn.Text) || !string.IsNullOrEmpty(ErrorProviderHelper.GetInstance.GetError(txtBoxInputMedicineNewCostIn)))
            {
                return false;
            }

            if (string.IsNullOrEmpty(txtBoxInputMedicineNewCostOut.Text) || !string.IsNullOrEmpty(ErrorProviderHelper.GetInstance.GetError(txtBoxInputMedicineNewCostOut)))
            {
                return false;
            }
            return true;
        }

        private bool ValidateGridForm(int row)
        {
            if(dataGridView1[1,row].Value == null || string.IsNullOrEmpty(dataGridView1[1,row].Value.ToString()))
            {
                return false;
            }
            if (dataGridView1[2, row].Value == null || !IsParseLong(dataGridView1[2, row].Value.ToString()))
            {
                return false;
            }
            if (dataGridView1[3, row].Value == null || !IsParseLong(dataGridView1[3, row].Value.ToString()))
            {
                return false;
            }
            if (dataGridView1[4, row].Value == null || !IsParseLong(dataGridView1[4, row].Value.ToString()))
            {
                return false;
            }
            return true;
        }
        private bool IsParseLong(string text)
        {
            try
            {
                long t = long.Parse(text);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Thongkethuoc thongke = new Thongkethuoc();
            thongke.ShowDialog();
        }

    }
}
