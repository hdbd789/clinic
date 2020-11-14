using Clinic.Database;
using System;
using System.Data.Common;

namespace Clinic.Helpers
{
    public class HelperforSeemore
    {

        #region Day
        public static int GetCountRevenueLastDay(IDatabase db, DateTime day, string nameMedicine)
        {
            string strCommand = "select Sum(Count) from medicine where Name = " + Helper.ConvertToSqlString(nameMedicine) + " and InputDay <= " + Helper.ConvertToSqlString(day.ToString("yyyy-MM-dd"));
            int count = (int)db.ExecuteScalar(strCommand);
            return count;
        }
        public static int GetMoneyOutRevenueFirstDay(IDatabase db, DateTime day, string nameMedicine)
        {
            string strCommand = "select Sum(Count) from medicine where Name = " + Helper.ConvertToSqlString(nameMedicine) + " and InputDay < " + Helper.ConvertToSqlString(day.ToString("yyyy-MM-dd"));
            int count = (int)db.ExecuteScalar(strCommand);
            return count;
        }

        
        public static Tuple<int,int> GetCountAndMoneyMedicineInputInDay(IDatabase db, DateTime day, string ID)
        {
            string strCommand = "select * from lichsunhapthuoc where idMedicine = " + Helper.ConvertToSqlString(ID) + " and InputDay = " + Helper.ConvertToSqlString(day.ToString("yyyy-MM-dd"));
            return GetCountAndMoneyMedicineInput(db, strCommand);
        }

        public static Tuple<int, int> GetCountAndMoneyMedicineExportInDay(IDatabase db, DateTime day, string Name)
        {
            string strCommand = "select Medicines from history where Day = " + Helper.ConvertToSqlString(day.ToString("yyyy-MM-dd"));
            return GetCountAndMoneyMedicineExport(db, strCommand, Name);
        }

        public static int GetCountFirstDay(IDatabase db, DateTime day,string id,string name)
        {
            string commandInput = string.Format("{0} < {1}", DatabaseContants.lichsunhapthuoc.InputDay, Helper.ConvertToSqlString(day.ToString("yyyy-MM-dd")));
            string commandHis = string.Format("{0} < {1}", DatabaseContants.history.Day, Helper.ConvertToSqlString(day.ToString("yyyy-MM-dd")));
            return GetCountFirst(db, id, name, commandInput, commandHis);
        }

        private static int GetCountStoreFromMedicineByName(string name, string medicine)
        {
            if (Helper.CheckDataMedicineOld(medicine))
            {
                return 0;
            }
            else
            {
                string[] newprocess = medicine.Split('|');
                for (int i = 0; i < newprocess.Length; i++)
                {
                    string[] parts = newprocess[i].Split(',');
                    if (parts.Length < 4)
                        return 0;
                    if (parts[0] == name)
                        return Int32.Parse(parts[3]);
                }
                return 0;
            }
        }

        private static Tuple<int, int> ProcessStringGetCountAndMoney(string text,string name)
        {
            
            if (Helper.CheckDataMedicineOld(text))
            {
                string[] medicines = text.Split(',');
                if (!Helper.CheckDataOld(medicines) || medicines.Length < 2)
                    return new Tuple<int, int>(0, 0);
                for (int i = 0; i < medicines.Length; i = i + 2)
                {
                    string tempName = medicines[i];
                    if (tempName == name)
                    {
                        int count = int.Parse(medicines[i + 1]);
                        int moneyMedicin = Helper.GetCostOutMedicineByName(tempName, DatabaseFactory.Instance2);
                        int money = moneyMedicin * count;
                        Tuple<int, int> result = new Tuple<int, int>(count, money);
                        return result;
                    }
                }
            }
            else
            {
                string[] newProcess = text.Split('|');
                for (int i = 0; i < newProcess.Length; i++)
                {
                    string[] parts = newProcess[i].Split(',');
                    string tempName = parts[0];
                    if (tempName == name)
                    {
                        int count = int.Parse(parts[1]);
                        int money = int.Parse(parts[2]) * count;
                        Tuple<int, int> result = new Tuple<int, int>(count, money);
                        return result;
                    }
                }
            }
            
            return new Tuple<int, int>(0, 0);
        }

