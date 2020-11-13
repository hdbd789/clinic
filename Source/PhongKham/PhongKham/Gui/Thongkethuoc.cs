using Clinic.Database;
using Clinic.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Clinic.Gui
{
    public partial class Thongkethuoc : Form
    {
        private IDatabase db = DatabaseFactory.Instance;
        public Thongkethuoc()
        {
            InitializeComponent();
        }

        private void btn_day_Click(object sender, EventArgs e)
        {
            DataDesign(GetCountAndMoneyInputMedcineDay(dateTimePicker1.Value), GetCountAndMoneySellMedcineDay(dateTimePicker1.Value));
        }

        private void DataDesign(Tuple<int, int> itemINput, Tuple<int, int> sellMedicine)
        {
            // count and money Input medicine
            lbl_countInput.Text = itemINput.Item1.ToString();
            lbl_moneyInput.Text = itemINput.Item2.ToString("C0");

            // count and money Buy medicine

            lbl_countSell.Text = sellMedicine.Item1.ToString();
            lbl_moneySell.Text = sellMedicine.Item2.ToString("C0");

            // sub

            lbl_subCount.Text = (sellMedicine.Item1 - itemINput.Item1).ToString();
            lbl_subMoney.Text = (sellMedicine.Item2 - itemINput.Item2).ToString("C0");
        }
        private Tuple<int, int> GetCountAndMoneyInputMedcineDay(DateTime date)
        {
            string strcmd = string.Format("select sum(Count),sum(Count * CostIn) from {0} where {1} = {2}",DatabaseContants.tables.lichsunhapthuoc,DatabaseContants.lichsunhapthuoc.InputDay,Helper.ConvertToSqlString(date.ToString("yyyy-MM-dd")));
            return GetCountAndMoneyInputMedcine(strcmd);
        }

        private Tuple<int, int> GetCountAndMoneyInputMedcineMonth(DateTime date)
        {
            string strcmd = string.Format("select sum(Count),sum(Count * CostIn) from {0} where Month({1}) = {2} and Year({1}) = {3}", DatabaseContants.tables.lichsunhapthuoc, DatabaseContants.lichsunhapthuoc.InputDay, date.Month.ToString(), date.Year.ToString());
            return GetCountAndMoneyInputMedcine(strcmd);
        }

        private Tuple<int, int> GetCountAndMoneyInputMedcineYear(DateTime date)
        {
            string strcmd = string.Format("select sum(Count),sum(Count * CostIn) from {0} where Year({1}) = {2}", DatabaseContants.tables.lichsunhapthuoc, DatabaseContants.lichsunhapthuoc.InputDay, date.Year.ToString());
            return GetCountAndMoneyInputMedcine(strcmd);
        }

        private Tuple<int, int> GetCountAndMoneyInputMedcine(string strcmd)
        {
            using (DbDataReader reader = db.ExecuteReader(strcmd,null) as DbDataReader)
            {
                reader.Read();
                if (reader.HasRows)
                {
                    int count = Helper.ConvertString2Int(reader[0]);
                    int money = Helper.ConvertString2Int(reader[1]);
                    return new Tuple<int, int>(count, money);
                }
            }
            return new Tuple<int, int>(0, 0);
        }

        private Tuple<int, int> GetCountAndMoneySellMedcineDay(DateTime date)
        {
            string strCommand = string.Format("select Medicines from {0} where Day = {1} and Medicines != N{2}", DatabaseContants.tables.history, Helper.ConvertToSqlString(date.ToString("yyyy-MM-dd")), Helper.ConvertToSqlString("Dd nhập bệnh nhân mới,!"));
            return GetCountAndMoneySellMedcine(strCommand);
        }

        private Tuple<int, int> GetCountAndMoneySellMedcineMonth(DateTime date)
        {
            string strCommand = string.Format("select Medicines from {0} where Month(Day) = {1} and Year(Day) = {2} and Medicines != N{3}", DatabaseContants.tables.history, date.Month.ToString(),date.Year.ToString(), Helper.ConvertToSqlString("Dd nhập bệnh nhân mới,!"));
            return GetCountAndMoneySellMedcine(strCommand);
        }

        private Tuple<int, int> GetCountAndMoneySellMedcineYear(DateTime date)
        {
            string strCommand = string.Format("select Medicines from {0} where Year(Day) = {1} and Medicines != N{2}", DatabaseContants.tables.history,date.Year.ToString(), Helper.ConvertToSqlString("Dd nhập bệnh nhân mới,!"));
            return GetCountAndMoneySellMedcine(strCommand);
        }

        private Tuple<int, int> GetCountAndMoneySellMedcine(string strcmd)
        {
            int count = 0;
            int money = 0;
            using (DbDataReader reader = db.ExecuteReader(strcmd, null) as DbDataReader)
            {
                while (reader.Read())
                {
                    string medicine = reader[0].ToString();
                    if (medicine.Length != 0)
                    {
                        Tuple<int, int> itemResult = HelperforSeemore.ProcessStringGetCountAndMoneyAll(medicine);
                        count += itemResult.Item1;
                        money += itemResult.Item2;
                    }
                }
            }
            return new Tuple<int, int>(count, money);
        }

        private void btn_month_Click(object sender, EventArgs e)
        {
            DataDesign(GetCountAndMoneyInputMedcineMonth(dateTimePicker1.Value), GetCountAndMoneySellMedcineMonth(dateTimePicker1.Value));
        }

        private void btn_year_Click(object sender, EventArgs e)
        {
            DataDesign(GetCountAndMoneyInputMedcineYear(dateTimePicker1.Value), GetCountAndMoneySellMedcineYear(dateTimePicker1.Value));
        }
    }
}
