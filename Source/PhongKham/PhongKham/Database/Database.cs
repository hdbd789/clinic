using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using Clinic.Helpers;
using log4net;
using System.Reflection;
using Clinic.Models;
using Clinic.Models.ItemMedicine;

namespace Clinic.Database
{
    public abstract class Database<TParameter, TDataReader, TConnection,
       TTransaction, TDataAdapter, TCommand, TDbConnectionStringBuilder> : IDatabase
        where TParameter : DbParameter, IDataParameter
        where TDataReader : DbDataReader, IDataReader
        where TConnection : DbConnection, IDbConnection, new()
        where TTransaction : DbTransaction, IDbTransaction
        where TDataAdapter : DbDataAdapter, IDataAdapter, new()
        where TCommand : DbCommand, IDbCommand, new()
        where TDbConnectionStringBuilder : DbConnectionStringBuilder
    {
        protected static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        protected TConnection tConnection;
        public Database(string strCon)
        {
            tConnection = new TConnection
            {
                ConnectionString = strCon
            };
        }

        protected int ExecuteNonQuery(string StoreProcName, List<TParameter> Params)
        {
            Log.Info("StoreProcName : " + StoreProcName);
            bool internalOpen = false;
            TCommand cmd;
            DbTransaction tTransaction = null;
            try
            {
                cmd = new TCommand
                {
                    //cmd.CommandType = CommandType.StoredProcedure;
                    CommandText = StoreProcName,
                    Connection = tConnection
                };

                if (Params != null && Params.Count > 0)
                {
                    foreach (DbParameter param in Params)
                        cmd.Parameters.Add(param);
                }

                if (tConnection.State == ConnectionState.Closed)
                {
                    tConnection.Open();
                    internalOpen = true;
                }
                tTransaction = tConnection.BeginTransaction();
                int result = cmd.ExecuteNonQuery();
                tTransaction.Commit();
                return result;
            }
            catch (DbException DbEx)
            {
                tTransaction.Rollback();
                Log.Error(DbEx.Message, DbEx);
                throw DbEx;
            }
            catch (Exception ex)
            {
                tTransaction.Rollback();
                Log.Error(ex.Message, ex);
                throw ex;
            }
            finally
            {
                if (internalOpen)
                    tConnection.Close();
            }
        }

        protected  TDataReader ExecuteReader(string StoreProcName, List<TParameter> Params)
        {
            TCommand cmd;
            try
            {

                cmd = new TCommand
                {
                    // cmd.CommandType = CommandType.StoredProcedure;
                    CommandText = StoreProcName,
                    Connection = tConnection
                };

                if (Params != null && Params.Count > 0)
                {
                    foreach (DbParameter param in Params)
                        cmd.Parameters.Add(param);
                }

                if (tConnection.State == ConnectionState.Closed)
                {
                    tConnection.Open();
                }

                return (TDataReader)cmd.ExecuteReader();

            }
            catch (DbException DbEx)
            {
                System.Windows.Forms.MessageBox.Show("Đọc database thất bại, xin xem lại kết nối database", "Thông báo");
                Log.Error(DbEx.Message, DbEx);
                throw DbEx;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                throw ex;
            }
        }

        public abstract DataTable ExecuteReaderAdapter(string StoreProcName, List<IDataParameter> Params);

        protected void CreateDatabase(string password)
        {
            try
            {
                if (!Setting.SslModeDatabase)
                {
                    string strCommand = "grant all privileges on *.* to 'root'@'%' identified by " + Helper.ConvertToSqlString(password);
                    ExecuteNonQuery(strCommand, null);
                }
                ExecuteNonQuery("CREATE DATABASE IF NOT EXISTS clinic DEFAULT CHARACTER SET utf8 COLLATE utf8_unicode_ci;", null);
                tConnection.ConnectionString += ";database=clinic;";
                tConnection.ConnectionString += ";password=" + password;
                ExecuteNonQuery("CREATE Table IF NOT EXISTS clinicuser(Username varchar(50),Password1  varchar(50),Authority  smallint(6), Password2  varchar(50));", null);

                ExecuteNonQuery("CREATE Table IF NOT EXISTS history(Id varchar(10),Symptom Longtext,Diagnose Longtext,Medicines Longtext,Day Datetime) CHARACTER SET utf8 COLLATE utf8_unicode_ci;", null);

                ExecuteNonQuery("CREATE Table IF NOT EXISTS medicine(Name varchar(50),Count int,CostIn int,CostOut int,InputDay Datetime,Id varchar(10)) CHARACTER SET utf8 COLLATE utf8_unicode_ci;", null);

                ExecuteNonQuery("CREATE Table IF NOT EXISTS patient(Idpatient INT NOT NULL AUTO_INCREMENT,Name varchar(50),Address Varchar(400),birthday datetime,height int(11),weight int(11),PRIMARY KEY (Idpatient)) CHARACTER SET utf8 COLLATE utf8_unicode_ci;", null);

                ExecuteNonQuery("CREATE Table IF NOT EXISTS calendar(IdCalendar INT NOT NULL,Username varchar(50),StartTime datetime,EndTime datetime,Text Longtext,Color int, PRIMARY KEY (IdCalendar)) CHARACTER SET utf8 COLLATE utf8_unicode_ci;", null);

                ExecuteNonQuery("CREATE Table IF NOT EXISTS listpatienttoday(Id varchar(10) NOT NULL,Name TEXT NULL,State VARCHAR(45) NULL, PRIMARY KEY (Id)) CHARACTER SET utf8 COLLATE utf8_unicode_ci;", null);

                ExecuteNonQuery("CREATE Table IF NOT EXISTS doanhthu(Iddoanhthu INT NOT NULL AUTO_INCREMENT,Namedoctor TEXT NULL,Money int NULL,time datetime, PRIMARY KEY (Iddoanhthu)) CHARACTER SET utf8 COLLATE utf8_unicode_ci;", null);

                ExecuteNonQuery("CREATE Table IF NOT EXISTS lichhen(Idlichhen INT NOT NULL AUTO_INCREMENT,Idpatient int,Namedoctor TEXT NULL,Namepatient TEXT NULL,time datetime,benh TEXT NULL,phone VARCHAR(45), PRIMARY KEY (Idlichhen)) CHARACTER SET utf8 COLLATE utf8_unicode_ci;", null);

                ExecuteNonQuery("CREATE Table IF NOT EXISTS loaikham(Idloaikham INT NOT NULL AUTO_INCREMENT,Nameloaikham TEXT NOT NULL, PRIMARY KEY (Idloaikham)) CHARACTER SET utf8 COLLATE utf8_unicode_ci;", null);

                ExecuteNonQuery("CREATE Table IF NOT EXISTS lichsunhapthuoc(Idhistory INT NOT NULL AUTO_INCREMENT,idMedicine varchar(10) NOT NULL, Count INT, CostIn int, CostOut int, InputDay Datetime , PRIMARY KEY (Idhistory)) CHARACTER SET utf8 COLLATE utf8_unicode_ci;", null);

                ExecuteNonQuery("CREATE Table IF NOT EXISTS ReasonApoinment(ID INT NOT NULL AUTO_INCREMENT,reason TEXT NOT NULL, PRIMARY KEY (ID)) CHARACTER SET utf8 COLLATE utf8_unicode_ci;", null);

                ExecuteNonQuery("CREATE Table IF NOT EXISTS Diagnoses(ID INT NOT NULL AUTO_INCREMENT,diagnoses TEXT NOT NULL,hiden TINYINT(1), PRIMARY KEY (ID)) CHARACTER SET utf8 COLLATE utf8_unicode_ci;", null);

                if (Setting.UpdateDatabase)
                {
                    UpdateDatabase();
                }
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e);
                throw e;
            }
        }

