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
using Clinic.Models;
using PhongKham;
using Clinic.Models.ItemMedicine;
using System.Threading;
using Clinic.Extensions;
using System.Threading.Tasks;

namespace Clinic
{
    public partial class DoanhThuForm : Form
    {

        private List<ItemDoanhThu> listItem;
        private string tongDoanhThu="0";
        private int tongLuotKham=0;
        List<IMedicine> currentMedicines;
        List<IMedicine> currentServices;
        List<string> AllLoaiKham;
        private bool needOptimize =false;

        private Thread threadLoad;
        public DoanhThuForm()
        {
            InitializeComponent();

            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnServices.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewMain.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            currentMedicines = Helper.GetAllMedicineFromDb();
            currentServices = Helper.GetAllServiceFromDb();
            AllLoaiKham = Helper.GetAllLoaiKham(DatabaseFactory.Instance);

            InitForm(needOptimize);
            this.dataGridViewLoaiKham.AllowUserToAddRows = false;
            this.dataGridViewMain.AllowUserToAddRows = false;
            this.dataGridViewAdminOfService.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToAddRows = false;
        }

        private void InitForm(bool needOptimize)
        {
            if (needOptimize)
            {
                this.dataGridViewMain.Columns[this.ColumnIdPatient.Index].Visible=false;
                this.dataGridViewMain.Columns[this.NameDoctor.Index].Visible=false;
            }
            this.dataGridViewMain.Columns[this.ColumnLoaiKham.Index].Visible=false;
        }

        private delegate void FillToGridDelegate(List<ItemDoanhThu> a);
        public void FillToGrid(List<ItemDoanhThu> listItem)
        {
            List<DoanhThuBacSi> listBacSi = new List<DoanhThuBacSi>();
            Dictionary<string, int> listService = new Dictionary<string,int>();
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new FillToGridDelegate(FillToGrid), listItem);
                return;
            }
            List<string> listID = new List<string>();

            for (int i = 0; i < listItem.Count; i++)
            {
                int index = dataGridViewMain.Rows.Add();
                DataGridViewRow row = dataGridViewMain.Rows[index];
                row.Cells["STT"].Value = i + 1;
                row.Cells[this.date.Name].Value = listItem[i].Date;

                row.Cells[this.ColumnDiagnose.Name].Value = listItem[i].Diagnose;

                row.Cells[Money.Name].Value = listItem[i].Money;
                string nameDoctor = listItem[i].NameOfDoctor;
                if (!needOptimize)
                {
                    row.Cells["ColumnIdPatient"].Value = listItem[i].IdPatient;
                    row.Cells[NameDoctor.Name].Value = nameDoctor;
                }
                if (!listID.Contains(listItem[i].IdPatient))
                {
                    listID.Add(listItem[i].IdPatient);

                }

                row.Cells["ColumnNamePatient"].Value = listItem[i].NamePatient;

                row.Cells["ColumnServices"].Value = Helper.BuildStringServicesAndAdmin(listItem[i].Services, currentServices, ref listService);

                row.Cells["ColumnLoaiKham"].Value = listItem[i].LoaiKham;
                
                DoanhThuBacSi bsTemp = listBacSi.Where(x => x.NameBacSi == nameDoctor).FirstOrDefault();
                if (bsTemp == null)
                {
                    bsTemp = new DoanhThuBacSi();
                    bsTemp.NameBacSi = nameDoctor;
                    bsTemp.SoLuotKham = 1;
                    bsTemp.SoTien = listItem[i].Money;
                    if (listItem[i].Money == 0)
                    {
                        bsTemp.SoLuotKham0Dong = 1;
                    }
                    listBacSi.Add(bsTemp);
                }
                else
                {
                    bsTemp.SoLuotKham++;
                    bsTemp.SoTien += listItem[i].Money;
                    if (listItem[i].Money == 0)
                    {
                        bsTemp.SoLuotKham0Dong++;
                    }
                }     

            }

            dataGridView3.Rows.Clear();
            
