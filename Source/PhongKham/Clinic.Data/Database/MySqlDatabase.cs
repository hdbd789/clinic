﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Clinic.Data.Extensions;
using Clinic.Data.Helpers;
using Clinic.Data.Models;
using MySql.Data.MySqlClient;

namespace Clinic.Data.Database
{
    public class MySqlDatabase : Database<MySqlParameter, MySqlDataReader, MySqlConnection, MySqlTransaction, MySqlDataAdapter, MySqlCommand, MySqlConnectionStringBuilder>
    {
        public MySqlDatabase(string strCon)
            : base(strCon)
        {
        }

        public override DataTable ExecuteReaderAdapter(string StoreProcName, List<IDataParameter> Params)
        {
            MySqlCommand cmd;
            DataTable dtDataTablesList = new DataTable();
            try
            {
                using (cmd = new MySqlCommand(StoreProcName, tConnection))
                {
                    if (Params != null && Params.Count > 0)
                    {
                        foreach (DbParameter param in Params)
                        {
                            cmd.Parameters.Add(param);
                        } 
                    }

                    if (tConnection.State == ConnectionState.Closed)
                    {
                        tConnection.Open();
                    }
                    MySqlDataAdapter adptr = new MySqlDataAdapter(cmd);
                    adptr.FillAsync(dtDataTablesList).GetAwaiter().GetResult();
                    return dtDataTablesList;
                }
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
                if (tConnection != null)
                {
                    tConnection.Close();
                }
            }
        }

        public override bool CheckMedicineExists(string Id)
        {
            string strCommand = string.Format("SELECT Id FROM {0} WHERE Id = {1}", DatabaseContants.tables.medicine, DatabaseHelper.ConvertToSqlString(Id));
            using (DbDataReader reader = ExecuteReader(strCommand, null))
            {
                reader.Read();
                return reader.HasRows;
            }
        }

        public override void DeleteRowFromTablelistpatienttoday(string id, string name)
        {
            string strCommand = string.Format("DELETE FROM {0} WHERE Id = {1} AND Name = {2};",
                DatabaseContants.tables.listpatienttoday, DatabaseHelper.ConvertToSqlString(id), DatabaseHelper.ConvertToSqlString(name));

            //MySqlCommand comm = new MySqlCommand(strCommand, conn);
            ExecuteNonQuery(strCommand, null);
        }

        public override void DeleteRowInTableByID(string nameTable, string nameID, string ID)
        {
            string strCommand = string.Format("DELETE FROM {0} WHERE {1} = {2}", nameTable, nameID, DatabaseHelper.ConvertToSqlString(ID));
            ExecuteNonQuery(strCommand, null);
        }

        public override void DeleteRowToTableCalendar(string nameOfTable, string id, string Username)
        {
            string strCommand = "DELETE FROM " + nameOfTable;

            strCommand += " WHERE IdCalendar='" + id + "' AND Username='" + Username + "';";

            //MySqlCommand comm = new MySqlCommand(strCommand, conn);
            ExecuteNonQuery(strCommand, null);
        }

        public override List<ADate> GetAllDateOfUser(string Username)
        {
            List<ADate> listDate = new List<ADate>();
            string strCommand = string.Format("SELECT * FROM {0} where Username = {1}", DatabaseContants.tables.calendar, DatabaseHelper.ConvertToSqlString(Username));
            using (DbDataReader reader = ExecuteReader(strCommand, null))
            {
                while (reader.Read())
                {
                    listDate.Add(DatabaseHelper.BoxingDate(reader));
                }
            }
            return listDate;
        }

