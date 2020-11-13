using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinic.Database;
using Clinic.Helpers;

namespace Clinic.Thong_Ke
{
    public partial class DiagnosesHistory : Form
    {
        public static readonly DateTime dateHistoryUse = new DateTime(2017,5,14);
        private List<string> listDiagnosesFromHistory;
        private Dictionary<int, string> ListDiagnosesFromDiagnoses;
        private IDatabase db = DatabaseFactory.Instance;
        public DiagnosesHistory(List<string> listDiagnosesFromHistory, Dictionary<int,string> listDiagnosesFromDiagnoses)
        {
            InitializeComponent();
            this.listDiagnosesFromHistory = listDiagnosesFromHistory;
            this.ListDiagnosesFromDiagnoses = listDiagnosesFromDiagnoses;
            this.listDiagnosesFromHistory.Sort();
        }

        private void DiagnosesHistory_Load(object sender, EventArgs e)
        {
            isValid(this.textBoxX1, this.textBoxX1.Text);
            dataGridView1.Rows.Clear();

            for (int i = 0; i < listDiagnosesFromHistory.Count; i++)
            {
                AddRowInDataGridView(listDiagnosesFromHistory[i],"-1",-1,true);
            }

            // from diagnoses

            foreach (int item in ListDiagnosesFromDiagnoses.Keys)
            {
                AddRowInDataGridView(ListDiagnosesFromDiagnoses[item], item.ToString());
            }
            
        }

        private void ValidateInput()
        {
            if (string.IsNullOrEmpty(this.textBoxX1.Text))
            {
                ErrorProviderHelper.GetInstance.SetError(this.textBoxX1, "Bạn chưa nhập tên chẩn đoán");
            }
            else
            {
                ErrorProviderHelper.GetInstance.SetError(this.textBoxX1,"");
            }
        }

