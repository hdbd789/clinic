using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinic.Database
{
    public class DatabaseContants
    {
        public static int IdColumnInDataGridViewMedicines = 5;
        public static int NameColumnInDataGridViewMedicines = 0;
        public static int HDSDColumnInDataGridViewMedicines = 6;
        public static int CountColumnInDataGridViewMedicines = 1;
        public static int CostColumnInDataGridViewMedicines = 3;
        public static int MoneyColumnInDataGridViewMedicines = 4;
        public static int StoreColumnInDataGridViewMedicines = 2;

        public static   List<string> columnsCalendar = new List<string>() { "IdCalendar", "Username", "StartTime", "EndTime", "Text", "Color" };

        public struct clinicuser
        {
            public static string  Username = "Username";
            public static string  Password1 = "Password1";
            public static string  Authority = "Authority";
            public static string Password2 = "Password2";
            public static string Namedoctor = "namedoctor";
        }
        public struct history
        {
            public static string  Id = "Id";
            public static string  Symptom = "Symptom";
            public static string temperature = "temperature";
            public static string huyetap = "huyetap";
            public static string  Diagnose = "Diagnose";
            public static string  Medicines = "Medicines";
            public static string  Day = "Day";
            public static string IdPatient = "Id";
            public static string nameofdoctor = "NameDoctor";
            public static string namLoaiKham = "NameLoaiKham";
            public static string IdHistory = "IdHistory";
            public static string Reason = "Reason";
        }

        public struct medicine
        {
            public static string Name = "Name";
            public static string Count = "Count";
            public static string CostIn = "CostIn";
            public static string CostOut = "CostOut";
            public static string InputDay = "InputDay";
            public static string Id = "Id";
            public static string Hdsd = "Hdsd";
            public static string Admin = "Admin";
        }
        public struct patient
        {
           public static string Name = "Name";
           public static string Address = "Address";
           public static string birthday = "birthday";
           public static string height = "height";
           public static string weight = "weight";
           public static string Id = "Idpatient";
            public static string Phone = "phone";
        }

        public struct danhthu
        {
            public static string Id = "Iddoanhthu";
            public static string IdPatient = "Idpatient";
            public static string time = "time";
            public static string NameDoctor = "Namedoctor";
            public static string IdHistory = "IdHistory";
            public static string Money = "Money";
            public static string Services = "Services";
            public static string LoaiKham = "LoaiKham";
            public static string NamePatient = "NamePatient";
        }

        public struct lichsunhapthuoc
        {
            public static string CountStore = "CountStore";
            public static string idMedicine = "idMedicine";
            public static string InputDay = "InputDay";
        }

        public struct Diagnoses
        {
            public static string Id = "ID";
            public static string diagnoses = "diagnoses";
            public static string Hiden = "hiden";
        }

        public struct LichHen
        {
            public static string ID = "Idlichhen";
            public static string status = "status";
            public static string Time = "time";
            public static string Idpatient = "Idpatient";
            public static string IdHistory = "IdHistory";
            public static string phone = "phone";
            public static string sick = "benh";
            public static string Namepatient = "Namepatient";
            public static string Namedoctor = "Namedoctor";
            public static string IdAdvisory = "IdAdvisory";
        }

        public struct LoaiKham
        {
            public static string Idloaikham = "Idloaikham";
            public static string Nameloaikham = "Nameloaikham";
        }

        public struct Advisory
        {
            public static string Id = "Id";
            public static string IdPatient = "IdPatient";
            public static string Symptom = "Symptom";
            public static string Diagnose = "Diagnose";
            public static string Temperature = "temperature";
            public static string Medicines = "Medicines";
            public static string Huyetap = "huyetap";
            public static string Day = "Day";
            public static string nameofdoctor = "NameDoctor";
            public static string namLoaiKham = "NameLoaiKham";
            public static string Reason = "Reason";
        }

        public struct AdvisoryHistory
        {
            public static string Id = "Id";
            public static string IdPatient = "IdPatient";
            public static string Day = "Day";
            public static string nameofdoctor = "NameDoctor";
        }

        public struct tables
        {
            public static string clinicuser = "clinicuser";
            public static string history = "history";
            public static string medicine = "medicine";
            public static string patient = "patient";
            public static string calendar = "calendar";
            public static string danhthu = "doanhthu";
            public static string diagnoses = "diagnoses";
            public static string lichsunhapthuoc = "lichsunhapthuoc";
            public static string lichHen = "lichhen";
            public static string loaikham = "loaikham";
            public static string reasonapoinment = "reasonapoinment"; 
            public static string listpatienttoday = "listpatienttoday";
            public static string advisory = "Advisory";
            public static string AdvisoryHistory = "AdvisoryHistory";
        }


               //  ExecuteNonQuery("CREATE Table IF NOT EXISTS medicine(Name varchar(50),Count int,CostIn int,CostOut int,InputDay Datetime,Id varchar(10));", null);

           // ExecuteNonQuery("CREATE Table IF NOT EXISTS patient(Name varchar(50),Address Varchar(400),birthday datetime,height int(11),weight int(11),Id varchar(10));", null);
    }
}