            foreach (string keyService in listService.Keys)
            {
                    int index = dataGridView3.Rows.Add();
                    DataGridViewRow row = dataGridView3.Rows[index];
                    row.Cells["ColumnServiceName"].Value = keyService;
                    try
                    {
                        row.Cells["ColumnServiceAdmin"].Value = currentServices.Where(x => x.Name == keyService).FirstOrDefault().Admin;
    
                    row.Cells["ColumnServiceCount"].Value = listService[keyService].ToString();
                    row.Cells["ColumnServiceTotal"].Value = (listService[keyService] * currentServices.Where(x => x.Name == keyService).FirstOrDefault().CostOut).ToString();
                    }
                    catch { }
                
            }

            dataGridView2.Rows.Clear();
            //each doctor
            for (int i = 0; i < listBacSi.Count; i++)
            {
                int index = dataGridView2.Rows.Add();
                DataGridViewRow row = dataGridView2.Rows[index];
                row.Cells["G2NameDoctor"].Value = listBacSi[i].NameBacSi;
                row.Cells["G2SoLuotKham"].Value = listBacSi[i].SoLuotKham.ToString() + "/" + listBacSi[i].SoLuotKham0Dong.ToString();
                row.Cells["G2TongCong"].Value = listBacSi[i].SoTien.ToString("C0");
            }


            dataGridViewLoaiKham.Rows.Clear();
            //each LoaiKham
            for (int i = 0; i < AllLoaiKham.Count; i++)
            {
                int index = dataGridViewLoaiKham.Rows.Add();
                DataGridViewRow row = dataGridViewLoaiKham.Rows[index];
                row.Cells[0].Value = AllLoaiKham[i];
                row.Cells[1].Value = listItem.Where(x => x.LoaiKham == AllLoaiKham[i]).Count();

            }