        void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks that are not on button cells.  
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex == dataGridView1.Columns[ColumnUpdate.Name].Index)
            {
                if(ExistIdDiagnoses(dataGridView1.Rows[e.RowIndex].Cells[this.ID.Name].Value.ToString()))
                {
                    UpdateTableDiagnoses(dataGridView1.Rows[e.RowIndex].Cells[this.ID.Name].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells[this.ColumnName.Name].Value.ToString());

                }
                //UpdateRow(dataGridView1.Rows[e.RowIndex].Cells[this.ColumnName.Name].Value.ToString(), listDiagnosesFromHistory[e.RowIndex]);
                MessageBox.Show("Cập nhật dịch vụ thành công");
                //listDiagnosesFromHistory = Helpers.Helper.GetAllDiagnosesFromHistory(DatabaseFactory.Instance);
                //DiagnosesHistory_Load(sender, e);
            }
        }
        #region Command

        private void UpdateRow(string value,string valuePrivious)
        {
            string strCommand = string.Format("Update {0} Set {1} = {2} where {3} = {4}", ClinicConstant.HistoryTable, ClinicConstant.HistoryTable_Diagnose, Helper.ConvertToSqlString(value), ClinicConstant.HistoryTable_Diagnose, Helper.ConvertToSqlString(valuePrivious));
            DatabaseFactory.Instance.ExecuteNonQuery(strCommand, null);
        }
        private bool isValid(Control control, string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                ErrorProviderHelper.GetInstance.SetError(control, "Bạn chưa nhập giá trị");
                return false;
            }
            ErrorProviderHelper.GetInstance.SetError(control, "");
            return true;
        }
        #endregion

        private void AddRowInDataGridView(string value,string id,int indexRow = -1,bool readonlyCol = false)
        {
            DataGridViewRow row;
            if (indexRow >= 0 && indexRow < dataGridView1.Rows.Count)
            {
                row = new DataGridViewRow();
                dataGridView1.Rows.Insert(indexRow, row);
                row = dataGridView1.Rows[indexRow];
            }
            else
            {
                int index = dataGridView1.Rows.Add();
                row = dataGridView1.Rows[index];
                
            }
            row.Cells[this.ID.Name].Value = id;
            row.Cells[this.ColumnName.Name].Value = value;
            row.Cells[this.ColumnUpdate.Name].Value = "Cập nhật";

            if (readonlyCol)
            {
                row.Cells[this.ColumnUpdate.Name].ReadOnly = readonlyCol;
                row.Cells[this.ColumnName.Name].ReadOnly = readonlyCol;
            }
            
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                List<DataGridViewRow> rows = (from DataGridViewRow r in dataGridView1.Rows where Convert.ToBoolean(r.Cells[0].Value) == true select r).ToList();
                for (int i = 0; i < rows.Count(); i++)
                {
                    if (ExistIdDiagnoses(rows[i].Cells[this.ID.Name].Value))
                    {
                        string strcmd = string.Format("delete from {0} where {1} = {2}", DatabaseContants.tables.diagnoses, DatabaseContants.Diagnoses.Id, rows[i].Cells[this.ID.Name].Value.ToString());
                        db.ExecuteNonQuery(strcmd, null);
                    }
                    else
                    {
                        string name = rows[i].Cells[this.ColumnName.Index].Value.ToString() + "[H]";
                        UpdateRow(name, rows[i].Cells[this.ColumnName.Index].Value.ToString());                   
                    }
                    dataGridView1.Rows.RemoveAt(rows[i].Index);
                    
                }
                MessageBox.Show("Xóa thành công");
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (!isValid(this.textBoxX1, this.textBoxX1.Text))
            {
                MessageBox.Show("Bạn chưa nhập giá trị.", "Thông báo");
                return;
            }

            if (Helper.ExistNameInTableDiagnoses(db, this.textBoxX1.Text))
            {
                MessageBox.Show("Chẩn đoán này đã tồn tại rồi. Xin thử chẩn đoán khác.", "Thông báo");
                return;
            }

            List<string> columns = new List<string>(){ DatabaseContants.Diagnoses.diagnoses,DatabaseContants.Diagnoses.Hiden };
            List<string> values = new List<string>(){ this.textBoxX1.Text,"0" };
            db.InsertRowToTable(DatabaseContants.tables.diagnoses, columns, values);
            string idAdd = Helper.GetValueColumnOfTable(db, DatabaseContants.tables.diagnoses, DatabaseContants.Diagnoses.Id, DatabaseContants.Diagnoses.diagnoses, this.textBoxX1.Text);
            AddRowInDataGridView(this.textBoxX1.Text, idAdd, 0);
            MessageBox.Show("Thêm thành công", "Thông báo");
        }

        private void UpdateTableDiagnoses(string id, string value)
        {
            string strCommand = string.Format("Update {0} Set {1} = {2} where {3} = {4}", DatabaseContants.tables.diagnoses, DatabaseContants.Diagnoses.diagnoses, Helper.ConvertToSqlString(value), DatabaseContants.Diagnoses.Id, id);
            DatabaseFactory.Instance.ExecuteNonQuery(strCommand, null);
        }

        public static bool AddNewDiagnoses(IDatabase db, string value)
        {
            if (Helper.ExistNameInTableDiagnoses(db, value))
            {
                return false;
            }

            List<string> columns = new List<string>() { DatabaseContants.Diagnoses.diagnoses, DatabaseContants.Diagnoses.Hiden};
            List<string> values = new List<string>() { value,"0" };
            db.InsertRowToTable(DatabaseContants.tables.diagnoses, columns, values);
            return true;
        }
        private bool ExistIdDiagnoses(object value)
        {
            if (value != null)
            {
                try
                {
                    int temp = int.Parse(value.ToString());
                    if (temp > -1)
                    {
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return false;
        }

        private void textBoxX1_Validating(object sender, CancelEventArgs e)
        {
            isValid(this.textBoxX1, this.textBoxX1.Text);
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            isValid(this.textBoxX1, this.textBoxX1.Text);
        }
    }
}
