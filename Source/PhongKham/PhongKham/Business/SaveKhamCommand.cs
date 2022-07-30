using Clinic.Database;
using Clinic.Helpers;
using Clinic.Models;
using Clinic.Models.ItemMedicine;
using Clinic.Thong_Ke;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Clinic.Business
{
    public class SaveKhamCommand : ISavePatientCommand
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IDatabase db;
        public string MessageNotifyFinishWithoutAppointment => "Kết thúc phiên khám! và không hẹn";

        public string MessageNotifyFinishWithAppointment => "Kết thúc phiên khám! và hẹn tái khám vào ngày: ";

        public LoadDataType LoadDataType => LoadDataType.OnlyExamination;
        public string ButtonInputText => "Nhập khám";
        public SaveKhamCommand(IDatabase database)
        {
            db = database ?? throw new ArgumentNullException(nameof(database));
        }

        private SaveKhamCommand()
        {
        }

        public void DoAction(InfoPatient infoPatient, 
            bool isAppointment, 
            List<Medicine> listMedicines,
            int tongTien,
            ref string errorMessage)
        {
            bool isPatientExist = Helper.checkPatientExists(db, infoPatient.Id);

            if (!isPatientExist)
            {
                List<string> columns = new List<string>() { DatabaseContants.patient.Name, DatabaseContants.patient.Address, DatabaseContants.patient.birthday, DatabaseContants.patient.height, DatabaseContants.patient.weight, DatabaseContants.patient.Id, DatabaseContants.patient.Phone };
                List<string> values = new List<string>()
                {
                    infoPatient.Name,
                    infoPatient.Address,
                    infoPatient.Birthday.ToString("yyyy-MM-dd"),
                    infoPatient.Height,
                    infoPatient.Weight,
                    infoPatient.Id,
                    infoPatient.Phone
                };
                db.InsertRowToTable(DatabaseContants.tables.patient, columns, values);
            }

            if (listMedicines.Count > 1)
            {
                int sumFollowDatagird = listMedicines.Sum(x => x.Number * x.CostOut);
                if (tongTien != sumFollowDatagird)
                {
                    errorMessage = "Có sự sai soát trong tổng tiền.";
                    return;
                }
            }
            // Delete record tu van of patient
            DeleteAdvisory(infoPatient.Id);
            // Update status appointment of Advisory
            UpdateStatusAppointmentOfAdvisory(infoPatient.Id);

            // id history in danh thu exists.
            string idHistoryOld = string.Empty;
            if (!Helper.checkVisitExists(db, infoPatient.Id, infoPatient.NgayKham.ToString("yyyy-MM-dd"), ref idHistoryOld))
            {
                AddVisitData(listMedicines, infoPatient);

                // not exist
                idHistoryOld = db.SearchIDHistoryByIDPatientAndDay(infoPatient.Id, infoPatient.NgayKham.ToString("yyyy-MM-dd"));
                //save to doanhthu
                List<string> valuesDoanhThu = new List<string>() 
                {
                    infoPatient.NameOfDoctor, 
                    tongTien.ToString(), 
                    DateTime.Now.ToString("yyyy-MM-dd"),
                    infoPatient.Id,
                    infoPatient.Name, 
                    Helper.BuildStringServices4SavingToDoanhThu(listMedicines),
                    infoPatient.LoaiKham, 
                    idHistoryOld 
                };
                db.InsertRowToTable(DatabaseContants.tables.danhthu, Helper.ColumnsDoanhThu, valuesDoanhThu);

                //tru tu thuoc
                Helper.TruTuThuoc(db, listMedicines);
            }
            else
            {
                //sua tu thuoc 
                List<Medicine> listMedicineFromHistory = new List<Medicine>();
                bool isNew = false;
                try
                {
                    listMedicineFromHistory = Helper.GetMedicinesFromHistoryByID(db, idHistoryOld, ref isNew);
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message, ex);
                }

                // list old and new
                List<Medicine> UpdateMedicines = Helper.CompareTwoListMedicineToUpdate(listMedicineFromHistory, listMedicines);

                Helper.TruTuThuoc(db, UpdateMedicines);

                ChangeVisitData(listMedicines, infoPatient);

                //maxValueIdHistoryFromHistory = Helper.SearchMaxValueOfTableWithoutPlusPlus(ClinicConstant.HistoryTable, ClinicConstant.HistoryTable_IdHistory, "DESC").ToString();

                if (isNew)
                {

                    //save to doanhthu
                    List<string> valuesDoanhThu = new List<string>() 
                    { 
                        infoPatient.NameOfDoctor, 
                        tongTien.ToString(), 
                        DateTime.Now.ToString("yyyy-MM-dd"),
                        infoPatient.Id,
                        infoPatient.Name, 
                        Helper.BuildStringServices4SavingToDoanhThu(listMedicines),
                        infoPatient.LoaiKham, 
                        idHistoryOld 
                    };
                    db.InsertRowToTable(DatabaseContants.tables.danhthu, Helper.ColumnsDoanhThu, valuesDoanhThu);
                }
                else
                {
                    //update to doanhthu
                    List<string> columnsDoanhThu = new List<string>() 
                    { 
                        "Namedoctor", 
                        "Money", 
                        "time", 
                        DatabaseContants.danhthu.Services, 
                        DatabaseContants.danhthu.LoaiKham, 
                        DatabaseContants.history.IdHistory 
                    };
                    List<string> valuesDoanhThu = new List<string>() 
                    {
                        infoPatient.NameOfDoctor, 
                        tongTien.ToString(), 
                        DateTime.Now.ToString("yyyy-MM-dd"), 
                        Helper.BuildStringServices4SavingToDoanhThu(listMedicines),
                        infoPatient.LoaiKham, 
                        idHistoryOld 
                    };
                    Helper.UpdateRowToTableDoanhThu(
                        db, 
                        DatabaseContants.tables.danhthu, 
                        columnsDoanhThu, 
                        valuesDoanhThu,
                        infoPatient.Id);
                }
            }
            Helper.UpdateStatusAppointmentHistory(db, infoPatient.Id, idHistoryOld);
            AddToLichHenTable(isAppointment, infoPatient, idHistoryOld);
        }

        public void CreatePDFPrescription(
            InfoPatient infoPatient,
            InfoClinic infoClinic,
            bool isAppointment,
            List<Medicine> listMedicines)
        {
            string strHenTaiKham = "";
            if (isAppointment)
            {
                strHenTaiKham = BuildStringHenTaiKham(infoPatient.NgayTaiKhamDate);
            }

            int STT = Helper.LaySTTTheoNgay(db, DateTime.UtcNow, infoPatient.Id);
            PrintPrescription.CreatePdfVaccination(
                infoClinic,
                infoPatient,
                listMedicines,
                strHenTaiKham,
                STT);
        }

        private void UpdateStatusAppointmentOfAdvisory(string idPatient)
        {
            try
            {
                string query = $"UPDATE {DatabaseContants.tables.lichHen} SET {DatabaseContants.LichHen.status} = {1}"
                               + $" WHERE {DatabaseContants.LichHen.Idpatient} = {idPatient} AND {DatabaseContants.LichHen.IdAdvisory} IS NOT NULL";
                if (db.ExecuteNonQuery(query, null) <= -1)
                {
                    Log.Warn($"Update lịch hẹn thành công.Query: {query}");
                }
            }
            catch (Exception ex)
            {
                Log.Warn(ex.Message, ex);
            }
        }

        private void DeleteAdvisory(string idPatient)
        {
            try
            {
                string query = $"DELETE FROM {DatabaseContants.tables.advisory} WHERE {DatabaseContants.Advisory.IdPatient} = {idPatient}";
                if (db.ExecuteNonQuery(query, null) <= -1)
                {
                    Log.Warn($"Xóa tư vấn không thành công.Query: {query}");
                }
            }
            catch(Exception ex)
            {
                Log.Warn(ex.Message, ex);
            }
        }

        private void AddVisitData(List<Medicine> medicineListInDataGrid, InfoPatient infoPatient)
        {
            //Save to history
            string medicines = GetAndConvertMedicinesToString(medicineListInDataGrid);

            List<string> valuesHistory = new List<string>() 
            {
                infoPatient.Id,
                infoPatient.Symptom,
                infoPatient.Diagnose, 
                DateTime.Now.ToString("yyyy-MM-dd"), 
                medicines,
                infoPatient.Temperature,
                infoPatient.HuyenAp,
                infoPatient.Reason
            };
            db.InsertRowToTable("history", Helper.ColumnsHistory, valuesHistory);

            // add table Diagnoses
            DiagnosesHistory.AddNewDiagnoses(db, infoPatient.Diagnose.Trim());
        }
        private string GetAndConvertMedicinesToString(List<Medicine> listMedicine, bool updateCount = false)
        {
            string medicines = "";
            for (int i = 0; i < listMedicine.Count; i++)
            {
                Medicine medicine = listMedicine[i];
                if (updateCount)
                {
                    medicine.Count = db.GetCountFromMecidicByName(medicine.Name);
                }
                int countStore = medicine.Count - medicine.Number;
                if (i == listMedicine.Count - 1)
                {
                    medicines += medicine.Name + "," + medicine.Number + "," + medicine.CostOut + "," + countStore;
                }
                else
                {
                    medicines += medicine.Name + "," + medicine.Number + "," + medicine.CostOut + "," + countStore + "|";
                }
            }
            //// nam,count, cose out, store count
            //for (int i = 0; i < dataGridViewMedicine.Rows.Count - 1; i++)
            //{
            //    int countStore = Helper.ConvertString2Int(dataGridViewMedicine[2, i].Value) - Helper.ConvertString2Int(dataGridViewMedicine[1, i].Value);

            //    if (i == dataGridViewMedicine.Rows.Count - 2)
            //    {
            //        medicines += dataGridViewMedicine[0, i].Value + "," + dataGridViewMedicine[1, i].Value + "," + dataGridViewMedicine[3, i].Value + "," + countStore;
            //    }
            //    else
            //    {
            //        medicines += dataGridViewMedicine[0, i].Value + "," + dataGridViewMedicine[1, i].Value + "," + dataGridViewMedicine[3, i].Value + "," + countStore + "|";
            //    }
            //}
            return medicines;
        }

        private void ChangeVisitData(List<Medicine> medicineListInDataGrid, InfoPatient infoPatient)
        {
            List<string> columns = new List<string>() 
            { 
                DatabaseContants.patient.Name, 
                DatabaseContants.patient.Address, 
                DatabaseContants.patient.birthday, 
                DatabaseContants.patient.height, 
                DatabaseContants.patient.weight,
                DatabaseContants.patient.Phone
            };
            List<string> values = new List<string>() 
            {
                infoPatient.Name,
                infoPatient.Address,
                infoPatient.Birthday.ToString("yyyy-MM-dd"),
                infoPatient.Height,
                infoPatient.Weight,
                infoPatient.Phone
            };
            db.UpdateRowToTable(DatabaseContants.tables.patient, columns, values, DatabaseContants.patient.Id, infoPatient.Id);

            //Save to history

            string medicines = GetAndConvertMedicinesToString(medicineListInDataGrid, true);

            List<string> valuesHistory = new List<string>() 
            {
                infoPatient.Id,
                infoPatient.Symptom,
                infoPatient.Diagnose,
                infoPatient.NgayKham.ToString("yyyy-MM-dd"), 
                medicines,
                infoPatient.Temperature,
                infoPatient.HuyenAp,
                infoPatient.Reason
            };
            db.UpdateRowToTable(DatabaseContants.tables.history, 
                Helper.ColumnsHistory, 
                valuesHistory, 
                DatabaseContants.history.IdPatient,
                infoPatient.Id,
                infoPatient.NgayKham.ToString("yyyy-MM-dd"));

            // add table Diagnoses
            DiagnosesHistory.AddNewDiagnoses(db, infoPatient.Diagnose.Trim());
        }

        private void AddToLichHenTable(bool isAppointment, InfoPatient infoPatient, string idHistory)
        {
            if (isAppointment)
            {
                string IDLichHen = "";
                if (Helper.IsExistsAppointmentHistory(db, infoPatient.Id, idHistory, ref IDLichHen)) // update
                {
                    List<string> columnslichhen = new List<string>() { "Idpatient", "Namedoctor", "Namepatient", "time", "phone", "benh", DatabaseContants.history.IdHistory, DatabaseContants.LichHen.status };
                    List<string> valueslichhen = new List<string>() 
                    {
                        infoPatient.Id,
                        infoPatient.NameOfDoctor,
                        infoPatient.Name,
                        infoPatient.NgayTaiKhamDate.ToString("yyyy-MM-dd"),
                        infoPatient.Phone,
                        infoPatient.Diagnose, 
                        idHistory, 
                        "0" 
                    };
                    db.UpdateRowToTable(DatabaseContants.tables.lichHen, columnslichhen, valueslichhen, DatabaseContants.LichHen.ID, IDLichHen);
                }
                else // add new
                {
                    List<string> columnslichhen = new List<string>() { "Idpatient", "Namedoctor", "Namepatient", "time", "phone", "benh", DatabaseContants.history.IdHistory, DatabaseContants.LichHen.status };
                    List<string> valueslichhen = new List<string>() 
                    {
                        infoPatient.Id,
                        infoPatient.NameOfDoctor,
                        infoPatient.Name,
                        infoPatient.NgayTaiKhamDate.ToString("yyyy-MM-dd"),
                        infoPatient.Phone,
                        infoPatient.Diagnose,
                        idHistory, 
                        "0" 
                    };
                    db.InsertRowToTable(DatabaseContants.tables.lichHen, columnslichhen, valueslichhen);
                }
            }
        }

        private string BuildStringHenTaiKham(DateTime ngayHen)
        {
            return $"Mời tái khám vào ngày: {ngayHen.ToString(ClinicConstant.DateTimeFormat)}";
        }
    }
}