            Dictionary<string, int> Admins = new Dictionary<string, int>();
            try
            {
                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    string nameAdmin = dataGridView3.Rows[i].Cells["ColumnServiceAdmin"].Value!=null ?dataGridView3.Rows[i].Cells["ColumnServiceAdmin"].Value.ToString():"";
                    int tien =0;
                    tien = int.Parse(dataGridView3.Rows[i].Cells["ColumnServiceTotal"].Value!=null? dataGridView3.Rows[i].Cells["ColumnServiceTotal"].Value.ToString():"0");
                    if (!String.IsNullOrEmpty(nameAdmin))
                    {
                        if (Admins.ContainsKey(nameAdmin))
                        {
                            
           
                            Admins[nameAdmin] += tien;
                        }
                        else
                        {
                            Admins.Add(nameAdmin, tien);
                        }

                    }
                }
            }
            catch 
            {

            }

            dataGridViewAdminOfService.Rows.Clear();

            try
            {
                foreach (string keyAdmin in Admins.Keys)
                {
                    int index = dataGridViewAdminOfService.Rows.Add();
                    DataGridViewRow row = dataGridViewAdminOfService.Rows[index];
                    row.Cells[0].Value = keyAdmin;
                    row.Cells[1].Value = Admins[keyAdmin];
                }
            }
            catch { }

            this.PatientNumber.Text = listID.Count.ToString();
            this.tongLuotKham = int.Parse(this.PatientNumber.Text);
            HelperControl.Instance.StopProgress();
        }


        void dataGridViewLoaiKham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks that are not on button cells.  
            if (e.RowIndex < 0 || e.ColumnIndex !=
                this.dataGridViewLoaiKham.Columns[this.ColumnLkName.Name].Index) return;

            //filter by LoaiKham
            List<DataGridViewRow> listRowWillDelete = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in dataGridViewMain.Rows)
            {
                string loaiKhamOnMainGrid = row.Cells[this.ColumnLoaiKham.Name].Value!=null?  row.Cells[this.ColumnLoaiKham.Name].Value.ToString() :"";
                if (loaiKhamOnMainGrid != this.dataGridViewLoaiKham.Rows[e.RowIndex].Cells[this.ColumnLkName.Name].Value.ToString())
                {
                    listRowWillDelete.Add(row);
                }
            }
            foreach (DataGridViewRow row in listRowWillDelete)
            {
                dataGridViewMain.Rows.Remove(row);
            }
        }

        private void button1_Click(object sender, EventArgs e) // ngay
        {
            dataGridViewMain.Rows.Clear();

            HelperControl.Instance.DoAsyncAction(() =>
            {
                DateTime day = dateTimePicker1.Value;
                listItem = Helpers.Helper.DoanhThuTheoNgay(DatabaseFactory.Instance, day);
                Tuple<int, int> resultBuyMedicine = HelperforSeemore.GetAllCountAndMoneyMedicineInputInDay(DatabaseFactory.Instance, day);
                int phimuathuoc = resultBuyMedicine.Item2;
                CalcuTotal(phimuathuoc, listItem, resultBuyMedicine.Item1);
                FillToGrid(listItem);
            });
        }

        private void button2_Click(object sender, EventArgs e) // thang
        {
            dataGridViewMain.Rows.Clear();

            HelperControl.Instance.DoAsyncAction(() =>
            {
                listItem = Helpers.Helper.DoanhThuTheoThang(DatabaseFactory.Instance, dateTimePicker1.Value);
                FillToGrid(listItem);
                Tuple<int, int> resultBuyMedicine = HelperforSeemore.GetAllCountAndMoneyMedicineInputInMonth(DatabaseFactory.Instance, dateTimePicker1.Value);
                int phimuathuoc = resultBuyMedicine.Item2;
                CalcuTotal(phimuathuoc, listItem, resultBuyMedicine.Item1);
            });
        }

        private void btn_year_Click(object sender, EventArgs e) // nam
        {
            dataGridViewMain.Rows.Clear();

            HelperControl.Instance.DoAsyncAction(() =>
            {
                listItem = Helpers.Helper.DoanhThuTheoNam(DatabaseFactory.Instance, dateTimePicker1.Value);
                FillToGrid(listItem);
                Tuple<int, int> resultBuyMedicine = HelperforSeemore.GetAllCountAndMoneyMedicineInputInYear(DatabaseFactory.Instance, dateTimePicker1.Value.Year);
                int phimuathuoc = resultBuyMedicine.Item2;
                CalcuTotal(phimuathuoc, listItem, resultBuyMedicine.Item1);
            });
        }
        
        private void CalcuTotal(int chiphimuathuoc,List<ItemDoanhThu>listItem,int numberBuyMedicine)
        {
            this.Invoke((Action)(()=>{
                tsl_numberbuyMedicine.Text = numberBuyMedicine.ToString();
                int total = 0;
                total = listItem.Sum(m => m.Money);
                labelTotal.Text = total.ToString("N0");
                this.tongDoanhThu = labelTotal.Text;

                tsl_laikinhdoanh.Text = (total - chiphimuathuoc).ToString("N0");
                tsl_moneybuyMedicine.Text = chiphimuathuoc.ToString("N0");
            }));
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string namePDF = "DoanhThu";
            Helper.CreateAPdfThongKeDoanhThu(this.dataGridViewMain, namePDF,tongLuotKham,tongDoanhThu);
            this.PDFShowDoanhThu.LoadFile("DoanhThu.pdf");
        }

        private void dataGridViewAdminOfService_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks that are not on button cells.  
            if (e.RowIndex < 0 || e.ColumnIndex !=
                this.dataGridViewAdminOfService.Columns[this.ColumnAdminInAdminOfService.Name].Index) return;

            //filter by LoaiKham
            List<DataGridViewRow> listRowWillDelete = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in dataGridViewMain.Rows)
            {
                string dichVuOnMainGrid = row.Cells[this.ColumnServices.Name].Value != null ? row.Cells[this.ColumnServices.Name].Value.ToString() : "";
                if (!dichVuOnMainGrid.Contains(this.dataGridViewAdminOfService.Rows[e.RowIndex].Cells[this.ColumnAdminInAdminOfService.Name].Value.ToString()))
                {
                    listRowWillDelete.Add(row);
                }
            }
            foreach (DataGridViewRow row in listRowWillDelete)
            {
                dataGridViewMain.Rows.Remove(row);
            }
        }

        
    }
}
