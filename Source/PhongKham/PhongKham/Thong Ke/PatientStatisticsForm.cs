using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using Clinic.Business;
using Clinic.Data.Database;
using Clinic.Data.Models;
using Clinic.Helpers;
using Clinic.Models;
using log4net;

namespace Clinic.Thong_Ke
{
    public partial class PatientStatisticsForm : Form
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private static Dictionary<string, Tuple<string, int>> DataGridviewPatientStructure = new Dictionary<string, Tuple<string, int>>()
        {
            { "STT", new Tuple<string, int>("STT",50) },
            { "DateExamination", new Tuple<string, int>("Ngày khám",100) },
            { "Name", new Tuple<string, int>("Tên bệnh nhân",200) },
            { "Dateofbirth", new Tuple<string, int>("Ngày sinh",100) },
            { "Phone", new Tuple<string, int>("Số điện thoại",120) },
            { "Address", new Tuple<string, int>("Địa chỉ",250) },
            { "Weight", new Tuple<string, int>("Cân nặng",80) },
            { "Temperature", new Tuple<string, int>("Nhiệt độ",100) },
            { "Huyetap", new Tuple<string, int>("Huyết áp",100) },
            { "Diagnose", new Tuple<string, int>("Chẩn đoán",0) },
        };
        public PatientStatisticsForm()
        {
            InitializeComponent();
            SetupColumnLayout();
            lblInfo.Text = "Màn hình xem thông tin bệnh nhân và xuất dữ liệu";
            
            datagridviewPaging1.AmountEachPage = 100;
            UpdateStatusButton();
            cbbExportType.DisplayMember = "Text";
            cbbExportType.ValueMember = "Value";
            cbbExportType.Items.Add(new { Text = "Excel file", Value = ExportType.ExcelType });
            cbbExportType.Items.Add(new { Text = "CSV file", Value = ExportType.CSVType });
            cbbExportType.SelectedIndex = 0;
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
                row["DateExamination"] = infoPatient.NgayKham.ToString(ClinicConstant.DateTimeFormat);
                row["Name"] = infoPatient.Name;
                row["Dateofbirth"] = infoPatient.Birthday.ToString(ClinicConstant.DateTimeFormat);
                row["Phone"] = infoPatient.Phone;
                row["Address"] = infoPatient.Address;
                row["Weight"] = infoPatient.Weight;
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
            if(datagridviewPaging1.RowCount == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if(cbbExportType.SelectedItem == null)
            {
                MessageBox.Show("Bạn chưa chọn kiểu xuất data.", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            IExportFile exportFile = new CSVExportFile();
            ExportType exportType = (ExportType)(cbbExportType.SelectedItem as dynamic).Value;
            switch (exportType)
            {
                case ExportType.CSVType:
                    {
                        exportFile = new CSVExportFile();
                        break;
                    }
                case ExportType.ExcelType:
                    {
                        exportFile = new ExcelExportFile();
                        break;
                    }
            }

            exportFile.ExportAction(datagridviewPaging1.Tag as List<InfoPatient>);
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

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            if(DateTime.Compare(dtpFromDate.Value, dtpToDate.Value)> 0)
            {
                MessageBox.Show("Xin lưu ý. Ngày bắt đầu đang lớn hơn ngày kết thúc.");
            }
        }

        private void dtpFromDate_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Compare(dtpToDate.Value, dtpFromDate.Value) < 0)
            {
                MessageBox.Show("Xin lưu ý. Ngày kết thúc đang nhỏ hơn ngày bắt đầu.");
            }
        }
    }
}