        public override List<string> GetAllDiagnosesFromHistory(DateTime date)
        {
            List<string> result = new List<string>();
            string strCommand = DatabaseHelper.BuildStringCommandGettingFieldsFromTableWithoutCondition(DatabaseContants.tables.history, new List<string>() { DatabaseContants.history.Diagnose }) + " where " + DatabaseContants.history.Diagnose + " NOT LIKE '%[H]'" + "and Day < " + DatabaseHelper.ConvertToSqlString(date.ToString("yyyy-MM-dd"));
            using (DbDataReader reader = ExecuteReader(strCommand, null))
            {
                while (reader.Read())
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(reader[DatabaseContants.history.Diagnose].ToString()) && !result.Contains(reader[DatabaseContants.history.Diagnose].ToString()))
                        {
                            result.Add(reader[DatabaseContants.history.Diagnose].ToString());
                        }
                    }
                    catch
                    {

                    }
                }
            }
            return result;
        }

        public override List<LoaiKham> GetAllLoaiKham()
        {
            List<LoaiKham> results = new List<LoaiKham>();
            string strcmd = string.Format("SELECT * FROM {0}", DatabaseContants.tables.loaikham);
            using (DbDataReader reader = ExecuteReader(strcmd, null))
            {
                while (reader.Read())
                {
                    var loaiKham = new LoaiKham()
                    {
                        Id = reader[0].ToString(),
                        TenLoaiKham = reader[1].ToString()
                    };
                    results.Add(loaiKham);
                }
            }
            return results;
        }

        public override int GetCountFromMecidicByName(string name)
        {
            string strCommand = string.Format("SELECT Sum(Count) FROM {0} where Name = {1}", DatabaseContants.tables.medicine, DatabaseHelper.ConvertToSqlString(name));
            int count = ExecuteScalar(strCommand).ToInt();
            return count;
        }

        public override List<PatientToday> GetListPatientToday()
        {
            List<PatientToday> result = new List<PatientToday>();

            string strCommand = string.Format("SELECT * FROM {0}", DatabaseContants.tables.listpatienttoday);
            using (DbDataReader reader = ExecuteReader(strCommand, null))
            {
                while (reader.Read())
                {
                    PatientToday patientToday = new PatientToday()
                    {
                        IdPatient = reader["Id"].ToString(),
                        NamePatient = reader["name"].ToString(),
                        State = reader["state"].ToString(),
                        Type = Enum.TryParse(reader["Type"]?.ToString(), out RecordType type) ? type : RecordType.Examination
                    };
                    result.Add(patientToday);
                }

            }
            CloseCurrentConnection();
            return result;
        }

        public override List<ReasonApointmentModel> GetListReason()
        {
            List<ReasonApointmentModel> results = new List<ReasonApointmentModel>();
            string strCommand = string.Format("SELECT * FROM {0}", DatabaseContants.tables.reasonapoinment);
            using (DbDataReader reader = ExecuteReader(strCommand, null))
            {
                while (reader.Read())
                {
                    ReasonApointmentModel reason = new ReasonApointmentModel();
                    reason.ID = reader.GetInt32(0);
                    reason.Reason = reader[1].ToString();
                    results.Add(reason);
                }
            }
            return results;
        }

        public override Medicine GetMedicineFromName(string name)
        {
            string strCommand = string.Format("SELECT * FROM {0} Where Name = {1}", DatabaseContants.tables.medicine, DatabaseHelper.ConvertToSqlString(name));
            using (DbDataReader reader = ExecuteReader(strCommand, null))
            {
                reader.Read();
                if (reader.HasRows)
                {
                    Medicine medicine = new Medicine
                    {
                        Name = reader[DatabaseContants.medicine.Name].ToStringOrDefault(),
                        CostIn = reader[DatabaseContants.medicine.CostIn].ToInt(),
                        CostOut = reader[DatabaseContants.medicine.CostOut].ToInt(),
                        Count = reader[DatabaseContants.medicine.Count].ToInt(),
                        InputDay = reader.GetDateTime(reader.GetOrdinal(DatabaseContants.medicine.InputDay)),
                        HDSD = reader[DatabaseContants.medicine.Hdsd].ToStringOrDefault()
                    };
                    return medicine;
                }
            }
            return null;
        }

        public override string GetNameOfDoctor(string name)
        {
            string strCommand = string.Format("SELECT * FROM {0} where Username = {1}", DatabaseContants.tables.clinicuser, DatabaseHelper.ConvertToSqlString(name));
            DbDataReader reader = ExecuteReader(strCommand, null);
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

        public override string GetNamePatientByID(string id)
        {
            string strcmd = string.Format("SELECT Name FROM {0} WHERE {1} = {2}", DatabaseContants.tables.patient, DatabaseContants.patient.Id, id);
            using (DbDataReader reader = ExecuteReader(strcmd, null))
            {
                while (reader.Read())
                {
                    return reader[0].ToString();
                }
            }
            return string.Empty;
        }

        public override string SearchIDHistoryByIDPatientAndDay(string idPatient, string visitDate)
        {
            string strCommand = string.Format("SELECT {0} FROM {1} WHERE Id = {2} AND Day = {3};",
                DatabaseContants.history.IdHistory, DatabaseContants.tables.history,
                DatabaseHelper.ConvertToSqlString(idPatient), DatabaseHelper.ConvertToSqlString(visitDate));
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
                    idHistory = reader[DatabaseContants.history.IdHistory].ToString();
                }
                return idHistory;
            }
            finally
            {
                reader.Close();
            }
        }

        public override void UpdateRowToTable(string nameOfTable, List<string> nameOfColumns, List<string> values, string namecolumn, string id)
        {
            string strCommand = DatabaseHelper.BuildFirstPartUpdateQuery(nameOfTable, nameOfColumns, values);

            strCommand += " WHERE " + namecolumn + " ='" + id + "';";

            //MySqlCommand comm = new MySqlCommand(strCommand, conn);
            ExecuteNonQuery(strCommand, null);
        }

        public override void UpdateRowToTable(string nameOfTable, List<string> nameOfColumns, List<string> values, string nameColumn, string id, string visitDate)
        {
            string strCommand = DatabaseHelper.BuildFirstPartUpdateQuery(nameOfTable, nameOfColumns, values);

            strCommand += " WHERE " + nameColumn + " ='" + id + "' AND Day='" + visitDate + "';";

            //MySqlCommand comm = new MySqlCommand(strCommand, conn);
            ExecuteNonQuery(strCommand, null);
        }

        public override void UpdateRowToTableCalendar(string nameOfTable, List<string> nameOfColumns, List<string> values, string id, string Username)
        {
            string strCommand = DatabaseHelper.BuildFirstPartUpdateQuery(nameOfTable, nameOfColumns, values);

            strCommand += " WHERE IdCalendar='" + id + "' AND Username='" + Username + "';";

            //MySqlCommand comm = new MySqlCommand(strCommand, conn);
            ExecuteNonQuery(strCommand, null);
        }

        public override List<InfoPatient> GetAllPatientInfo(DateTime fromDate, DateTime toDate)
        {
            string strCommand = string.Format("SELECT p.*, h.*, l.benh, l.time, l.status FROM {0} p ", DatabaseContants.tables.patient)
                                + string.Format("LEFT JOIN {0} h ON p.Idpatient = h.Id ", DatabaseContants.tables.history)
                                + string.Format("LEFT JOIN {0} l ON l.IdHistory = h.IdHistory ", DatabaseContants.tables.lichHen)
                                + string.Format("WHERE h.Day >= {0} AND h.Day <= {1}",
                                DatabaseHelper.ConvertToSqlString(fromDate.ToString("yyyy-MM-dd")),
                                DatabaseHelper.ConvertToSqlString(toDate.ToString("yyyy-MM-dd")));

            List<InfoPatient> results = new List<InfoPatient>();
            using (MySqlDataReader reader = ExecuteReader(strCommand, null))
            {
                while (reader.Read())
                {
                    InfoPatient item = new InfoPatient();
                    item.Name = reader[DatabaseContants.patient.Name].ToString();
                    item.Birthday = reader.GetDateTime(reader.GetOrdinal(DatabaseContants.patient.birthday));
                    item.Phone = reader[DatabaseContants.patient.Phone].ToString();
                    item.Address = reader[DatabaseContants.patient.Address].ToString();
                    item.DateWillBirth = DateTime.TryParse(reader[DatabaseContants.patient.DateWillBirthMain].ToString(), out DateTime dateWillBirth) ? dateWillBirth : DateTime.Today;
                    item.Weight = reader[DatabaseContants.history.Weight].ToString();
                    item.Symptom = reader[DatabaseContants.history.Symptom].ToString();
                    item.Temperature = reader[DatabaseContants.history.temperature].ToString();
                    item.HuyenAp = reader[DatabaseContants.history.huyetap].ToString();
                    item.Diagnose = reader[DatabaseContants.history.Diagnose].ToString();
                    item.Medicines = reader[DatabaseContants.history.Medicines].ToString();
                    item.NgayKham = reader.GetDateTime(reader.GetOrdinal(DatabaseContants.history.Day));
                    item.Reason = reader[DatabaseContants.history.Reason].ToString();
                    item.NameOfDoctor = reader[DatabaseContants.history.nameofdoctor].ToString();
                    item.Benh = reader[DatabaseContants.LichHen.sick].ToString();
                    item.NgayTaiKham = DateTime.TryParse(reader[DatabaseContants.LichHen.Time].ToString(), out DateTime taiKham) ? taiKham.ToString(ClinicConstant.DateTimeFormat) : string.Empty;
                    item.Status = reader[DatabaseContants.LichHen.status].ToString();

                    results.Add(item);
                }
            }
            CloseCurrentConnection();
            return results;
        }

        public override List<InfoPatient> LoadDataFromHistory(string query)
        {
            List<InfoPatient> results = new List<InfoPatient>();
            using (MySqlDataReader reader = ExecuteReader(query, null))
            {
                while (reader.Read())
                {
                    InfoPatient item = new InfoPatient();
                    item.Id = reader[DatabaseContants.patient.Id].ToString();
                    item.Name = reader[DatabaseContants.patient.Name].ToString();
                    item.Birthday = reader.GetDateTime(reader.GetOrdinal(DatabaseContants.patient.birthday));
                    item.NgayKham = reader.GetDateTime(reader.GetOrdinal(DatabaseContants.history.Day));
                    item.Address = reader[DatabaseContants.patient.Address].ToString();
                    item.Symptom = reader[DatabaseContants.history.Symptom].ToString();
                    item.Diagnose = reader[DatabaseContants.history.Diagnose].ToString();
                    item.Temperature = reader[DatabaseContants.history.temperature].ToString();
                    item.Weight = reader[DatabaseContants.history.Weight].ToString();
                    item.IdHistory = reader[DatabaseContants.history.IdHistory].ToString();
                    item.Medicines = reader[DatabaseContants.history.Medicines].ToString();
                    item.HuyenAp = reader[DatabaseContants.history.huyetap].ToString();
                    results.Add(item);
                }
            }
            CloseCurrentConnection();
            return results;
        }

        public override List<InfoPatient> LoadDataFromAdvisory(string query)
        {
            List<InfoPatient> results = new List<InfoPatient>();
            using (MySqlDataReader reader = ExecuteReader(query, null))
            {
                while (reader.Read())
                {
                    InfoPatient item = new InfoPatient();
                    item.Id = reader[DatabaseContants.patient.Id].ToString();
                    item.Name = reader[DatabaseContants.patient.Name].ToString();
                    item.Birthday = reader.GetDateTime(reader.GetOrdinal(DatabaseContants.patient.birthday));
                    item.Address = reader[DatabaseContants.patient.Address].ToString();
                    item.Symptom = reader[DatabaseContants.Advisory.Symptom].ToString();
                    item.Diagnose = reader[DatabaseContants.Advisory.Diagnose].ToString();
                    item.Temperature = reader[DatabaseContants.Advisory.Temperature].ToString();
                    item.Weight = reader[DatabaseContants.Advisory.Weight].ToString();
                    item.IdHistory = reader[DatabaseContants.Advisory.Id].ToString();
                    item.Medicines = reader[DatabaseContants.Advisory.Medicines].ToString();
                    item.HuyenAp = reader[DatabaseContants.Advisory.Huyetap].ToString();
                    results.Add(item);
                }
            }
            CloseCurrentConnection();
            return results;
        }
    }
}