        public static Tuple<int, int> ProcessStringGetCountAndMoneyAll(string text)
        {
            int count = 0;
            int money = 0;
            if (Helper.CheckDataMedicineOld(text))
            {
                string[] medicines = text.Split(',');
                if (!Helper.CheckDataOld(medicines) || medicines.Length < 2)
                    return new Tuple<int, int>(0, 0);
                for (int i = 0; i < medicines.Length; i = i + 2)
                {
                    string tempName = medicines[i];
                    int countItem = Helper.ConvertString2Int(medicines[i + 1]);

                    int moneyMedicin = Helper.GetCostOutMedicineByName(tempName,DatabaseFactory.Instance2);
                    int moneyItem = moneyMedicin * countItem;

                    count += countItem;
                    money += moneyItem;
                }
            }
            else
            {
                string[] newProcess = text.Split('|');
                for (int i = 0; i < newProcess.Length; i++)
                {
                    string[] parts = newProcess[i].Split(',');
                    string tempName = parts[0];

                    int countItem = Helper.ConvertString2Int(parts[1]);
                    int moneyItem = Helper.ConvertString2Int(parts[2]) * count;

                    count += countItem;
                    money += moneyItem;
                }
            }

            Tuple<int, int> result = new Tuple<int, int>(count, money);
            return result;
        }
        #endregion

        #region Month
        public static Tuple<int, int> GetCountAndMoneyMedicineInputInMonth(IDatabase db, DateTime date, string ID)
        {
            string strCommand = "select * from lichsunhapthuoc where idMedicine = " + Helper.ConvertToSqlString(ID) + " and MONTH(InputDay) = " + Helper.ConvertToSqlString(date.Month.ToString()) + " and YEAR(InputDay) = " + Helper.ConvertToSqlString(date.Year.ToString());
            return GetCountAndMoneyMedicineInput(db,strCommand);
        }
       
        public static Tuple<int, int> GetCountAndMoneyMedicineExportInMonth(IDatabase db, DateTime date, string Name)
        {
            string strCommand = "select * from history where MONTH(Day) = " + Helper.ConvertToSqlString(date.Month.ToString()) + "and YEAR(Day) = " + Helper.ConvertToSqlString(date.Year.ToString());
            return GetCountAndMoneyMedicineExport(db, strCommand, Name);
        }

        public static int GetCountFirstMonth(IDatabase db, DateTime day, string id, string name)
        {
            string commandInput = string.Format("Month({0}) < {1} and Year({0}) <= {2} ", DatabaseContants.lichsunhapthuoc.InputDay, day.Month.ToString(),day.Year.ToString());
            string commandHis = string.Format("Month({0}) < {1} and Year({0}) <= {2} ", DatabaseContants.history.Day, day.Month.ToString(), day.Year.ToString());
            return GetCountFirst(db, id, name, commandInput, commandHis);
        }
        #endregion

        #region Year
        public static Tuple<int, int> GetCountAndMoneyMedicineInputInYear(IDatabase db, int year, string ID)
        {
            string strCommand = "select * from lichsunhapthuoc where idMedicine = " + Helper.ConvertToSqlString(ID) + " and YEAR(InputDay) >= " + Helper.ConvertToSqlString(year.ToString());
            return GetCountAndMoneyMedicineInput(db, strCommand);
        }

        public static Tuple<int, int> GetCountAndMoneyMedicineExportInYear(IDatabase db, int year, string Name)
        {
            string strCommand = "select Medicines from history where YEAR(Day) = " + Helper.ConvertToSqlString(year.ToString());
            return GetCountAndMoneyMedicineExport(db, strCommand, Name);
        }

        public static int GetCountFirstYear(IDatabase db, int year, string id, string name)
        {
            string commandInput = string.Format("Year({0}) < {0} ", DatabaseContants.lichsunhapthuoc.InputDay, year);
            string commandHis = string.Format("Year({0}) < {0} ", DatabaseContants.history.Day, year);
            return GetCountFirst(db, id, name, commandInput, commandHis);
        }
        #endregion

        #region Common
        public static Tuple<int, int> GetCountAndMoneyMedicineInput(IDatabase db, string query)
        {
            Tuple<int, int> result;
            DbDataReader reader = db.ExecuteReader(query, null) as DbDataReader;

            int count = 0;
            int sumMoney = 0;
            while (reader.Read())
            {
                int tempCount = int.Parse(reader["Count"].ToString());
                int costIn = int.Parse(reader["CostIn"].ToString());
                count += tempCount;
                sumMoney += tempCount * costIn;
            }
            reader.Close();
            result = new Tuple<int, int>(count, sumMoney);
            return result;
        }

