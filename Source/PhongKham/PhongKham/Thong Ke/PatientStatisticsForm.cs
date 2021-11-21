using Clinic.Database;
using Clinic.Helpers;
using Clinic.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic.Thong_Ke
{
    public partial class PatientStatisticsForm : Form
    {
        private static Dictionary<string, Tuple<string, int>> DataGridviewPatientStructure = new Dictionary<string, Tuple<string, int>>()
        {
            { "STT", new Tuple<string, int>("STT",50) },
            { "DateExamination", new Tuple<string, int>("Ngày khám",150) },
            { "Name", new Tuple<string, int>("Tên bệnh nhân",220) },
            { "Dateofbirth", new Tuple<string, int>("Ngày sinh",150) },
            { "Phone", new Tuple<string, int>("Số điện thoại",120) },
            { "Address", new Tuple<string, int>("Địa chỉ",250) },
            { "Weight", new Tuple<string, int>("Cân nặng",80) },
            { "Hight", new Tuple<string, int>("Chiều cao",80) },
            { "Temperature", new Tuple<string, int>("Nhiệt độ",100) },
            { "Huyetap", new Tuple<string, int>("Huyết áp",100) },
            { "Diagnose", new Tuple<string, int>("Chẩn đoán",0) },
        };
        public PatientStatisticsForm()
        {
            InitializeComponent();
            SetupColumnLayout();
            lblInfo.Text = "Màn hình xem thông tin bệnh nhân và xuất dữ liệu";
            cbbExportType.SelectedIndex = 0;
            datagridviewPaging1.AmountEachPage = 100;
            UpdateStatusButton();
        }

        private void cbbExportType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SetupColumnLayout()
        {
            List<DataGridViewTextBoxColumn> columns = new List<DataGridViewTextBoxColumn>();
            foreach (var data in DataGridviewPatientStructure)
            {
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn()
                {
                    HeaderText = data.Value.Item1,
                    Name = data.Key
                };
                if (data.Value.Item2 == 0)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                else
                {
                    column.Width = data.Value.Item2;
                }
                columns.Add(column);
            }
            datagridviewPaging1.AddColumns(columns.ToArray());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            HelperControl.Instance.DoAsyncAction(() =>
            {
                List<InfoPatient> listPatient = DatabaseFactory.Instance.GetAllPatientInfo(dtpFromDate.Value, dtpToDate.Value);
                FillToGrid(listPatient);
            });
        }

        private delegate void FillToGridDelegate(List<InfoPatient> a);
        public void FillToGrid(List<InfoPatient> listPatient)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new FillToGridDelegate(FillToGrid), listPatient);
                return;
            }
            // Save data into grid
            datagridviewPaging1.Tag = listPatient;
            List<DataRow> rows = new List<DataRow>();
            for (int i = 0; i < listPatient.Count; i++)
            {
                InfoPatient infoPatient = listPatient[i];
                DataRow row = datagridviewPaging1.NewRow();
                row["STT"] = i + 1;
                row["DateExamination"] = infoPatient.NgayKham;
                row["Name"] = infoPatient.Name;
                row["Dateofbirth"] = infoPatient.Birthday;
                row["Phone"] = infoPatient.Phone;
                row["Address"] = infoPatient.Address;
                row["Weight"] = infoPatient.Weight;
                row["Hight"] = infoPatient.Height;
                row["Temperature"] = infoPatient.Temperature;
                row["Huyetap"] = infoPatient.HuyenAp;
                row["Diagnose"] = infoPatient.Diagnose;

                rows.Add(row);
            }
            datagridviewPaging1.AddRowDatas(rows.ToArray());
            UpdateStatusButton();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            FileDialog fileDialog = new SaveFileDialog();
            fileDialog.AddExtension = true;
            fileDialog.Title = "Xuất file";
            fileDialog.DefaultExt = ".csv";
            fileDialog.FileName = "Bệnh nhân";
            fileDialog.Filter = "CSV file|*.csv";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                HelperControl.Instance.DoAsyncAction(() =>
                {

                });
            }
        }

        private void UpdateStatusButton()
        {
            if(datagridviewPaging1.RowCount > 0)
            {
                btnExport.Enabled = true;
            }
            else
            {
                btnExport.Enabled = false;
            }
        }
    }
}