        private void Guard(Func<int> action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e);
                throw e;
            }
        }


        private void UpdateDatabase()
        {
            Func<int> fun = () => ExecuteNonQuery("ALTER TABLE medicine CHARACTER SET = utf16 , COLLATE = utf16_unicode_ci", null);
            fun=()=> ExecuteNonQuery("ALTER TABLE clinicuser ADD PRIMARY KEY(Username);", null);
            Guard(fun);;

            fun = () => ExecuteNonQuery("ALTER TABLE medicine ADD COLUMN Hdsd TEXT NULL AFTER Id", null);
            Guard(fun);

            fun = () => ExecuteNonQuery("ALTER TABLE listpatienttoday ADD COLUMN time datetime NULL AFTER Id", null);
            Guard(fun);

            fun = () => ExecuteNonQuery("ALTER TABLE patient ADD COLUMN phone VARCHAR(45) NULL AFTER Name;", null);
            Guard(fun);

            fun = () => ExecuteNonQuery(" ALTER TABLE patient CHANGE COLUMN height height TEXT NULL DEFAULT NULL , CHANGE COLUMN weight weight TEXT NULL DEFAULT NULL ;", null);
            Guard(fun);

            fun = () => ExecuteNonQuery("ALTER TABLE clinicuser ADD COLUMN namedoctor TEXT NULL AFTER Password2;", null);
            Guard(fun);

            fun = () => ExecuteNonQuery("ALTER TABLE history ADD COLUMN temperature TEXT NULL AFTER Symptom;", null);
            Guard(fun);

            fun = () => ExecuteNonQuery("ALTER TABLE history ADD COLUMN huyetap TEXT NULL AFTER temperature;", null);
            Guard(fun);

            fun = () => ExecuteNonQuery("CREATE event delete on schedule every 1 day starts at timestamp '2007-03-25 23:59:00' do delete from listpatienttoday", null);
            Guard(fun);

            fun = () => ExecuteNonQuery("ALTER TABLE doanhthu  ADD COLUMN Idpatient varchar(10) NULL , ADD COLUMN Namepatient TEXT NULL;", null);
            Guard(fun);

            fun = () => ExecuteNonQuery("ALTER TABLE medicine ADD COLUMN "+ DatabaseContants.medicine.Admin +" TEXT NULL", null);
            Guard(fun);

            fun = () => ExecuteNonQuery("ALTER TABLE doanhthu  ADD COLUMN " + DatabaseContants.danhthu.Services + " TEXT NULL;", null);
            Guard(fun);


            fun = () => ExecuteNonQuery("ALTER TABLE doanhthu  ADD COLUMN " + DatabaseContants.danhthu.LoaiKham + " TEXT NULL;", null);
            Guard(fun);


            fun = () => ExecuteNonQuery("ALTER TABLE history  ADD COLUMN " + DatabaseContants.history.IdHistory + " INT NOT NULL AUTO_INCREMENT ,ADD PRIMARY KEY (`IdHistory`) ;", null);
            Guard(fun);

            fun = () => ExecuteNonQuery("ALTER TABLE doanhthu  ADD COLUMN " + DatabaseContants.history.IdHistory + " INT NULL ;", null);
            Guard(fun);

            fun = () => ExecuteNonQuery("ALTER TABLE history  ADD COLUMN " + DatabaseContants.history.Reason + " TEXT NULL ;", null);
            Guard(fun);

            fun = () => ExecuteNonQuery("ALTER TABLE lichhen  ADD COLUMN " + DatabaseContants.LichHen.IdHistory + " INT NULL ;", null);
            Guard(fun);

            fun = () => ExecuteNonQuery("ALTER TABLE lichhen  ADD COLUMN " + DatabaseContants.LichHen.status + " INT NULL ;", null);
            Guard(fun);

            fun = () => ExecuteNonQuery("ALTER TABLE lichsunhapthuoc  ADD COLUMN " + DatabaseContants.lichsunhapthuoc.CountStore + " INT NULL ;", null);
            Guard(fun);

        }

        #region implement Interface IDatabase

        IDataReader IDatabase.ExecuteReader(string StoreProcName, List<IDataParameter> Params)
        {
            return ExecuteReader(StoreProcName, Params as List<TParameter>);
        }


         void IDatabase.CreateDatabase(string password)
        {
            CreateDatabase(password);
        }


        public int InsertRowToTable(string nameOfTable, List<string> nameOfColumns, List<string> values)
        {
            if (nameOfColumns.Count != values.Count)
            {
                throw new Exception("số cột và số giá trị khác nhau");
            }
            for (int i = 0; i < values.Count; i++)
            {
                values[i] =Helper.ConvertToSqlString(values[i]);
            }

            string columns = "Insert Into " + nameOfTable + " (";
            foreach (string name in nameOfColumns)
            {
                columns += name + ",";
            }
            columns = columns.Remove(columns.Length - 1);
            columns += ")";
            string vals = " VALUES (";
            foreach (string value in values)
            {
                vals += value + ",";
            }
            vals = vals.Remove(vals.Length - 1);
            vals += ")";

            string strCommand = columns + vals;
            return ExecuteNonQuery(strCommand, null);
        }


         int IDatabase.ExecuteNonQuery(string StoreProcName, List<IDataParameter> Params)
        {
            return ExecuteNonQuery(StoreProcName, Params as List<TParameter>);
        }
        #endregion


         public void CloseCurrentConnection()
         {
            if(tConnection != null)
            {
                tConnection.Close();
            }
         }


         public object ExecuteScalar(string query)
         {
             TCommand cmd;
             try
             {

                cmd = new TCommand
                {
                    // cmd.CommandType = CommandType.StoredProcedure;
                    CommandText = query,
                    Connection = tConnection
                };

                if (tConnection.State == ConnectionState.Closed)
                 {
                     tConnection.Open();
                 }

                 return cmd.ExecuteScalar();

             }
             catch (DbException DbEx)
             {
                Log.Error(DbEx.Message, DbEx);
                throw DbEx;
             }
             catch (Exception ex)
             {
                Log.Error(ex.Message, ex);
                throw ex;
             }
             finally
             {
                 // reader need connection still open for read() , and note : close connection

                 //if (internalOpen)
                 //    tConnection.Close();
             }
         }

        public abstract List<LoaiKham> GetAllLoaiKham();
        public abstract List<ReasonApointmentModel> GetListReason();
        public abstract void DeleteRowInTableByID(string nameTable, string nameID, string ID);
        public abstract void UpdateRowToTable(string nameOfTable, List<string> nameOfColumns, List<string> values, string namecolumn, string id);
        public abstract void UpdateRowToTable(string nameOfTable, List<string> nameOfColumns, List<string> values, string nameColumn, string id, string visitDate);
        public abstract void UpdateRowToTableCalendar(string nameOfTable, List<string> nameOfColumns, List<string> values, string id, string Username);
        public abstract void DeleteRowToTableCalendar(string nameOfTable, string id, string Username);
        public abstract void DeleteRowFromTablelistpatienttoday(string id, string name);
        public abstract List<ADate> GetAllDateOfUser(string Username);
        public abstract int GetCountFromMecidicByName(string name);
        public abstract string SearchIDHistoryByIDPatientAndDay(string idPatient, string visitDate);
        public abstract bool CheckMedicineExists(string Id);
        public abstract string GetNameOfDoctor(string name);
        public abstract Dictionary<string, string> GetListPatientToday();
        public abstract List<string> GetAllDiagnosesFromHistory(DateTime date);
        public abstract string GetNamePatientByID(string id);
        public abstract Medicine GetMedicineFromName(string name);
        public abstract List<InfoPatient> GetAllPatientInfo(DateTime fromDate, DateTime toDate);
    }
}