        public static Tuple<int, int> GetCountAndMoneyMedicineExport(IDatabase db, string query, string Name)
        {
            Tuple<int, int> result;
            DbDataReader reader = db.ExecuteReader(query, null) as DbDataReader;

            int count = 0;
            int sumMoney = 0;
            while (reader.Read())
            {
                string medicines = reader["Medicines"].ToString();
                if (medicines.Contains(Name))
                {
                    Tuple<int, int> itemResult = ProcessStringGetCountAndMoney(medicines, Name);
                    count += itemResult.Item1;
                    sumMoney += itemResult.Item2;
                }
            }
            reader.Close();
            result = new Tuple<int, int>(count, sumMoney);
            return result;
        }

        public static int GetCountFirst(IDatabase db, string id, string name, string commandInput, string commandHis)
        {
            string strcommand = string.Format("select {0},{4} from {1} where idMedicine = {2} and {3} order by {4} desc, Idhistory desc limit 1", DatabaseContants.lichsunhapthuoc.CountStore, DatabaseContants.tables.lichsunhapthuoc, Helper.ConvertToSqlString(id), commandInput, DatabaseContants.lichsunhapthuoc.InputDay);
            int countInput = 0;
            string dayInputMedicine = string.Empty;
            using (DbDataReader reader = db.ExecuteReader(strcommand, null) as DbDataReader)
            {
                reader.Read();
                if (reader.HasRows)
                {
                    countInput = Int32.Parse(reader[0].ToString());
                    dayInputMedicine = reader[1].ToString();
                }
            }
            //
            string medicine = string.Empty;
            string dayHistory = string.Empty;
            int countHis = 0;
            strcommand = string.Format("SELECT Medicines,Day FROM {0} where Medicines like '%{1}%' and {2} order by Day desc, IdHistory desc", DatabaseContants.tables.history, name, commandHis);
            using (DbDataReader reader = db.ExecuteReader(strcommand, null) as DbDataReader)
            {
                reader.Read();
                if (reader.HasRows)
                {
                    medicine = reader[0].ToString();
                    dayHistory = reader[1].ToString();
                    countHis = GetCountStoreFromMedicineByName(name, medicine);
                }
            }
            if (countHis == 0)
                return countInput;
            if (countInput == 0)
                return countHis;
            if (dayInputMedicine.CompareTo(dayHistory) > 0)
                return countInput;
            else
            {
                return countHis;
            }
        }
        #endregion

        #region doanh thu

        public static Tuple<int, int> GetAllCountAndMoneyMedicineInputInDay(IDatabase db, DateTime day)
        {
            Tuple<int, int> result;
            string strCommand = "select * from lichsunhapthuoc where InputDay = " + Helper.ConvertToSqlString(day.ToString("yyyy-MM-dd"));
            using (DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader)
            {
                int count = 0;
                int sumMoney = 0;
                while (reader.Read())
                {
                    int tempCount = int.Parse(reader["Count"].ToString());
                    int costIn = int.Parse(reader["CostIn"].ToString());
                    count += tempCount;
                    sumMoney += tempCount * costIn;
                }
                result = new Tuple<int, int>(count, sumMoney);
            }
            return result;
        }

        public static Tuple<int, int> GetAllCountAndMoneyMedicineInputInMonth(IDatabase db, DateTime month)
        {
            Tuple<int, int> result;
            string strCommand = "select * from lichsunhapthuoc where MONTH(InputDay) = " + Helper.ConvertToSqlString(month.Month.ToString()) + "and YEAR(InputDay) = " + Helper.ConvertToSqlString(month.Year.ToString());
            DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader;

            int count = 0;
            int sumMoney = 0;
            while (reader.Read())
            {
                int tempCount = int.Parse(reader["Count"].ToString());
                int costIn = int.Parse(reader["CostIn"].ToString());
                count += tempCount;
                sumMoney += tempCount * costIn;
            }
            reader.Close();
            result = new Tuple<int, int>(count, sumMoney);
            return result;
        }

        public static Tuple<int, int> GetAllCountAndMoneyMedicineInputInYear(IDatabase db, int year)
        {
            Tuple<int, int> result;
            string strCommand = string.Format("select * from {0} where YEAR(InputDay) = {1}", DatabaseContants.tables.lichsunhapthuoc, Helper.ConvertToSqlString(year.ToString()));
            DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader;

            int count = 0;
            int sumMoney = 0;
            while (reader.Read())
            {
                int tempCount = int.Parse(reader["Count"].ToString());
                int costIn = int.Parse(reader["CostIn"].ToString());
                count += tempCount;
                sumMoney += tempCount * costIn;
            }
            reader.Close();
            result = new Tuple<int, int>(count, sumMoney);
            return result;
        }
        #endregion
    }
}
