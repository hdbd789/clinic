using System;
using System.Windows.Forms;
using Clinic.Data.Database;
using Clinic.Helpers;

namespace Clinic.Thong_Ke
{
    public partial class FormSeemoreMedicine : Form
    {
        private readonly IDatabase db = DatabaseFactory.Instance;
        private string IDMedicine;
        private string NameMedicine;
        public FormSeemoreMedicine(string Id, string name)
        {
            InitializeComponent();
            this.IDMedicine = Id;
            this.NameMedicine = name;
        }

        public FormSeemoreMedicine()
        {
            InitializeComponent();
        }

        private void FormSeemoreMedicine_Load(object sender, EventArgs e)
        {
            lbl_name.Text = this.NameMedicine;
        }

        private void btn_day_Click(object sender, EventArgs e)
        {
            DateTime current = dateTimePicker1.Value;
            // Thuoc da nhap trong ngay
            Tuple<int, int> resultInputDay = HelperforSeemore.GetCountAndMoneyMedicineInputInDay(db, current, this.IDMedicine);
            int countInput = resultInputDay.Item1;
            tbx_nhapthuoc.Text = countInput.ToString();
            tbx_moneynhapthuoc.Text = resultInputDay.Item2.ToString();

            

            // Medicine export
            Tuple<int, int> resultExportInDay = HelperforSeemore.GetCountAndMoneyMedicineExportInDay(db, current, this.NameMedicine);
            int countExport = resultExportInDay.Item1;
            tbx_xuatthuoc.Text = countExport.ToString();
            tbx_moneyxuatthuoc.Text = resultExportInDay.Item2.ToString();

            if (current.Date == DateTime.Now.Date)
            {   
                // Thuoc ton kho
                int countInventory = db.GetCountFromMecidicByName(this.NameMedicine);
                tbx_cuoiki.Text = countInventory.ToString();

                //Ton khi truoc ki
                int countFirst = countInventory + countExport - countInput;
                tbx_dauki.Text = countFirst.ToString();
            }
            else
            {
                //Ton khi truoc ki
                int countFirst = HelperforSeemore.GetCountFirstDay(db, current, this.IDMedicine, this.NameMedicine);
                tbx_dauki.Text = countFirst.ToString();

                // Thuoc ton kho
                int countInventory = countFirst + countInput - countExport;
                tbx_cuoiki.Text = countInventory.ToString();
            }

        }

        private void btn_month_Click(object sender, EventArgs e)
        {
            DateTime month = dateTimePicker1.Value;
            // Thuoc da nhap trong tháng
            Tuple<int, int> resultInputDay = HelperforSeemore.GetCountAndMoneyMedicineInputInMonth(db, month, this.IDMedicine);
            int countInput = resultInputDay.Item1;
            tbx_nhapthuoc.Text = countInput.ToString();
            tbx_moneynhapthuoc.Text = resultInputDay.Item2.ToString();

            // Medicine export
            Tuple<int, int> resultExportInDay = HelperforSeemore.GetCountAndMoneyMedicineExportInMonth(db, month, this.NameMedicine);
            int countExport = resultExportInDay.Item1;
            tbx_xuatthuoc.Text = countExport.ToString();
            tbx_moneyxuatthuoc.Text = resultExportInDay.Item2.ToString();

            if (month.Month == DateTime.Now.Month && month.Year == DateTime.Now.Year)
            {
                /// Thuoc ton kho
                int countInventory = db.GetCountFromMecidicByName(this.NameMedicine);
                tbx_cuoiki.Text = countInventory.ToString();

                //Ton khi truoc ki
                int countFirst = countInventory + countExport - countInput;
                tbx_dauki.Text = countFirst.ToString();
            }
            else
            {
                //Ton khi truoc ki
                int countFirst = HelperforSeemore.GetCountFirstMonth(db, month, this.IDMedicine, this.NameMedicine);
                tbx_dauki.Text = countFirst.ToString();

                // Thuoc ton kho
                int countInventory = countFirst + countInput - countExport;
                tbx_cuoiki.Text = countInventory.ToString();
            }
        }

        private void btn_year_Click(object sender, EventArgs e)
        {
            int year = dateTimePicker1.Value.Year;
            // Thuoc da nhap trong năm
            Tuple<int, int> resultInputDay = HelperforSeemore.GetCountAndMoneyMedicineInputInYear(db, year, this.IDMedicine);
            int countInput = resultInputDay.Item1;
            tbx_nhapthuoc.Text = countInput.ToString();
            tbx_moneynhapthuoc.Text = resultInputDay.Item2.ToString();

            // Medicine export
            Tuple<int, int> resultExportInDay = HelperforSeemore.GetCountAndMoneyMedicineExportInYear(db, year, this.NameMedicine);
            int countExport = resultExportInDay.Item1;
            tbx_xuatthuoc.Text = countExport.ToString();
            tbx_moneyxuatthuoc.Text = resultExportInDay.Item2.ToString();           

            if (year == DateTime.Now.Year)
            {
                /// Thuoc ton kho
                int countInventory = db.GetCountFromMecidicByName(this.NameMedicine);
                tbx_cuoiki.Text = countInventory.ToString();

                //Ton khi truoc ki
                int countFirst = countInventory + countExport - countInput;
                tbx_dauki.Text = countFirst.ToString();
            }
            else
            {
                //Ton khi truoc ki
                int countFirst = HelperforSeemore.GetCountFirstYear(db, year, this.IDMedicine, this.NameMedicine);
                tbx_dauki.Text = countFirst.ToString();

                // Thuoc ton kho
                int countInventory = countFirst + countInput - countExport;
                tbx_cuoiki.Text = countInventory.ToString();
            }
        }
    }
}
