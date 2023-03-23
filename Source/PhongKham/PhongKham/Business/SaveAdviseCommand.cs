using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Clinic.Data.Database;
using Clinic.Data.Models;
using Clinic.Helpers;
using Clinic.Models;
using Clinic.Thong_Ke;
using log4net;

namespace Clinic.Business
{
    public class SaveAdviseCommand : ISavePatientCommand
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IDatabase db;

        public string MessageNotifyFinishWithoutAppointment => "Kết thúc phiên tư vấn! và không hẹn";

        public string MessageNotifyFinishWithAppointment => "Kết thúc phiên tư vấn! và hẹn khám vào ngày: ";

        public LoadDataType LoadDataType => LoadDataType.OnlyAdvisory;

        public string ButtonInputText => "Nhập tư vấn";

        public SaveAdviseCommand(IDatabase database)
        {
            db = database ?? throw new ArgumentNullException(nameof(database));
        }

        private SaveAdviseCommand()
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
                List<string> columns = new List<string>() 
                { 
                    DatabaseContants.patient.Name, 
                    DatabaseContants.patient.Address, 
                    DatabaseContants.patient.birthday,
                    DatabaseContants.patient.Id, 
                    DatabaseContants.patient.Phone,
                    DatabaseContants.patient.DateWillBirthMain
                };
                List<string> values = new List<string>()
                {
                    infoPatient.Name,
                    infoPatient.Address,
                    infoPatient.Birthday.ToString(ClinicConstant.DateTimeSQLFormat),
                    infoPatient.Id,
                    infoPatient.Phone,
                    infoPatient.DateWillBirth.ToString(ClinicConstant.DateTimeSQLFormat)
                };
                db.InsertRowToTable(DatabaseContants.tables.patient, columns, values);
            }
            else
            {
                Helper.UpdateInfoPatient(db, infoPatient);
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
            if (!Helper.IsAdvisoryExists(db, infoPatient.IdHistory))
            {
                AddVisitData(listMedicines, infoPatient);
            }
            else
            {
                ChangeVisitData(listMedicines, infoPatient);
            }
            AddToLichHenTable(isAppointment, infoPatient);
            AddToAdvisoryHistory(infoPatient);
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

            PrintPrescription.CreateAPdfAdvisory(
                infoClinic,
                infoPatient,
                listMedicines,
                strHenTaiKham,
                STT);
        }

        private void AddToAdvisoryHistory(InfoPatient infoPatient)
        {
            if (Helper.IsAdvisoryHistoryExists(db, infoPatient.Id, infoPatient.NgayKham.ToString("yyyy-MM-dd"), out string idAdvisoryHistory))
            {
                List<string> columnsAdvisoryHistory = new List<string>()
                {
                    "IdPatient",
                    DatabaseContants.AdvisoryHistory.Day,
                    DatabaseContants.Advisory.nameofdoctor
                };
                List<string> valuesAdvisoryHistory = new List<string>()
                {
                    infoPatient.Id,
                    infoPatient.NgayKham.ToString("yyyy-MM-dd"),
                    infoPatient.NameOfDoctor
                };
                db.UpdateRowToTable(DatabaseContants.tables.AdvisoryHistory,
                    columnsAdvisoryHistory,
                    valuesAdvisoryHistory,
                    DatabaseContants.AdvisoryHistory.Id,
                    idAdvisoryHistory);
            }
            else
            {
                List<string> columnsAdvisoryHistory = new List<string>()
                {
                    "IdPatient",
                    DatabaseContants.AdvisoryHistory.Day,
                    DatabaseContants.Advisory.nameofdoctor
                };
                List<string> valuesAdvisoryHistory = new List<string>()
                {
                    infoPatient.Id,
                    infoPatient.NgayKham.ToString("yyyy-MM-dd"),
                    infoPatient.NameOfDoctor
                };
                db.InsertRowToTable(DatabaseContants.tables.AdvisoryHistory, columnsAdvisoryHistory, valuesAdvisoryHistory);
            }
        }

        private void AddVisitData(List<Medicine> medicineListInDataGrid, InfoPatient infoPatient)
        {
            //Save to history
            string medicines = GetAndConvertMedicinesToString(medicineListInDataGrid);

            List<string> ColumnsAdvisory = new List<string>() 
            {
                "IdPatient", 
                "Symptom", 
                "Diagnose", 
                "Day", 
                "Medicines", 
                "temperature", 
                "huyetap", 
                DatabaseContants.Advisory.Reason,
                DatabaseContants.Advisory.nameofdoctor,
                DatabaseContants.Advisory.DateWillBirth,
                DatabaseContants.Advisory.Weight
            };
            List<string> valuesHistory = new List<string>()
            {
                infoPatient.Id,
                infoPatient.Symptom,
                infoPatient.Diagnose,
                DateTime.Now.ToString(ClinicConstant.DateTimeSQLFormat),
                medicines,
                infoPatient.Temperature,
                infoPatient.HuyenAp,
                infoPatient.Reason,
                infoPatient.NameOfDoctor,
                infoPatient.DateWillBirth.ToString(ClinicConstant.DateTimeSQLFormat),
                infoPatient.Weight
            };
            db.InsertRowToTable(DatabaseContants.tables.advisory, ColumnsAdvisory, valuesHistory);

            // add table Diagnoses
            DiagnosesHistory.AddNewDiagnoses(db, infoPatient.Diagnose.Trim());
        }

        private void ChangeVisitData(List<Medicine> medicineListInDataGrid, InfoPatient infoPatient)
        {
            List<string> columns = new List<string>() 
            { 
                DatabaseContants.patient.Name, 
                DatabaseContants.patient.Address, 
                DatabaseContants.patient.birthday,
                DatabaseContants.patient.Phone,
                DatabaseContants.patient.DateWillBirthMain
            };
            List<string> values = new List<string>()
            {
                infoPatient.Name,
                infoPatient.Address,
                infoPatient.Birthday.ToString(ClinicConstant.DateTimeSQLFormat),
                infoPatient.Phone,
                infoPatient.DateWillBirth.ToString(ClinicConstant.DateTimeSQLFormat)
            };
            db.UpdateRowToTable(DatabaseContants.tables.patient, columns, values, DatabaseContants.patient.Id, infoPatient.Id);

            //Save to history

            string medicines = GetAndConvertMedicinesToString(medicineListInDataGrid, true);

            List<string> ColumnsAdvisory = new List<string>()
            {
                "IdPatient",
                "Symptom",
                "Diagnose",
                "Day",
                "Medicines",
                "temperature",
                "huyetap",
                DatabaseContants.history.Reason,
                DatabaseContants.Advisory.nameofdoctor,
                DatabaseContants.Advisory.DateWillBirth,
                DatabaseContants.Advisory.Weight
            };
            List<string> valuesHistory = new List<string>()
            {
                infoPatient.Id,
                infoPatient.Symptom,
                infoPatient.Diagnose,
                infoPatient.NgayKham.ToString(ClinicConstant.DateTimeSQLFormat),
                medicines,
                infoPatient.Temperature,
                infoPatient.HuyenAp,
                infoPatient.Reason,
                infoPatient.NameOfDoctor,
                infoPatient.DateWillBirth.ToString(ClinicConstant.DateTimeSQLFormat),
                infoPatient.Weight
            };
            db.UpdateRowToTable(DatabaseContants.tables.advisory,
                ColumnsAdvisory,
                valuesHistory,
                DatabaseContants.Advisory.Id,
                infoPatient.IdHistory);

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
        private void AddToLichHenTable(bool isAppointment, InfoPatient infoPatient)
        {
            if (isAppointment)
            {
                string IDLichHen = "";
                if (Helper.IsExistsAppointmentAdvisory(db, infoPatient.Id, infoPatient.IdHistory, ref IDLichHen)) // update
                {
                    List<string> columnslichhen = new List<string>() 
                    { 
                        "Idpatient", 
                        "Namedoctor", 
                        "Namepatient", 
                        "time", 
                        "phone", 
                        "benh", 
                        DatabaseContants.LichHen.IdAdvisory, 
                        DatabaseContants.LichHen.status,
                        DatabaseContants.LichHen.DateWillBirth
                    };
                    List<string> valueslichhen = new List<string>()
                    {
                        infoPatient.Id,
                        infoPatient.NameOfDoctor,
                        infoPatient.Name,
                        infoPatient.NgayTaiKhamDate.ToString(ClinicConstant.DateTimeSQLFormat),
                        infoPatient.Phone,
                        infoPatient.Diagnose,
                        infoPatient.IdHistory,
                        "0",
                        infoPatient.DateWillBirth.ToString(ClinicConstant.DateTimeSQLFormat)
                    };
                    db.UpdateRowToTable(DatabaseContants.tables.lichHen, columnslichhen, valueslichhen, DatabaseContants.LichHen.ID, IDLichHen);
                }
                else // add new
                {
                    List<string> columnslichhen = new List<string>() { "Idpatient", "Namedoctor", "Namepatient", "time", "phone", "benh", DatabaseContants.LichHen.IdAdvisory, DatabaseContants.LichHen.status, DatabaseContants.LichHen.DateWillBirth };
                    List<string> valueslichhen = new List<string>()
                    {
                        infoPatient.Id,
                        infoPatient.NameOfDoctor,
                        infoPatient.Name,
                        infoPatient.NgayTaiKhamDate.ToString("yyyy-MM-dd"),
                        infoPatient.Phone,
                        infoPatient.Diagnose,
                        infoPatient.IdHistory,
                        "0",
                        infoPatient.DateWillBirth.ToString(ClinicConstant.DateTimeSQLFormat)
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
