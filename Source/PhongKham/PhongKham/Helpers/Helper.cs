

namespace Clinic.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.SqlClient;
    using System.Security.Cryptography;
    using System.IO;
    using System.Security.Permissions;
    using PhongKham;
    using MySql.Data.MySqlClient;
    using Clinic.Database;
    using System.Data;
    using System.Data.Common;
    using Clinic.Models;
    using System.Drawing;
    using PdfSharp.Pdf;
    using PdfSharp.Drawing;
    using PdfSharp.Drawing.Layout;
    using MigraDoc.DocumentObjectModel;
    using MigraDoc.Rendering;
    using MigraDoc.DocumentObjectModel.Tables;
    using Clinic.Models.ItemMedicine;

    /// <summary>
    /// Comment for the class
    /// </summary>
    public class Helper
    {
        #region Fields
        private static readonly byte[] _key = { 0xA1, 0xF1, 0xA6, 0xBB, 0xA2, 0x5A, 0x37, 0x6F, 0x81, 0x2E, 0x17, 0x41, 0x72, 0x2C, 0x43, 0x27 };
        private static readonly byte[] _initVector = { 0xE1, 0xF1, 0xA6, 0xBB, 0xA9, 0x5B, 0x31, 0x2F, 0x81, 0x2E, 0x17, 0x4C, 0xA2, 0x81, 0x53, 0x61 };
        public static List<string> ColumnsHistory = new List<string>() { "Id", "Symptom", "Diagnose", "Day", "Medicines", "temperature", "huyetap", ClinicConstant.HistoryTable_Reason };
        public static List<string> ColumnsDoanhThu = new List<string>() { "Namedoctor", "Money", "time", "Idpatient", "Namepatient", ClinicConstant.DoanhThuTable_Services, ClinicConstant.DoanhThuTable_LoaiKham, ClinicConstant.HistoryTable_IdHistory };
        public static string IDPatient;

        private static readonly DateTime dateOld = new DateTime(2017, 05, 06);
        #endregion

        #region ctors

        #endregion

        #region Properties

        #endregion

        #region Methods
        public static void CopyFilesRecursively(DirectoryInfo source, DirectoryInfo target)
        {
            try
            {
                DirectoryInfo[] directories = source.GetDirectories();
                for (int i = 0; i < directories.Length; i++)
                {
                    DirectoryInfo directoryInfo = directories[i];
                    CopyFilesRecursively(directoryInfo, target.CreateSubdirectory(directoryInfo.Name));
                }
                FileInfo[] files = source.GetFiles();
                for (int i = 0; i < files.Length; i++)
                {
                    FileInfo fileInfo = files[i];
                    fileInfo.CopyTo(Path.Combine(target.FullName, fileInfo.Name), true);
                }
            }
            catch { }
        }

        public static string ChangePositionOfDayAndYear(string datetime)
        {
            string[] temp = datetime.Split('-');
            return temp[2] + '-' + temp[1] + '-' + temp[0];
        }


        public static string Decrypt(string Value)
        {
            SymmetricAlgorithm mCSP;
            ICryptoTransform ct = null;
            MemoryStream ms = null;
            CryptoStream cs = null;
            byte[] byt;
            byte[] _result;

            mCSP = new RijndaelManaged();

            try
            {
                mCSP.Key = _key;
                mCSP.IV = _initVector;
                ct = mCSP.CreateDecryptor(mCSP.Key, mCSP.IV);


                byt = Convert.FromBase64String(Value);

                ms = new MemoryStream();
                cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
                cs.Write(byt, 0, byt.Length);
                cs.FlushFinalBlock();

                cs.Close();
                _result = ms.ToArray();
            }
            catch
            {
                _result = null;
            }
            finally
            {
                if (ct != null)
                    ct.Dispose();
                if (ms != null)
                    ms.Dispose();
                if (cs != null)
                    cs.Dispose();
            }

            return ASCIIEncoding.UTF8.GetString(_result);
        }

        public static string Encrypt(string Password)
        {
            if (string.IsNullOrEmpty(Password))
                return string.Empty;

            byte[] Value = Encoding.UTF8.GetBytes(Password);
            SymmetricAlgorithm mCSP = new RijndaelManaged();
            mCSP.Key = _key;
            mCSP.IV = _initVector;
            using (ICryptoTransform ct = mCSP.CreateEncryptor(mCSP.Key, mCSP.IV))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, ct, CryptoStreamMode.Write))
                    {
                        cs.Write(Value, 0, Value.Length);
                        cs.FlushFinalBlock();
                        cs.Close();
                        return Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
        }


        public static bool checkId(string Id)
        {
            if (Id.Length < 6)
            {
                return false;
            }
            return true;
        }
        #endregion
        public static string ConvertToSqlString(string str)
        {
            return "'" + str + "'";
        }
        //public static void InsertRowToTable( string nameOfTable, List<string>nameOfColumns,List<string> values)
        //{

        //    for (int i = 0; i < values.Count; i++)
        //    {
        //        values[i] = ConvertToSqlString(values[i]);
        //    }

        //    string columns = "Insert Into " +nameOfTable+" (";
        //    foreach (string name in nameOfColumns)
        //    {
        //        columns += name + ",";
        //    }
        //    columns = columns.Remove(columns.Length - 1);
        //    columns += ")"; 
        //    string vals = " VALUES (";
        //    foreach (string value in values)
        //    {
        //        vals += value + ",";
        //    }
        //    vals= vals.Remove(vals.Length -1 );
        //    vals += ")";

        //    string strCommand = columns + vals;

        //    SqlCommand comm = new SqlCommand(strCommand, conn);
        //    comm.ExecuteNonQuery();

        //}

        //public static void InsertRowToTable(MySqlConnection conn, string nameOfTable, List<string> nameOfColumns, List<string> values)
        //{

        //    for (int i = 0; i < values.Count; i++)
        //    {
        //        values[i] = ConvertToSqlString(values[i]);
        //    }

        //    string columns = "Insert Into " + nameOfTable + " (";
        //    foreach (string name in nameOfColumns)
        //    {
        //        columns += name + ",";
        //    }
        //    columns = columns.Remove(columns.Length - 1);
        //    columns += ")";
        //    string vals = " VALUES (";
        //    foreach (string value in values)
        //    {
        //        vals += value + ",";
        //    }
        //    vals = vals.Remove(vals.Length - 1);
        //    vals += ")";

        //    string strCommand = columns + vals;

        //    MySqlCommand comm = new MySqlCommand(strCommand, conn);
        //    comm.ExecuteNonQuery();

        //}

        private static string BuildFirstPartUpdateQuery(string nameOfTable, List<string> nameOfColumns, List<string> values)
        {
            string strCommand = "Update " + nameOfTable + " Set ";
            for (int i = 0; i < nameOfColumns.Count; i++)
            {
                if (nameOfColumns[i] != "Id")
                {
                    strCommand += nameOfColumns[i] + "='" + values[i] + "',";
                }
            }
            strCommand = strCommand.Remove(strCommand.Length - 1);
            return strCommand;
        }

        public static void UpdateRowToTable(IDatabase db, string nameOfTable, List<string> nameOfColumns,
            List<string> values,string namecolumn, string id)
        {
            string strCommand = BuildFirstPartUpdateQuery(nameOfTable, nameOfColumns, values);

            strCommand += " Where " + namecolumn + " ='" + id + "';";

            //MySqlCommand comm = new MySqlCommand(strCommand, conn);
            db.ExecuteNonQuery(strCommand, null);
        }

        public static void UpdateRowToTable(IDatabase db, string nameOfTable, List<string> nameOfColumns,
            List<string> values,string nameColumn, string id, string visitDate)
        {
            string strCommand = BuildFirstPartUpdateQuery(nameOfTable, nameOfColumns, values);

            strCommand += " Where " + nameColumn + " ='" + id + "' AND Day='" + visitDate + "';";

            //MySqlCommand comm = new MySqlCommand(strCommand, conn);
            db.ExecuteNonQuery(strCommand, null);
        }

        public static void UpdateRowToTableCalendar(IDatabase db, string nameOfTable, List<string> nameOfColumns,
    List<string> values, string id, string Username)
        {
            string strCommand = BuildFirstPartUpdateQuery(nameOfTable, nameOfColumns, values);

            strCommand += " Where IdCalendar='" + id + "' AND Username='" + Username + "';";

            //MySqlCommand comm = new MySqlCommand(strCommand, conn);
            db.ExecuteNonQuery(strCommand, null);
        }


        public static void DeleteRowToTableCalendar(IDatabase db, string nameOfTable, string id, string Username)
        {
            string strCommand = "Delete From " + nameOfTable;

            strCommand += " Where IdCalendar='" + id + "' AND Username='" + Username + "';";

            //MySqlCommand comm = new MySqlCommand(strCommand, conn);
            db.ExecuteNonQuery(strCommand, null);
        }

        public static void DeleteRowFromTablelistpatienttoday(IDatabase db, string id, string name)
        {
            string strCommand = "Delete From listpatienttoday";

            strCommand += " Where Id='" + id + "' AND Name='" + name + "';";

            //MySqlCommand comm = new MySqlCommand(strCommand, conn);
            db.ExecuteNonQuery(strCommand, null);
        }

        public static bool checkAdminExists(SqlConnection conn, string nameOfTable)
        {

            string strCommand = "SELECT * FROM " + nameOfTable + " WHERE Authority = '1'";
            SqlCommand comm = new SqlCommand(strCommand, conn);
            SqlDataReader reader = comm.ExecuteReader();
            reader.Read();

            try
            {
                return reader.HasRows;
            }
            finally
            {
                reader.Close();

            }


        }

        public static List<string> GetAllRowsOfSpecialColumn(string table, string nameOfColumn)
        {
            List<string> result = new List<string>();
            string strCommand = "SELECT " + nameOfColumn + " FROM " + table;
            IDatabase database = DatabaseFactory.Instance;
            DbDataReader reader = database.ExecuteReader(strCommand, null) as DbDataReader;
            while (reader.Read())
            {
                string name = reader.GetString(0).Trim();
                result.Add(name);
            }
            reader.Close();
            return result;
        }

        public static List<ADate> GetAllDateOfUser(string Username, IDatabase db)
        {
            List<ADate> ListDate = new List<ADate>();
            string strCommand = "Select * from calendar where Username = " + Helper.ConvertToSqlString(Username);
            DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader;
            while (reader.Read())
            {
                ListDate.Add(BoxingDate(reader));
            }
            reader.Close();
            return ListDate;
        }

        private static ADate BoxingDate(DbDataReader reader)
        {
            ADate date = new ADate();
            date.Text = reader["Text"].ToString();
            date.color = (int)reader["Color"];
            date.StartTime = (DateTime)reader["StartTime"];
            date.EndTime = (DateTime)reader["EndTime"];
            date.Id = (int)reader["IdCalendar"];
            return date;
        }

        public static bool checkUserExists(string user, string pass, bool setAuthority)
        {
            string strCommand = "Select Authority From ClinicUser Where Username = " + Helper.ConvertToSqlString(user) + " And Password1 = " + Helper.ConvertToSqlString(Helper.Encrypt(pass));

            IDatabase database = DatabaseFactory.Instance;

            IDataReader reader = database.ExecuteReader(strCommand, null);
            reader.Read();
            if (((DbDataReader)reader).HasRows)
            {
                if (setAuthority) LoginForm.Authority = int.Parse(reader["Authority"].ToString());

                reader.Close();
                return true;
            }
            else
            {
                reader.Close();
                return false;
            }

        }

        public static bool checkUserExistsWithoutPassword(string user)
        {
            string strCommand = "Select * From ClinicUser Where Username = " + Helper.ConvertToSqlString(user);

            IDatabase database = DatabaseFactory.Instance;

            IDataReader reader = database.ExecuteReader(strCommand, null);
            reader.Read();
            if (((DbDataReader)reader).HasRows)
            {
                reader.Close();
                return true;
            }
            else
            {
                reader.Close();
                return false;
            }

        }

        public static bool checkAdminExists(string nameOfTable)
        {

            string strCommand = "SELECT * FROM " + nameOfTable + " WHERE Authority = 1";
            // MySqlCommand comm = new MySqlCommand(strCommand, conn);
            //MySqlDataReader reader = comm.ExecuteReader();
            IDatabase db = DatabaseFactory.Instance;
            bool hasrow = false;
            DbDataReader reader = (DbDataReader)db.ExecuteReader(strCommand, null);

            try
            {
                reader.Read();
                return reader.HasRows;
            }
            finally
            {
                reader.Close();
                db.CloseCurrentConnection();
            }


        }

        public static string hasOtherNameForThisId(IDatabase db, string Id, string name)
        {

            string strCommand = "SELECT name FROM Patient WHERE " + DatabaseContants.patient.Id + "=" + ConvertToSqlString(Id);
            //MySqlCommand comm = new MySqlCommand(strCommand, conn);
            DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader;
            reader.Read();

            try
            {
                if (reader.HasRows)
                {
                    if (reader.GetValue(0) as string != name)
                    {
                        return reader.GetValue(0) as string;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            finally
            {
                reader.Close();

            }


        }

        public static bool checkPatientExists(IDatabase db, string Id)
        {

            string strCommand = string.Format("SELECT {0} FROM Patient WHERE {0} = ",DatabaseContants.patient.Id) + ConvertToSqlString(Id);
            DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader;
            reader.Read();

            try
            {
                return reader.HasRows;
            }
            finally
            {
                reader.Close();

            }
        }

        public static bool checkVisitExists(IDatabase db, string Id, string visitDate,ref string idHistory)
        {

            string strCommand = "SELECT IdHistory FROM history WHERE Id = " + ConvertToSqlString(Id) + " AND Day=" + ConvertToSqlString(visitDate) + ";";
            //MySqlCommand comm = new MySqlCommand(strCommand, conn);
            DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader;
            reader.Read();
            try
            {
                bool result = reader.HasRows;
                if (result)
                {
                    idHistory = reader["IdHistory"].ToString();
                }
                return result;
            }
            finally
            {
                reader.Close();

            }
        }

        public static bool CheckPatientExistsDanhThu(IDatabase db, string Id)
        {

            //string strCommand = "SELECT Idpatient FROM doanhthu WHERE Idpatient = " + ConvertToSqlString(Id);
            string strCommand = string.Format("select {0} from {1} where {2} = {3}", DatabaseContants.danhthu.IdPatient, DatabaseContants.tables.danhthu, DatabaseContants.danhthu.IdPatient, ConvertToSqlString(Id));
            //MySqlCommand comm = new MySqlCommand(strCommand, conn);
            DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader;
            reader.Read();
            try
            {
                return reader.HasRows;
            }
            finally
            {
                reader.Close();

            }
        }

        #region Delete Db
        public static void DeleteRowInTableByID(IDatabase db,string nameTable,string nameID ,string ID)
        {
            string strCommand = "delete from " + nameTable + " where " + nameID + " = " + ConvertToSqlString(ID);
            db.ExecuteNonQuery(strCommand, null);
        }
        #endregion
        public static bool DoesUserHavePermission()
        {
            try
            {
                SqlClientPermission clientPermission = new SqlClientPermission(PermissionState.Unrestricted);
                clientPermission.Demand();
                return true;
            }
            catch
            {
                return false;
            }
        }


        //internal static int SearchMaxValueOfTable(SqlConnection sqlConnection, string p, string p_2 ,string order)
        //{
        //    string strCommand =" SELECT TOP 1 "+p_2+" FROM "+p+" ORDER BY "+p_2+" "+order;
        //    SqlCommand comm = new SqlCommand(strCommand, Program.conn);
        //    using (SqlDataReader reader = comm.ExecuteReader())
        //    {

        //        reader.Read();
        //        int intTemp;
        //        if (reader.HasRows)
        //        {
        //            string temp = reader.GetValue(0).ToString();
        //            intTemp = int.Parse(temp);
        //        }
        //        else
        //        {
        //            intTemp = 0;
        //        }
        //        int newId = intTemp + 1;
        //        return newId;
        //    }
        //}

        #region Get value in DB
        public static int GetCountFromMecidicByName(IDatabase db,string name)
        {
            string strCommand = "SELECT Sum(Count) FROM clinic.medicine where Name = " + ConvertToSqlString(name);
            int count = ConvertString2Int(db.ExecuteScalar(strCommand).ToString());
            return count;
        }

        public static List<ReasonApointmentModel> GetListReason(IDatabase db)
        {
            List<ReasonApointmentModel> list = new List<ReasonApointmentModel>();
            string strCommand = "Select * from ReasonApoinment";
            DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader;
            while (reader.Read())
            {
                ReasonApointmentModel reason = new ReasonApointmentModel();
                reason.ID = reader.GetInt32(0);
                reason.Reason = reader[1].ToString();
                list.Add(reason);
            }
            reader.Close();
            return list;
        }
        #endregion

        /// <summary>
        /// Search value next in table.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="nameOfColumn"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        internal static int SearchMaxValueOfTable(string table, string nameOfColumn, string order)
        {
            string strCommand = " SELECT  " + nameOfColumn + " FROM " + table + " ORDER BY " + nameOfColumn + " " + order + " LIMIT 1";
            //MySqlCommand comm = new MySqlCommand(strCommand, Program.conn);
            IDatabase db = DatabaseFactory.Instance;
            using (DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader)
            {

                reader.Read();
                int intTemp = 0;
                if (reader.HasRows)
                {
                    intTemp = ConvertString2Int(reader.GetValue(0));                   
                }
                else
                {
                    intTemp = 0;
                }
                int newId = intTemp + 1;
                return newId;
            }
        }

        internal static int SearchMaxValueOfTableWithoutPlusPlus(string table, string nameOfColumn, string order)
        {
            string strCommand = " SELECT  " + nameOfColumn + " FROM " + table + " ORDER BY " + nameOfColumn + " " + order + " LIMIT 1";
            //MySqlCommand comm = new MySqlCommand(strCommand, Program.conn);
            IDatabase db = DatabaseFactory.Instance;
            using (DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader)
            {

                reader.Read();
                int intTemp = 0;
                if (reader.HasRows)
                {
                    string temp = reader.GetValue(0).ToString();
                    try
                    {
                        intTemp = int.Parse(temp);
                    }
                    catch (Exception)
                    {
                    }
                    finally
                    {
                        reader.Close();
                    }
                }
                else
                {
                    intTemp = 0;
                }
                int newId = intTemp;
                return newId;
            }
        }

        internal static string SearchIDHistoryByIDPatientAndDay(string idPatient, string visitDate)
        {
            string strCommand = "SELECT IdHistory FROM history WHERE Id = " + ConvertToSqlString(idPatient) + " AND Day=" + ConvertToSqlString(visitDate) + ";";
            //MySqlCommand comm = new MySqlCommand(strCommand, conn);
            IDatabase db = DatabaseFactory.Instance;
            DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader;
            reader.Read();
            try
            {
                bool result = reader.HasRows;
                string idHistory = string.Empty;
                if (result)
                {
                    idHistory = reader["IdHistory"].ToString();
                }
                return idHistory;
            }
            finally
            {
                reader.Close();
            }
        }


        // public Patient AddNewPatient(SqlConnection conn, string id, bool Old)
        //{
        //Patient patient = new Patient();
        //patient.Name = txtBoxWaitRoomName.Text.Trim();

        //patient.Birthday = dateTimePicker2.Value;
        //patient.Old = DateTime.Now.Year - patient.Birthday.Year;
        //patient.Address = txtBoxWaitRoomAddress.Text;
        //patient.Symptom = txtBoxWaitingRoomSymptom.Text;
        //patient.Id = id;
        //try
        //{
        //    patient.Weight = int.Parse(txtBoxWaitingRoomWeight.Text);
        //}
        //catch (Exception ex)
        //{
        //    patient.Weight = 0;
        //}
        //try
        //{
        //    patient.Height = int.Parse(txtBoxWaitRoomHeight.Text);
        //}
        //catch (Exception ex)
        //{
        //    patient.Height = 0;
        //}

        //if (Old)
        //{
        //    return patient;
        //}

        //List<string> columns = new List<string>() { "Name", "Old", "Address", "Height", "Weight", "Birthday", "Id" };
        //List<string> values = new List<string>() { patient.Name, patient.Old.ToString(), patient.Address, patient.Height.ToString(), patient.Weight.ToString(), patient.Birthday.ToString("yyyy-MM-dd"), patient.Id };

        //Helper.InsertRowToTable(conn, "Patient", columns, values);
        //MessageBox.Show("Thêm mới bệnh nhân thành công");

        //return patient;

        // }

        public static void DefineStyles(Document document)
        {

            Style style = document.Styles["Normal"];

            style.Font.Name = "Times New Roman";



            style = document.Styles["Heading1"];

            style.Font.Name = "Tahoma";

            style.Font.Size = 18;

            style.Font.Bold = true;

            style.Font.Color = Colors.DarkBlue;

            style.ParagraphFormat.PageBreakBefore = true;

            style.ParagraphFormat.SpaceAfter = 6;



            style = document.Styles["Heading2"];

            style.Font.Size = 18;

            style.Font.Bold = true;

            style.ParagraphFormat.PageBreakBefore = false;

            style.ParagraphFormat.SpaceBefore = 10;

            style.ParagraphFormat.SpaceAfter = 24;



            style = document.Styles["Heading3"];

            style.Font.Size = 18;

            style.Font.Bold = true;

            style.Font.Italic = true;

            style.ParagraphFormat.SpaceBefore = 10;

            style.ParagraphFormat.SpaceAfter = 24;



            style = document.Styles[StyleNames.Header];

            style.ParagraphFormat.AddTabStop("20cm", TabAlignment.Right);



            style = document.Styles[StyleNames.Footer];

            style.ParagraphFormat.AddTabStop("12cm", TabAlignment.Center);



            // Create a new style called TextBox based on style Normal

            style = document.Styles.AddStyle("TextBox", "Normal");

            style.ParagraphFormat.Alignment = ParagraphAlignment.Justify;

            style.ParagraphFormat.Borders.Width = 9.5;

            style.ParagraphFormat.Borders.Distance = "5pt";

            style.ParagraphFormat.Shading.Color = Colors.SkyBlue;



            // Create a new style called TOC based on style Normal

            style = document.Styles.AddStyle("TOC", "Normal");

           // style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right, TabLeader.Dots);

            style.ParagraphFormat.Font.Color = Colors.Blue;
        }

        internal static void CreateAPdfThongKeDoanhThu(System.Windows.Forms.DataGridView dataGridView, string namePDF,int tongLuotKham,string tongDoanhThu)
        {
            Document document = new Document();
            document.Info.Author = "Luong Y";
            Unit width, height;
            PageSetup.GetPageSize(PageFormat.A4, out width, out height);
            document.DefaultPageSetup.PageWidth = width;
            document.DefaultPageSetup.PageHeight = height;

            Section section = document.AddSection();

            Paragraph paragraphTitle = section.AddParagraph();
            paragraphTitle.Format.Alignment = ParagraphAlignment.Center;
            paragraphTitle.AddTab();
            paragraphTitle.AddTab();



            paragraphTitle.AddFormattedText("Doanh Thu \n \n", new MigraDoc.DocumentObjectModel.Font("Times New Roman", 24));




            section.PageSetup.LeftMargin = 1;

            Paragraph paragraph = section.Headers.Primary.AddParagraph();

            paragraph.AddText("Lượt Khám: "+tongLuotKham.ToString()); 
            paragraph.AddText(" \n");

            paragraph.AddText("Tổng tiền: "+tongDoanhThu);
            paragraph.AddText(" \n");

            Table tableMedicines = section.AddTable();
            tableMedicines.Borders.Width = 0.5;
            tableMedicines.BottomPadding = 1;
            //Column columnMedicines1 = tableMedicines.AddColumn(30);
            //for (int i = 0; i < dataGridView.Columns.Count; i++)
            //{
                Column columnMedicines1 = tableMedicines.AddColumn();
                Column columnMedicines2 = tableMedicines.AddColumn(200);
                Column columnMedicines3 = tableMedicines.AddColumn(100);
                Column columnMedicines4 = tableMedicines.AddColumn(50);
                Column columnMedicines5 = tableMedicines.AddColumn(200);
            //}


                Row rowHeaderText = tableMedicines.AddRow();
                rowHeaderText.Cells[0].AddParagraph("Ngày khám");
                rowHeaderText.Cells[1].AddParagraph("Tên bác sĩ");
                rowHeaderText.Cells[2].AddParagraph("Tiền");
                rowHeaderText.Cells[3].AddParagraph("ID bệnh nhân");
                rowHeaderText.Cells[4].AddParagraph("Tên bệnh nhân");



            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                Row row = tableMedicines.AddRow();
                row.Cells[0].AddParagraph(dataGridView.Rows[i].Cells["date"].Value != null ? dataGridView.Rows[i].Cells["date"].Value.ToString() : "");
                row.Cells[1].AddParagraph(dataGridView.Rows[i].Cells["NameDoctor"].Value != null ? dataGridView.Rows[i].Cells["NameDoctor"].Value.ToString() : "");
                row.Cells[2].AddParagraph(dataGridView.Rows[i].Cells["Money"].Value != null ? dataGridView.Rows[i].Cells["Money"].Value.ToString() : "");
                row.Cells[3].AddParagraph(dataGridView.Rows[i].Cells["ColumnIdPatient"].Value != null ? dataGridView.Rows[i].Cells["ColumnIdPatient"].Value.ToString() : "");
                row.Cells[4].AddParagraph(dataGridView.Rows[i].Cells["ColumnNamePatient"].Value != null ? dataGridView.Rows[i].Cells["ColumnNamePatient"].Value.ToString() : "");

            }


            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always);
            pdfRenderer.Document = document;
            pdfRenderer.RenderDocument();
            pdfRenderer.PdfDocument.Save(namePDF + ".pdf");
        }


        internal static void CreateAPdfThongKe(System.Windows.Forms.DataGridView dataGridView, string namePDF)
        {
            Document document = new Document();
            document.Info.Author = "Luong Y";
            Unit width, height;
            PageSetup.GetPageSize(PageFormat.A4, out width, out height);
            document.DefaultPageSetup.PageWidth = width;
            document.DefaultPageSetup.PageHeight = height;

            Section section = document.AddSection();

            Paragraph paragraphTitle = section.AddParagraph();
            paragraphTitle.Format.Alignment = ParagraphAlignment.Center;
            paragraphTitle.AddTab();
            paragraphTitle.AddTab();



              paragraphTitle.AddFormattedText("Tủ Thuốc \n \n", new MigraDoc.DocumentObjectModel.Font("Times New Roman", 24));
 



            section.PageSetup.LeftMargin = 1;

            Table tableMedicines = section.AddTable();
            tableMedicines.Borders.Width = 0.5;
            tableMedicines.BottomPadding = 1;
            //Column columnMedicines1 = tableMedicines.AddColumn(30);
            for (int i = 0; i<dataGridView.Columns.Count; i++)
            {

                if (i == 1)
                {
                    Column columnMedicines1 = tableMedicines.AddColumn(150);
                    
                }
                else {
                    Column columnMedicines1 = tableMedicines.AddColumn();
                }
            }

            Row rowHeaderText = tableMedicines.AddRow();
            rowHeaderText.Cells[0].AddParagraph("Id");
            rowHeaderText.Cells[1].AddParagraph("Tên thuốc");
            rowHeaderText.Cells[2].AddParagraph("Số lượng");
            rowHeaderText.Cells[3].AddParagraph("Giá vào");
            rowHeaderText.Cells[4].AddParagraph("Giá ra");
            rowHeaderText.Cells[5].AddParagraph("Ngày nhập");

            for (int i = 0; i < dataGridView.Rows.Count-1; i++)
            {
                Row row = tableMedicines.AddRow();
                row.Cells[0].AddParagraph(dataGridView.Rows[i].Cells["ColumnId"].Value != null ? dataGridView.Rows[i].Cells["ColumnId"].Value.ToString() : "");
                row.Cells[1].AddParagraph(dataGridView.Rows[i].Cells["ColumnName"].Value != null ? dataGridView.Rows[i].Cells["ColumnName"].Value.ToString() : "");
                row.Cells[2].AddParagraph(dataGridView.Rows[i].Cells["ColumnCount"].Value != null ? dataGridView.Rows[i].Cells["ColumnCount"].Value.ToString() : "");
                row.Cells[3].AddParagraph(dataGridView.Rows[i].Cells["ColumnCostIn"].Value != null ? dataGridView.Rows[i].Cells["ColumnCostIn"].Value.ToString() : "");
                row.Cells[4].AddParagraph(dataGridView.Rows[i].Cells["ColumnCostOut"].Value != null ? dataGridView.Rows[i].Cells["ColumnCostOut"].Value.ToString() : "");
                row.Cells[5].AddParagraph(dataGridView.Rows[i].Cells["ColumnInputDay"].Value != null ? dataGridView.Rows[i].Cells["ColumnInputDay"].Value.ToString() : "");
            }
            

            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always);
            pdfRenderer.Document = document;
            pdfRenderer.RenderDocument();
            pdfRenderer.PdfDocument.Save(namePDF+".pdf");
        }
        public static void CreateAPdf(InfoClinic InformationOfClinic, string MaBn, Patient patient, List<Medicine> Medicines, string taikham, string Diagno, string tuoi,int Stt,string reasonComeBack)
        {
            Document document = new Document();
            document.Info.Author = "Luong Y";
             Unit width, height;
            PageSetup.GetPageSize(PageFormat.A5, out width, out height);
            document.DefaultPageSetup.PageWidth = width;
            document.DefaultPageSetup.PageHeight = height;
           
            int tongTienThuoc = 0;
            AddSection(document, InformationOfClinic, MaBn, patient, Medicines, false, taikham, ref  tongTienThuoc, Diagno, tuoi, Stt, reasonComeBack);

            AddSection(document, InformationOfClinic, MaBn, patient, Medicines, true, taikham, ref  tongTienThuoc, Diagno, tuoi, Stt, reasonComeBack);

            //document.LastSection.AddPageBreak();





            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always);
     
            pdfRenderer.Document = document;
            pdfRenderer.RenderDocument();
            pdfRenderer.PdfDocument.Save("firstpage.pdf");


        }

        private static void AddSection(Document document, InfoClinic InformationOfClinic, string MaBn, Patient patient, List<Medicine> Medicines, bool onlyServices, string taikham, ref int tongTienThuoc, string Diagno, string tuoi, int Stt, string reasonComeBack)
        {
            Section section = document.AddSection();
            section.PageSetup.LeftMargin = 10;


            Paragraph paragraph =section.Headers.Primary.AddParagraph();
             //= section.AddParagraph();
      
            paragraph.Format.Alignment = ParagraphAlignment.Left;

            paragraph.AddText(InformationOfClinic.Name); //+"Mã BN: " + patient.Id + " \n" +" Địa chỉ xxxxx");
            paragraph.AddText(" \n");

            string[] addressArray = InformationOfClinic.Address.Split(';');
            try
            {
                paragraph.AddSpace(int.Parse(addressArray[0]));
                paragraph.AddText(addressArray[1]);
                paragraph.AddText(" \n");

                string[] sdtArray = InformationOfClinic.Sdt.Split(';');
                paragraph.AddSpace(int.Parse(sdtArray[0]));
                paragraph.AddText(sdtArray[1]);
            }
            catch (Exception ex)
            {
                paragraph.AddSpace(10);
            }
            



            


            Paragraph paragraph2 = section.Headers.Primary.AddParagraph();

            paragraph2.Format.Alignment = ParagraphAlignment.Right;
            paragraph2.AddText("ID : " + MaBn);
            paragraph2.AddText(" \n");
            paragraph2.AddText("STT : " + Stt);

            paragraph.AddText(" \n");
            paragraph.AddText(" \n");
            paragraph.AddText(" \n");
            paragraph.AddText(" \n");
            //Table InfoTable = section.AddTable();
            //InfoTable.Borders.Width = 0;
            //Column ColumnInfo1 = InfoTable.AddColumn(500);
            //Row rowInfoName = InfoTable.AddRow();
            //Paragraph para1 = rowInfoName.Cells[0].AddParagraph(InformationOfClinic.Name);
            //Row rowInfo2 = InfoTable.AddRow();



            //Paragraph paraInfo = rowInfo2.Cells[0].AddParagraph();
            //paraInfo.AddSpace(4);
            //paraInfo.AddText(InformationOfClinic.Address);
            //rowsignatureAndMore2.Cells[0].AddParagraph(taikham);
            //Paragraph para = rowsignatureAndMore2.Cells[2].AddParagraph(" \n \n \n \n" + Form1.nameOfDoctor);
            //para.Format.Alignment = ParagraphAlignment.Center;
           



            Paragraph paragraphTitle = section.AddParagraph();
            paragraphTitle.Format.Alignment = ParagraphAlignment.Center;
            paragraphTitle.AddTab();
            paragraphTitle.AddTab();
            if (!onlyServices)
            {
                paragraphTitle.AddFormattedText("TOA THUỐC \n \n", new MigraDoc.DocumentObjectModel.Font("Times New Roman", 24));
            }
            else
            {
                paragraphTitle.AddFormattedText("Bảng Dịch Vụ \n \n", new MigraDoc.DocumentObjectModel.Font("Times New Roman", 24));
            }

            Table table = new Table();
            table.Borders.Width = 0;
            Column column = table.AddColumn();
            column.Width = 80;
            table.AddColumn(440);

            Row row = table.AddRow();
            row.Cells[0].AddParagraph("Bệnh nhân: ");
            row.Cells[1].AddParagraph(patient.Name);
            //int tuoi = DateTime.Now.Year - patient.Birthday.Year;
            row.Cells[0].AddParagraph("Tuổi:");
            row.Cells[1].AddParagraph(tuoi);
            Row row2 = table.AddRow();
            row2.Cells[0].AddParagraph("Địa chỉ: ");
            row2.Cells[1].AddParagraph(patient.Address);
            //row2.Cells[2].AddParagraph("Mã BN: "+ patient.Id);
            if (!onlyServices)
            {
                Row row3 = table.AddRow();
                row3.Cells[0].AddParagraph("Chẩn đoán: ");
                row3.Cells[1].AddParagraph(Diagno);
            }


            
            Table tableMedicines = new Table();
            tableMedicines.Borders.Width = 0;
            tableMedicines.BottomPadding = 10;
            Column columnMedicines1 = tableMedicines.AddColumn(30);
            Column columnMedicines2;
            if (onlyServices)
            {
               columnMedicines2 = tableMedicines.AddColumn(140);
            }
            else
            {
                 columnMedicines2 = tableMedicines.AddColumn(240);
            }
            Column columnMedicines3 = tableMedicines.AddColumn(70);
            Column columnMedicines4 = tableMedicines.AddColumn(130);
            Row rowMedicinesHeader = tableMedicines.AddRow();
            rowMedicinesHeader.Cells[0].AddParagraph("STT");
            if (!onlyServices)
            {
                rowMedicinesHeader.Cells[1].AddParagraph("Tên thuốc/Cách dùng");
            }
            else
            {
                rowMedicinesHeader.Cells[1].AddParagraph("Tên dịch vụ");
            }
            rowMedicinesHeader.Cells[2].AddParagraph("Số lượng");


            if (onlyServices)
            {
                rowMedicinesHeader.Cells[3].AddParagraph("Số tiền");
                int totalServices = 0;
                int indexServices = 1;
                for (int i = 0; i < Medicines.Count; i++)
                {
                    if (Medicines[i].Name[0] == '@')
                    {
                        string name = Medicines[i].Name.Substring(1, Medicines[i].Name.Length - 1);
                        Row rowDetail = tableMedicines.AddRow();
                        rowDetail.Cells[0].AddParagraph(indexServices.ToString());
                        rowDetail.Cells[1].AddParagraph(name + "\n" + Medicines[i].HDSD);
                        rowDetail.Cells[2].AddParagraph(Medicines[i].Number.ToString());
                        int thanhtien = Medicines[i].CostOut * Medicines[i].Number;
                        rowDetail.Cells[3].AddParagraph(thanhtien.ToString("C0"));
                        indexServices++;

                        totalServices += thanhtien;
                    }

                }
                //tong cong thuoc

                Row rowTotalThuoc = tableMedicines.AddRow();
                rowTotalThuoc.Cells[1].AddParagraph("Thuốc");
                rowTotalThuoc.Cells[3].AddParagraph(tongTienThuoc.ToString("C0"));



                Row gachdit = tableMedicines.AddRow();
                gachdit.Cells[3].AddParagraph("________________");

                int total = totalServices + tongTienThuoc;

                Row rowTotal = tableMedicines.AddRow();
                rowTotal.Cells[2].AddParagraph("Tổng cộng:");
                rowTotal.Cells[3].AddParagraph(total.ToString("C0"));
            }
            else
            {
                int indexMedicines = 1;
                for (int i = 0; i < Medicines.Count; i++)
                {
                    if (Medicines[i].Name[0] != '@')
                    {
                        Row rowDetail = tableMedicines.AddRow();
                        rowDetail.Cells[0].AddParagraph(indexMedicines.ToString());
                        rowDetail.Cells[1].AddParagraph(Medicines[i].Name + "\n" + Medicines[i].HDSD);
                        rowDetail.Cells[2].AddParagraph(Medicines[i].Number.ToString());
                        indexMedicines++;
                        tongTienThuoc += Medicines[i].Number * Medicines[i].CostOut;
                    }
                }
            }

            //Table loi dan , chu ky
            Table signatureAndMore = new Table();
            signatureAndMore.Borders.Width = 0;
            Column columnsignatureAndMore1 = signatureAndMore.AddColumn(150);
            Column columnsignatureAndMore2 = signatureAndMore.AddColumn(50);
            Column columnsignatureAndMore3 = signatureAndMore.AddColumn(210);
            Row rowsignatureAndMore1 = signatureAndMore.AddRow();

            if (!onlyServices)
            {
               // rowsignatureAndMore1.Cells[0].AddParagraph("Lời dặn: " + InformationOfClinic.Advice);
            }
            Paragraph paramNgayThang = rowsignatureAndMore1.Cells[2].AddParagraph("Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year);
            paramNgayThang.Format.Alignment = ParagraphAlignment.Center;
            Row rowsignatureAndMore2 = signatureAndMore.AddRow();
            rowsignatureAndMore2.VerticalAlignment = VerticalAlignment.Center;
            //rowsignatureAndMore2.Cells[0].AddParagraph(taikham + ": " + reasonComeBack);
            Paragraph para = rowsignatureAndMore2.Cells[2].AddParagraph(" \n \n \n" + Form1.nameOfDoctor);
            para.Format.Alignment = ParagraphAlignment.Center;

            document.LastSection.Add(table);
            document.LastSection.AddParagraph("\n");
            document.LastSection.Add(tableMedicines);
            document.LastSection.AddParagraph("\n");
            document.LastSection.Footers.Primary.Add(signatureAndMore);

        }

        internal static string ConvertToDatetimeSql(DateTime dateTime)
        {
            return dateTime.Year + "-" + dateTime.Month + "-" + dateTime.Day + " " + dateTime.Hour + ":" + dateTime.Minute + ":" + dateTime.Second;
        }

        internal static System.Drawing.Color ConvertCodeToColor(int p)
        {
            switch (p)
            {
                case 1:
                    return System.Drawing.Color.Red;
                case 2:
                    return System.Drawing.Color.Yellow;
                case 3:
                    return System.Drawing.Color.Green;
                case 4:
                    return System.Drawing.Color.Blue;
                default:
                    return System.Drawing.Color.White;
            }
        }



        internal static List<Medicine> GetAllMedicinesFromDataGrid(IDatabase db, System.Windows.Forms.DataGridView dataGridView)
        {
            //List<int> listCountMedicines = new List<int>();
            List<Medicine> result = new List<Medicine>();

            for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
            {
                Medicine medic = new Medicine();
                if (dataGridView[DatabaseContants.IdColumnInDataGridViewMedicines, i].Value == null)
                {
                    continue;
                }
                medic.Id = dataGridView[DatabaseContants.IdColumnInDataGridViewMedicines, i].Value.ToString();
                medic.Number = Helper.ConvertString2Int(dataGridView[DatabaseContants.CountColumnInDataGridViewMedicines, i].Value);
                medic.Name = dataGridView[DatabaseContants.NameColumnInDataGridViewMedicines, i].Value.ToString();
                medic.HDSD = dataGridView[DatabaseContants.HDSDColumnInDataGridViewMedicines, i].Value.ToString();
                medic.CostOut = Helper.ConvertString2Int(dataGridView[DatabaseContants.CostColumnInDataGridViewMedicines, i].Value);
                medic.Count = Helper.ConvertString2Int(dataGridView[DatabaseContants.StoreColumnInDataGridViewMedicines, i].Value);
                result.Add(medic);
            }
            return result;

        }

        private static string ConvertListToListSQL(List<string> listIdMedicines)
        {
            string result = "(";
            for (int i = 0; i < listIdMedicines.Count; i++)
            {
                result += ConvertToSqlString(listIdMedicines[i]) + ',';

            }
            result = result.Substring(0, result.Length - 1);
            result = result += ")";
            return result;
        }

        internal static Dictionary<string,Service> FilterServicesFromAllMedicines(List<Medicine> currentMedicinesAndServices)
        {
            Dictionary<string, Service> services = new Dictionary<string,Service>();
            foreach (Medicine medi in currentMedicinesAndServices)
            {
                if (medi.Name[0] == '@')
                {
                    Service service = new Service();
                    service.Id = medi.Id;
                    service.Name = medi.Name;
                    service.Admin = medi.Admin;
                    services.Add(medi.Name,service);
                }
            }
            return services;
        }

        internal static bool CheckMedicineExists(IDatabase db, string Id)
        {
            string strCommand = "SELECT Id FROM medicine WHERE Id = " + ConvertToSqlString(Id);
            DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader;
            reader.Read();

            try
            {
                return reader.HasRows;
            }
            finally
            {
                reader.Close();

            }
        }

        // change medicine in db into string in datagridview search
        public static string ChangeListMedicines(string medicines)
        {
            if (!medicines.Contains(','))
            {
                return "";
            }
            string result = "";
            string[] newMedicine = medicines.Split('|');
            
            if (newMedicine.Length == 1)
            {
                string[] medicinesAndCount = medicines.Split(',');
                if (CheckDataOld(medicinesAndCount))
                {
                    for (int i = 0; i < medicinesAndCount.Length; i = i + 2)
                    {
                        string temp = medicinesAndCount[i] + ":" + medicinesAndCount[i + 1];
                        result += temp;
                        if (i != medicinesAndCount.Length - 2)
                        {
                            result += "\n";
                        }
                    }
                    return result;
                }
                else
                {
                    for (int i = 0; i < medicinesAndCount.Length; i = i + 3)
                    {
                        string temp = medicinesAndCount[i] + ":" + medicinesAndCount[i + 1];
                        result += temp;
                        if (i != medicinesAndCount.Length - 3)
                        {
                            result += "\n";
                        }
                    }
                    return result;
                }
            }
            else
            {
                for (int i = 0; i < newMedicine.Length; i++)
                {
                    string[] parts = newMedicine[i].Split(',');
                    if (parts.Length < 4)
                        return string.Empty;
                    string temp = parts[0] + ":" + parts[1];
                    result += temp;
                    if (i != newMedicine.Length - 1)
                        result += "\n";
                }
                return result;
            }
            
        }

        public static bool CheckDataOld(string[] medicineAndCount)
        {
            if (medicineAndCount.Length < 3)
            {
                return true;
            }
            else
            {
                try
                {
                    if (medicineAndCount[2] == "!")
                        return false;
                    int temp = int.Parse(medicineAndCount[2]);
                    return false;
                }
                catch (Exception ex)
                {
                    return true;
                }
            }
        }

        public static bool CheckDataMedicineOld(string medicine)
        {
            if (medicine.Contains('|'))
                return false;
            string[] medicines = medicine.Split(',');

            if (medicines.Length != 4)
                return true;
            try
            {
                if (medicines[2] == "!")
                    return true;
                int temp = int.Parse(medicines[2]);
                return false;
            }
            catch (Exception ex)
            {
                return true;
            }
        }
        internal static string GetNameOfDoctor(IDatabase db, string name)
        {
            string strCommand = "SELECT * FROM clinicuser where Username = " + Helper.ConvertToSqlString(name);
            DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader;
            reader.Read();

            try
            {
                if (reader["namedoctor"] != null)
                    return reader["namedoctor"].ToString();
                return "";
            }
            finally
            {
                reader.Close();

            }
        }

        internal static Dictionary<string, string> GetListPatientToday(IDatabase db)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            string strCommand = "SELECT * FROM listpatienttoday";
            DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader;


            try
            {
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        result.Add(reader["Id"].ToString(), reader["name"].ToString() + ";" + reader["state"].ToString());
                    }

                }
                return result;
            }
            finally
            {
                reader.Close();

            }
        }

        internal static List<ItemDoanhThu> DoanhThuTheoNgay(IDatabase db, DateTime dateTime)
        {
            List<ItemDoanhThu> result = new List<ItemDoanhThu>();

            if (dateTime > dateOld)
            {
                string strCommand = " SELECT * FROM doanhthu   WHERE time = " + Helper.ConvertToSqlString(dateTime.ToString("yyyy-MM-dd"));
                result.AddRange(DoanhThuNew(db, strCommand));
            }
            else
            {
                result.AddRange(DoanhThuTheoNgayDataOld(db, dateTime));
            }

            return result;

        }

        internal static int SoluotKham0DongInDay(IDatabase db, DateTime dateTime)
        {
            List<ItemDoanhThu> result = new List<ItemDoanhThu>();
            string strCommand = string.Format("SELECT count(*) FROM doanhthu WHERE time = {0} and {1} = 0", Helper.ConvertToSqlString(dateTime.ToString("yyyy-MM-dd")),DatabaseContants.danhthu.Money);
            return Helper.ConvertString2Int(db.ExecuteScalar(strCommand));
        }

        internal static List<ItemDoanhThu> DoanhThuTheoNgayDataOld(IDatabase db, DateTime dateTime)
        {
            List<ItemDoanhThu> result = new List<ItemDoanhThu>();
            //Data old should get history
            string strCommand = string.Format("select * from {0} where Day = {1} and Medicines != N{2}", DatabaseContants.tables.history, Helper.ConvertToSqlString(dateTime.ToString("yyyy-MM-dd")), Helper.ConvertToSqlString("Dd nhập bệnh nhân mới,!"));
            result.AddRange(DoanhThuDataOld(db, strCommand));
            return result;
        }

        private static string GetNameOfDoctorInDoanhThuByIdPatient(IDatabase database, string idPatien,string date)
        {
            string strcmd = string.Format("select {0} from {1} where {2} = {3} and {4} = {5}", DatabaseContants.danhthu.NameDoctor, DatabaseContants.tables.danhthu, DatabaseContants.danhthu.IdPatient, idPatien, DatabaseContants.danhthu.time, Helper.ConvertToSqlString(date));
            using (DbDataReader reader = database.ExecuteReader(strcmd, null) as DbDataReader)
            {
                reader.Read();
                if (reader.HasRows)
                {
                    return reader[DatabaseContants.danhthu.NameDoctor].ToString();
                }
            }
            return string.Empty;
        }

        static string  GetDiagnoseFromHistoryByIdHistory(int idHistory , IDatabase db2)
        {
            string result = "";

            string strCommand = " SELECT "+ClinicConstant.HistoryTable_Diagnose+" FROM "+ClinicConstant.HistoryTable  +" WHERE "+ClinicConstant.HistoryTable_IdHistory+" = " + Helper.ConvertToSqlString(idHistory.ToString());
            using (DbDataReader reader = db2.ExecuteReader(strCommand, null) as DbDataReader)
            {
                reader.Read();
                if (reader.HasRows)
                {
                    result = reader[ClinicConstant.HistoryTable_Diagnose].ToString();
                }
            }
            return result;
        }


        internal static int LaySTTTheoNgay(IDatabase db, DateTime dateTime, string Id)
        {

            List<string> result = new List<string>();
            int i = 0;
            string strCommand = " SELECT * FROM doanhthu WHERE time = " + Helper.ConvertToSqlString(dateTime.ToString("yyyy-MM-dd"));
            using (DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader)
            {
                while (reader.Read())
                {

                    i++;
                  
                    string IdPatient = reader[ClinicConstant.DoanhThuTable_IdPatient].ToString();
                    if (Id == IdPatient)
                    {
                        return i;
                    }
                    //if (result.Contains(IdPatient) == false)
                    //{
                    //    result.Add(IdPatient);
                    //}
                    //else
                    //{
                    //    return i;
                    //}

                }
            }


            return i;
        }

        internal static List<ItemDoanhThu> DoanhThuTheoThang(IDatabase db, DateTime dateTime)
        {
            List<ItemDoanhThu> result = new List<ItemDoanhThu>();

            //string strCommand = " SELECT * FROM doanhthu   WHERE month(time) = " + dateTime.Month.ToString();
            
            if (dateTime > dateOld)
            {
                string strCommand = string.Format("select * from {0} where {1} = {2} and {3} = {4}", ClinicConstant.DoanhThuTable, "month(" + DatabaseContants.danhthu.time + ")", dateTime.Month.ToString(), "YEAR(" + DatabaseContants.danhthu.time + ")", dateTime.Year.ToString());
                result.AddRange(DoanhThuNew(db, strCommand));
            }
            else
            {
                //Data old should get history
                string strCommand = string.Format("select * from {0} where {1} = {2} and {3} = {4} and Medicines != N{5}", ClinicConstant.HistoryTable, "month(" + DatabaseContants.history.Day + ")", dateTime.Month.ToString(), "YEAR(" + DatabaseContants.history.Day + ")", dateTime.Year.ToString(), Helper.ConvertToSqlString("Dd nhập bệnh nhân mới,!"));
                result.AddRange(DoanhThuDataOld(db, strCommand));
            }

            return result;
        }

        internal static List<ItemDoanhThu> DoanhThuTheoNam(IDatabase db, DateTime dateTime)
        {
            List<ItemDoanhThu> result = new List<ItemDoanhThu>();
            if (dateTime > dateOld)
            {
                string strCommand = " SELECT * FROM doanhthu   WHERE YEAR(time) = " + dateTime.Year.ToString();
                result.AddRange(DoanhThuNew(db, strCommand));
            }
            else
            {
                //Data old should get history
                string strCommand = string.Format("select * from {0} where {1} = {2} and Medicines != N{3}", ClinicConstant.HistoryTable, "YEAR(" + DatabaseContants.history.Day + ")", dateTime.Year.ToString(), Helper.ConvertToSqlString("Dd nhập bệnh nhân mới,!"));
                result.AddRange(DoanhThuDataOld(db, strCommand));
            }

            return result;
        }

        internal static List<ItemDoanhThu> DoanhThuDataOld(IDatabase db, string strcommand)
        {
            List<ItemDoanhThu> result = new List<ItemDoanhThu>();
            //Data old should get history

            using (DbDataReader reader = db.ExecuteReader(strcommand, null) as DbDataReader)
            {
                while (reader.Read())
                {

                    ItemDoanhThu item = new ItemDoanhThu();
                    DateTime datetime = reader.GetDateTime(reader.GetOrdinal(DatabaseContants.history.Day));
                    item.Date = datetime.ToString("dd-MM-yyyy");
                    item.IdPatient = reader[DatabaseContants.history.IdPatient].ToString();
                    //var value = result.Where(m => m.IdPatient == item.IdPatient && m.Date == item.Date).FirstOrDefault();
                    //if (value != null)
                    // continue;

                    item.NameOfDoctor = reader[DatabaseContants.history.nameofdoctor].ToString();
                    if (string.IsNullOrEmpty(item.NameOfDoctor))
                    {
                        item.NameOfDoctor = GetNameOfDoctorInDoanhThuByIdPatient(DatabaseFactory.Instance2, item.IdPatient, datetime.ToString("yyyy-MM-dd"));
                    }

                    string medicines = reader[DatabaseContants.history.Medicines].ToString();
                    List<Medicine> medicineList = ConvertString2MedicineList(medicines);
                    item.Money = medicineList.Sum(m => m.CostOut * m.Number);
                    item.NamePatient = GetNamePatientByID(item.IdPatient, DatabaseFactory.Instance2);
                    item.Services = BuildStringServices4SavingToDoanhThu(medicineList);
                    item.LoaiKham = reader[DatabaseContants.history.namLoaiKham].ToString();
                    item.Diagnose = reader[DatabaseContants.history.Diagnose].ToString();
                    if (result.Where(x => x.IdPatient == item.IdPatient && x.Date == item.Date).FirstOrDefault() == null)
                    {
                        result.Add(item);
                    }

                }
            }
            return result;
        }

        internal static List<ItemDoanhThu> DoanhThuNew(IDatabase db, string strcommand)
        {
            List<ItemDoanhThu> result = new List<ItemDoanhThu>();

            using (DbDataReader reader = db.ExecuteReader(strcommand, null) as DbDataReader)
            {
                while (reader.Read())
                {
                    ItemDoanhThu item = new ItemDoanhThu();
                    item.Date = reader.GetDateTime(reader.GetOrdinal(ClinicConstant.DoanhThuTable_Time)).ToString("dd-MM-yyyy");
                    item.NameOfDoctor = reader[ClinicConstant.DoanhThuTable_Namedoctor].ToString();
                    item.Money = (int)reader[ClinicConstant.DoanhThuTable_Money];
                    item.IdPatient = reader[ClinicConstant.DoanhThuTable_IdPatient].ToString();
                    item.NamePatient = reader[ClinicConstant.DoanhThuTable_NamePatient].ToString();
                    item.Services = reader[ClinicConstant.DoanhThuTable_Services].ToString();
                    item.LoaiKham = reader[ClinicConstant.DoanhThuTable_LoaiKham].ToString();

                    try
                    {
                        int idHistory = (int)reader[ClinicConstant.HistoryTable_IdHistory];
                        item.Diagnose = GetDiagnoseFromHistoryByIdHistory(idHistory, DatabaseFactory.Instance2);
                    }
                    catch { item.Diagnose = ""; }
                    result.Add(item);

                }
            }

            return result;
        }
        internal static List<IMedicine> GetAllMedicinesAndServicesFromDB()
        {
            List<IMedicine> result = new List<IMedicine>();
            IDatabase db = DatabaseFactory.Instance;
            string strCommand = " SELECT * FROM medicine";
            using (DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader)
            {
                while (reader.Read())
                {
                    try
                    {

                        ObjectMedicine objectMedicine = new ObjectMedicine();
                        objectMedicine.Id = reader[DatabaseContants.medicine.Id] != null ? reader[DatabaseContants.medicine.Id].ToString() : "";
                        objectMedicine.Name = reader[DatabaseContants.medicine.Name] != null ? reader[DatabaseContants.medicine.Name].ToString() : "";
                        if (string.IsNullOrEmpty(objectMedicine.Id))
                            continue;
                        if (objectMedicine.Name[0] != '@')
                        {
                            objectMedicine.Count = (int)reader[DatabaseContants.medicine.Count];
                            objectMedicine.CostIn = (int)reader[DatabaseContants.medicine.CostIn];
                            objectMedicine.Admin = "";
                            objectMedicine.InputDay = reader.GetDateTime(reader.GetOrdinal(DatabaseContants.medicine.InputDay));
                            objectMedicine.HDSD = reader[DatabaseContants.medicine.Hdsd].ToString();
                        }
                        else // service
                        {
                            objectMedicine.Count = 0;
                            objectMedicine.CostIn = 1;
                            objectMedicine.Admin = reader[ClinicConstant.MedicineTable_Admin].ToString();
                            objectMedicine.InputDay = DateTime.Now;
                        }

                        objectMedicine.CostOut = (int)reader[DatabaseContants.medicine.CostOut];
       


                        result.Add(objectMedicine);
                        
                    }
                    catch (Exception e)
                    {
 
                    }
                }
            }

            return result;
        }

        public static List<IMedicine> GetAllMedicineFromDb()
        {
            return GetAllMedicinesAndServicesFromDB().Where(x => x.Name[0] != '@').ToList();
        
        }

        public static List<IMedicine> GetAllServiceFromDb()
        {
            return GetAllMedicinesAndServicesFromDB().Where(x => x.Name[0] == '@').ToList();

        }

        internal static void UpdateRowToTableDoanhThu(IDatabase db, string nameOfTable, List<string> columnsDoanhThu, List<string> valuesDoanhThu, string p_2)
        {
            string strCommand = BuildFirstPartUpdateQuery(nameOfTable, columnsDoanhThu, valuesDoanhThu);

            strCommand += " Where " + DatabaseContants.danhthu.IdPatient + "='" + p_2 + "'And time=" + ConvertToSqlString(DateTime.Now.ToString("yyyy-MM-dd")) + ";";

            //MySqlCommand comm = new MySqlCommand(strCommand, conn);
            db.ExecuteNonQuery(strCommand, null);
        }

        internal static bool checkVisitExistsDoanhThu(IDatabase db, string Id, string visitDate)
        {
            //string strCommand = "SELECT Idpatient FROM doanhthu WHERE Idpatient = " + ConvertToSqlString(Id) + " AND time=" + ConvertToSqlString(visitDate) + ";";

            string strCommand = string.Format("SELECT {0} FROM {1} WHERE {0} = {2} AND time ={3}", DatabaseContants.danhthu.IdPatient, DatabaseContants.tables.danhthu, ConvertToSqlString(visitDate));
            //MySqlCommand comm = new MySqlCommand(strCommand, conn);
            DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader;
            reader.Read();
            try
            {
                return reader.HasRows;
            }
            finally
            {
                reader.Close();

            }
        }

        internal static void DeleteRowFromTableCalendar(IDatabase db, string id, string name)
        {
            string strCommand = "Delete From lichhen";

            strCommand += " Where Idpatient='" + id + "' AND Namepatient='" + name + "';";

            //MySqlCommand comm = new MySqlCommand(strCommand, conn);
            db.ExecuteNonQuery(strCommand, null);

        }

        internal static string GetIdMedicineFromName(IDatabase db, string name)
        {
            string id = "";
            string strCommand = "Select Id from medicine where Name = " +ConvertToSqlString(name)  ;
            using (DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader)
            {
                reader.Read();
                if (reader.HasRows)
                {
                    id = reader[DatabaseContants.medicine.Id].ToString();
                }
            }
            return id;
        }

        internal static List<Medicine> GetMedicinesFromHistory(IDatabase db,string IdPatient, string datetime, ref bool isNew )
        {
            List<Medicine> result = new List<Medicine>();
            string strCommand = "Select Medicines from history where Id = " + IdPatient + " And Day=" + ConvertToSqlString(datetime);
            using (DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader)
            {
                reader.Read();
                if (reader.HasRows)
                {
                    string medicines = reader[DatabaseContants.history.Medicines].ToString();
                    if (medicines == "Dd nhập bệnh nhân mới,!,!" || medicines == "Dd nh?p b?nh nhân m?i,!" || medicines == "Dd nhập bệnh nhân mới,!")
                    {
                        isNew = true;
                        return result;
                    }
                    //string[] medicineAndCount = new string[] { };
                    //if (!string.IsNullOrEmpty(medicines))
                    //{
                    //    medicineAndCount = medicines.Split(',');
                    //    for (int i = 0; i < medicineAndCount.Length; i = i + 3)
                    //    {
                    //        Medicine medicine = new Medicine();
                    //        medicine.Name = medicineAndCount[i];
                    //        reader.Close();
                    //        medicine.Id = GetIdMedicineFromName(db, medicine.Name);
                    //        medicine.Number = int.Parse(medicineAndCount[i + 1]);
                    //        medicine.CostOut = int.Parse(medicineAndCount[i + 2]);
                    //        result.Add(medicine);
                    //    }
                    //}
                    if (!string.IsNullOrEmpty(medicines))
                    {
                        result = ConvertString2MedicineList(medicines);
                        reader.Close();
                    }
                }
            }
            return result;
        }

        internal static List<Medicine> GetMedicinesFromHistoryByID(IDatabase db, string IdHistory,ref bool isNew)
        {
            List<Medicine> result = new List<Medicine>();
            string strCommand = "Select Medicines from history where IdHistory = " + IdHistory;
            using (DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader)
            {
                reader.Read();
                if (reader.HasRows)
                {
                    string medicines = reader[DatabaseContants.history.Medicines].ToString();
                    if (medicines == "Dd nhập bệnh nhân mới,!,!" || medicines == "Dd nh?p b?nh nhân m?i,!" || medicines == "Dd nhập bệnh nhân mới,!")
                    {
                        isNew = true;
                        return result;
                    }
                    if (!string.IsNullOrEmpty(medicines))
                    {
                        result = ConvertString2MedicineList(medicines);
                        reader.Close();
                    }
                }
            }
            return result;
        }

        internal static void UpdateRowToTableMedicine(IDatabase db, string p, int offset, string p_2)
        {
            //get current number of medicine in store
            //string strCommand = "Select Count from medicine where Id = " + p_2;
            string strCommand = string.Format("select {0} from {1} where {2} = {3}", DatabaseContants.medicine.Count, DatabaseContants.tables.medicine, DatabaseContants.medicine.Id, p_2);

            DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader;
            reader.Read();
            if (reader.HasRows)
            {
                int numberInStore = int.Parse(reader[DatabaseContants.medicine.Count].ToString());
                int numberWillBe = numberInStore - offset;
                reader.Close();

                strCommand = "Update Medicine Set Count =" + numberWillBe.ToString() + " Where Id =" + p_2;
                db.ExecuteNonQuery(strCommand, null);
            }
            else
            {
                reader.Close();
            }
            
        }

        internal static void TruTuThuoc(IDatabase db,List<Medicine> listMedicines)
        {
            //tru tu thuoc
            for (int iThuoc = 0; iThuoc < listMedicines.Count; iThuoc++)
            {
                if (listMedicines[iThuoc].Name[0] != '@')
                {
                    int offsetThuoc = listMedicines[iThuoc].Number;
                    string idThuoc = listMedicines[iThuoc].Id.ToString();
                    Helper.UpdateRowToTableMedicine(db, "medicine", offsetThuoc, idThuoc);
                }
            }
        }

        internal static List<Medicine> CompareTwoListMedicineToUpdate(List<Medicine> listMedicineFromHistory, List<Medicine> listMedicines)
        {
            List<Medicine> result = new List<Medicine>();
            foreach (Medicine medicine in listMedicines)
            {
                Medicine medicineFromHistory= listMedicineFromHistory.Where(i => i.Name == medicine.Name).FirstOrDefault();
                if (medicineFromHistory != null)
                {
                    int offset = medicine.Number - medicineFromHistory.Number;
                    Medicine medicineUpdate = new Medicine();
                    medicineUpdate.Name = medicine.Name;
                    medicineUpdate.Id = medicine.Id;
                    medicineUpdate.Number = offset;
                    medicineUpdate.CostOut = medicine.CostOut;
                    result.Add(medicineUpdate);
                }
                else // new
                {
                    Medicine medicineUpdate = new Medicine();
                    medicineUpdate.Name = medicine.Name;
                    medicineUpdate.Id = medicine.Id;
                    medicineUpdate.Number = medicine.Number;
                    medicineUpdate.CostOut = medicine.CostOut;
                    result.Add(medicineUpdate);
                }
            }


            //case: delete row so we must add medicine again
            foreach (Medicine medicine in listMedicineFromHistory)
            {
                Medicine medicineFromNew = listMedicines.Where(i => i.Name == medicine.Name).FirstOrDefault();
                if (medicineFromNew == null)
                {
                    Medicine medicineUpdate = new Medicine();
                    medicineUpdate.Name = medicine.Name;

                    medicineUpdate.Id = medicine.Id;
                    medicineUpdate.Number = 0 - medicine.Number;
                    result.Add(medicineUpdate);
                }
            }

            return result;
        }

        internal static bool ExistMoreThanOneRowOfMedicine(System.Windows.Forms.DataGridView dataGridView)
        {
            List<string> medicines = new List<string>();
            for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
            {
                //dataGridViewMedicinesId
                if (dataGridView.Rows[i].Cells["dataGridViewMedicinesId"].Value == null)
                {
                    return false;
                }
                if(medicines.Contains(dataGridView.Rows[i].Cells["dataGridViewMedicinesId"].Value.ToString()))
                {
                    return true;
                }
                else
                {
                    medicines.Add(dataGridView.Rows[i].Cells["dataGridViewMedicinesId"].Value.ToString());
                }
            }
            return false;
        }
        internal static bool CheckNumberValid(object value)
        {
            //dataGridViewMedicinesId
            if (value == null)
            {
                return false;
            }

            try
            {
                int temp = Int32.Parse(value.ToString());
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        // check value number valid
        internal static bool CheckNumberCellValid(object value)
        {
                //dataGridViewMedicinesId
                if (value == null || value.ToString() == "0")
                {
                    return false;
                }

                try
                {
                    int temp = Int32.Parse(value.ToString());
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
        }

        // check value cell string valid
        internal static bool CheckStringCellValid(object value)
        {
            //dataGridViewMedicinesId
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return false;
            }

            return true;
        }

        internal static bool CheckAllDataCellMedicine(System.Windows.Forms.DataGridView dataGridView)
        {
            for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
            {
                // check name cell
                if (!CheckStringCellValid(dataGridView.Rows[i].Cells["ColumnNameAllMedicine"].Value))
                {
                    System.Windows.Forms.MessageBox.Show("Tên thuốc bạn chưa nhập.", "Thông báo");
                    return false;
                }

                // check count
                if (!CheckNumberCellValid(dataGridView.Rows[i].Cells["Column19"].Value))
                {
                    System.Windows.Forms.MessageBox.Show("Ô số lượng trống.", "Thông báo");
                    return false;
                }

                // check inventory
                if (!CheckStringCellValid(dataGridView.Rows[i].Cells["store"].Value))
                {
                    System.Windows.Forms.MessageBox.Show("Tên thuốc (Dịch vụ) " + dataGridView.Rows[i].Cells["ColumnNameAllMedicine"].Value.ToString() + " không tồn tại.", "Thông báo");
                    return false;
                }

                // check cost out
                if (!CheckNumberCellValid(dataGridView.Rows[i].Cells["ColumnCost"].Value))
                {
                    System.Windows.Forms.MessageBox.Show("Giá không tồn tại", "Thông báo");
                    return false;
                }

                // check money
                if (!CheckNumberCellValid(dataGridView.Rows[i].Cells["ColumnMoneyMedicine"].Value))
                {
                    System.Windows.Forms.MessageBox.Show("Cột Tiên có giá trị không đúng", "Thông báo");
                    return false;
                }
                
            }
            return true;
        }

        internal static void RefreshDoanhThu()
        {
             
        }

        internal static bool SameAddressAndName(IDatabase db, string name, string address)
        {

            string strCommand = "SELECT Name,Address FROM Patient WHERE Name = " + ConvertToSqlString(name) + " and " + "Address = " + ConvertToSqlString(address);
            DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader;
            reader.Read();

            try
            {
                return reader.HasRows;
            }
            finally
            {
                reader.Close();

            }
        }

        /// <summary>
        /// Should be called 1 time when loading the program
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        internal static List<string> GetAllDiagnosesFromHistory(IDatabase db, DateTime date)
        {
            List<string> result = new List<string>();
            string strCommand = BuildStringCommandGettingFieldsFromTableWithoutCondition(ClinicConstant.HistoryTable, new List<string>() { ClinicConstant.HistoryTable_Diagnose }) + " where " + ClinicConstant.HistoryTable_Diagnose + " NOT LIKE '%[H]'" + "and Day < " + Helper.ConvertToSqlString(date.ToString("yyyy-MM-dd"));
            using (DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader)
            {
                while (reader.Read())
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(reader[ClinicConstant.HistoryTable_Diagnose].ToString()) && !result.Contains(reader[ClinicConstant.HistoryTable_Diagnose].ToString()))
                        {
                            result.Add(reader[ClinicConstant.HistoryTable_Diagnose].ToString());
                        }
                    }
                    catch (Exception e)
                    {

                    }
                }
            }
            return result;
        }

        internal static Dictionary<int, string> GetAllDiagnosesFromTableDiagnoses(IDatabase db,List<string>except)
        {
            Dictionary<int, string> result = new Dictionary<int,string>();
            string strCommand = string.Format("select * from {0} where hiden = 0", DatabaseContants.tables.diagnoses);
            using (DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader)
            {
                while (reader.Read())
                {
                    try
                    {
                        if (!except.Contains(reader[1].ToString()))
                        {
                            result.Add(int.Parse(reader[0].ToString()), reader[1].ToString());
                        }
                    }
                    catch (Exception e)
                    {

                    }
                }
            }
            return result;
        }

        private static string BuildStringCommandGettingFieldsFromTableWithoutCondition(string tableName, List<string> fields)
        {
            return "SELECT " + BuildStringFieldsInCommand(fields) + " FROM " + tableName;
        }

        private static string BuildStringFieldsInCommand(List<string> fields)
        {
            if(fields==null|| fields.Count==0)
            {
                return "*";
            }
            string result ="";
            for(int i=0;i<fields.Count-1;i++)
            {
                result+=(fields[i]+',');
            }
            result+=fields[fields.Count-1];
            return result;
        }

        internal static List<string> GetAllLoaiKham(IDatabase iDatabase)
        {
            List<string> result = new List<string>();
            string strCommand = BuildStringCommandGettingFieldsFromTableWithoutCondition(ClinicConstant.LoaiKhamTable, new List<string>() { ClinicConstant.LoaiKhamTable_Nameloaikham });
            using (DbDataReader reader = iDatabase.ExecuteReader(strCommand, null) as DbDataReader)
            {
                while (reader.Read())
                {
                    try
                    {
                        if (!result.Contains(reader[ClinicConstant.LoaiKhamTable_Nameloaikham].ToString()))
                        {
                            result.Add(reader[ClinicConstant.LoaiKhamTable_Nameloaikham].ToString());
                        }
                    }
                    catch (Exception e)
                    {

                    }
                }
            }
            return result;
        }

        internal static string BuildStringServices4SavingToDoanhThu(List<Medicine> Medicines)
        {
            string result = "";
            if (Medicines.Count == 0)
            {
                return result;
            }
            for (int i = 0; i < Medicines.Count-1; i++)
            {
                if (Medicines[i].Name[0] == '@')
                {
                    string name = Medicines[i].Name;
                    result += (name + ClinicConstant.StringBetweenServicesInDoanhThu);
                }

            }
            result += Medicines[Medicines.Count - 1].Name;
            return result;
        }

        internal static string GetIdHistoryFromHistory()
        {
            int result =0;
            string strCommand = "SELECT LAST_INSERT_ID() FROM " + ClinicConstant.HistoryTable_IdHistory;
            using (DbDataReader reader = DatabaseFactory.Instance.ExecuteReader(strCommand, null) as DbDataReader)
            {
                if (reader.HasRows)
                {
                    result = reader.GetInt32(0);
                }

            }
            return result.ToString();
        }

        internal static string GetReasonComeBackFromHistoryByIdHistory(int idHistory, IDatabase iDatabase2)
        {
            string result = "";

            string strCommand = " SELECT " + ClinicConstant.HistoryTable_Reason + " FROM " + ClinicConstant.HistoryTable + " WHERE " + ClinicConstant.HistoryTable_IdHistory + " = " + Helper.ConvertToSqlString(idHistory.ToString());
            using (DbDataReader reader = iDatabase2.ExecuteReader(strCommand, null) as DbDataReader)
            {
                reader.Read();
                if (reader.HasRows)
                {
                    result = reader[ClinicConstant.HistoryTable_Reason].ToString();
                }
            }
            return result;
        }

        internal static int GetStateComeBackFromHistoryByIdPatient(string IdPatient, IDatabase iDatabase2, DateTime time)
        {
            string strCommand = string.Format("Select {0} from history Where Day = ", DatabaseContants.history.IdPatient) + Helper.ConvertToSqlString(time.ToString("yyyy-MM-dd")) + " And " + DatabaseContants.history.IdPatient + "=" + Helper.ConvertToSqlString(IdPatient);
            using (DbDataReader reader = iDatabase2.ExecuteReader(strCommand, null) as DbDataReader)
            {
                reader.Read();
                if (reader.HasRows)
                {
                    return 1;
                }
            }
            return 0;
        }

        public static long SoLuotKhamTrongNgay(IDatabase db,string useName)
        {
            try
            {
                string strCommand = "select count(*) from doanhthu where Namedoctor = " + Helper.ConvertToSqlString(useName) + " and time = " + Helper.ConvertToSqlString(DateTime.Now.ToString("yyyy-MM-dd"));
                return long.Parse(db.ExecuteScalar(strCommand).ToString());
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public static long TongSoLuotKhamTrongNgay(IDatabase db)
        {
            try
            {
                string strCommand = "select count(*) from doanhthu where time = " + Helper.ConvertToSqlString(DateTime.Now.ToString("yyyy-MM-dd"));
                return long.Parse(db.ExecuteScalar(strCommand).ToString());
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public static List<Medicine> ConvertString2MedicineList(string medicines)
        {
            List<Medicine> listMedicine = new List<Medicine>();
            if (!medicines.Contains(','))
            {
                return new List<Medicine>();
            }
            
            
            if (CheckDataMedicineOld(medicines))
            {
                string[] medicinesAndCount = medicines.Split(',');
                if (CheckDataOld(medicinesAndCount))
                {
                    if (medicinesAndCount.Length < 2)
                        return listMedicine;
                    for (int i = 0; i < medicinesAndCount.Length; i = i + 2)
                    {
                        Medicine medicine = new Medicine();
                        medicine.Name = medicinesAndCount[i];
                        medicine.Number = medicine.Count = int.Parse(medicinesAndCount[i + 1]);
                        medicine.CostOut = GetCostOutMedicineByName(medicine.Name, DatabaseFactory.Instance2);
                        medicine.Id = GetIdMedicineFromName(DatabaseFactory.Instance2, medicine.Name);
                        listMedicine.Add(medicine);
                    }
                    return listMedicine;
                }
                else
                {
                    if (medicinesAndCount.Length < 3)
                        return listMedicine;
                    for (int i = 0; i < medicinesAndCount.Length; i = i + 3)
                    {
                        Medicine medicine = new Medicine();
                        medicine.Name = medicinesAndCount[i];
                        medicine.Number = medicine.Count= int.Parse(medicinesAndCount[i + 1]);
                        medicine.CostOut = int.Parse(medicinesAndCount[i + 2]);
                        medicine.Id = GetIdMedicineFromName(DatabaseFactory.Instance2, medicine.Name);
                        listMedicine.Add(medicine);
                    }
                    return listMedicine;
                }
            }
            else
            {
                string[] newProcess = medicines.Split('|');
                for (int i = 0; i < newProcess.Length; i++)
                {
                    string[] parts = newProcess[i].Split(',');
                    if (parts.Length < 4)
                        return listMedicine;
                    Medicine medicine = new Medicine();
                    medicine.Name = parts[0];
                    medicine.Number = Helper.ConvertString2Int(parts[1]);
                    medicine.CostOut = Helper.ConvertString2Int(parts[2]);
                    medicine.Count = Helper.ConvertString2Int(parts[3]);
                    medicine.Id = GetIdMedicineFromName(DatabaseFactory.Instance2, medicine.Name);
                    listMedicine.Add(medicine);
                }
                return listMedicine;
            }
        }

        public static int GetCostOutMedicineByName(string name,IDatabase db)
        {
            string cmd = string.Format("select CostOut from {0} where {1} = {2}", DatabaseContants.tables.medicine, DatabaseContants.medicine.Name, Helper.ConvertToSqlString(name));
            using (DbDataReader reader = db.ExecuteReader(cmd, null) as DbDataReader)
            {
                while (reader.Read())
                {
                    return ConvertString2Int(reader[DatabaseContants.medicine.CostOut]);
                }
            }
            return 0;
        }

        public static string GetNamePatientByID(string id, IDatabase db )
        {
            string strcmd = string.Format("select Name from {0} where {1} = {2}", DatabaseContants.tables.patient, DatabaseContants.patient.Id, id);
            using (DbDataReader reader = db.ExecuteReader(strcmd, null) as DbDataReader)
            {
                while (reader.Read())
                {
                    return reader[0].ToString();
                }
            }
            return string.Empty;
        }

        public static int ConvertString2Int(object a)
        {
            if (a != null)
            {
                try
                {
                    return Int32.Parse(a.ToString());
                }
                catch (Exception e)
                {
                    return 0;
                }
            }
            return 0;
        }

        public static string ConvertObject2String(object a)
        {
            if (a != null)
            {
                return a.ToString();
            }
            return "";
        }

        public static string GetValueColumnOfTable(IDatabase db,string tableName,string columnGet, string columnCheck, string value)
        {
            string strCmp = string.Format("select {0} from {1} where {2} = '{3}' limit 1", columnGet, tableName, columnCheck, value);
            using (DbDataReader reader = db.ExecuteReader(strCmp, null) as DbDataReader)
            {
                if (reader.Read())
                {
                    return reader[0].ToString();
                }
                return "";
            }
        }

        // DiagnosesHistory
        public static bool ExistNameInTableDiagnoses(IDatabase db, string diagnoses)
        {
            string strcmd = string.Format("select {0} from {1} where {2} = '{3}' limit 1", DatabaseContants.Diagnoses.Id, DatabaseContants.tables.diagnoses, DatabaseContants.Diagnoses.diagnoses, diagnoses);
            using (DbDataReader reader = db.ExecuteReader(strcmd, null) as DbDataReader)
            {
                if (reader.HasRows)
                {
                    return true;
                }
                return false;
            }
        }

        internal static bool IsExistsAppointment(IDatabase db,string idbenhnhan, string idHistory, ref string idLichHen)
        {
            string strCmd = string.Format("select {0} from lichhen where {1} = {2} and {3} = {4}", DatabaseContants.LichHen.ID, DatabaseContants.LichHen.Idpatient, idbenhnhan, DatabaseContants.LichHen.IdHistory, idHistory);
            using (DbDataReader reader = db.ExecuteReader(strCmd, null) as DbDataReader)
            {
                if (reader.Read())
                {
                    idLichHen = Helper.ConvertObject2String(reader[DatabaseContants.LichHen.ID]);
                    return true;
                }
                return false;
            }
        }

        internal static Medicine GetMedicineFromName(IDatabase db, string name)
        {
            string id = "";
            string strCommand = "Select * From Medicine Where Name =" + Helper.ConvertToSqlString(name);
            using (DbDataReader reader = db.ExecuteReader(strCommand, null) as DbDataReader)
            {
                reader.Read();
                if (reader.HasRows)
                {
                    Medicine medicine = new Medicine();
                    medicine.Name = Helper.ConvertObject2String(reader[DatabaseContants.medicine.Name]);
                    medicine.CostIn = Helper.ConvertString2Int(reader[DatabaseContants.medicine.CostIn]);
                    medicine.CostOut = Helper.ConvertString2Int(reader[DatabaseContants.medicine.CostOut]);
                    medicine.Count = Helper.ConvertString2Int(reader[DatabaseContants.medicine.Count]);
                    medicine.InputDay = reader.GetDateTime(reader.GetOrdinal(DatabaseContants.medicine.InputDay));
                    medicine.HDSD = Helper.ConvertObject2String(reader[DatabaseContants.medicine.Hdsd]);
                    return medicine;
                }
            }
            return null;
        }
    }
}
