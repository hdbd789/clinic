using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinic
{
    public class ClinicConstant
    {
        /// <summary>
        /// clinicuser table Username varchar(50),Password1  varchar(50),Authority  smallint(6), Password2  varchar(50))
        /// </summary>
        public const string ClinicUserTable_Username = "Username";
        public const string ClinicUserTable_Password1 = "Password1";
        public const string ClinicUserTable_Authority = "Authority";
        public const string ClinicUserTable_Password2 = "Password2";
        public const string ClinicUserTable_namedoctor = "namedoctor";
        
        /// <summary>
        /// history(Id varchar(10),Symptom Longtext,Diagnose Longtext,Medicines Longtext,Day Datetime)
        /// </summary>
        /// 
        public const string HistoryTable = "history";
        public const string HistoryTable_Id = "Id";
        public const string HistoryTable_Symptom = "Symptom";
        public const string HistoryTable_Diagnose = "Diagnose";
        public const string HistoryTable_Medicines = "Medicines";
        public const string HistoryTable_Day = "Day";
        public const string HistoryTable_IdHistory = "IdHistory";
        public const string HistoryTable_Reason = "Reason";

        /// <summary>
        /// medicine(Name varchar(50),Count int,CostIn int,CostOut int,InputDay Datetime,Id varchar(10))
        /// </summary>
        /// 
        public const string MedicineTable = "medicine";
        public const string MedicineTable_Name = "Name";
        public const string MedicineTable_Count = "Count";
        public const string MedicineTable_CostIn = "CostIn";
        public const string MedicineTable_CostOut = "CostOut";
        public const string MedicineTable_InputDay = "InputDay";
        public const string MedicineTable_Id = "Id";
        public const string MedicineTable_Admin = "Admin";
        public const string MedicineTable_Hdsd = "Hdsd";

        /// <summary>
        /// patient(Idpatient INT NOT NULL AUTO_INCREMENT,Name varchar(50),Address Varchar(400),birthday datetime,height int(11),weight int(11)
        /// </summary>
        public const string PatientTable_Idpatient = "Idpatient";


        /// <summary>
        /// loaikham(Idloaikham INT NOT NULL AUTO_INCREMENT,Nameloaikham TEXT NOT NULL, PRIMARY KEY (Idloaikham))

        public const string LoaiKhamTable = "loaikham";
        public const string LoaiKhamTable_Idloaikham = "Idloaikham";
        public const string LoaiKhamTable_Nameloaikham = "Nameloaikham";

        /// <summary>
        /// doanhthu(Iddoanhthu INT NOT NULL AUTO_INCREMENT,Namedoctor TEXT NULL,Money int NULL,time datetime,Services
        /// </summary>
        public const string DoanhThuTable = "doanhthu";
        public const string DoanhThuTable_Services = "Services";
        public const string DoanhThuTable_LoaiKham = "LoaiKham";
        public const string DoanhThuTable_Namedoctor = "Namedoctor";
        public const string DoanhThuTable_Money = "Money";
        public const string DoanhThuTable_Time = "time";
        public const string DoanhThuTable_NamePatient = "NamePatient";
        public const string DoanhThuTable_IdPatient = "IdPatient";




        public const string StringBetweenServicesInDoanhThu= "*_*Services";

        /// <summary>
        /// @SieuAm *_*S_A Nguyen Thi A 
        /// </summary>
        public const string StringBetweenServiceAndAdmin = " *** ";


        #region Notify text in app
        public const string SuccessUpdate_Text = "Cập nhật thành công.";
        public const string FailUpdate_Text = "Cập nhật thất bại.";
        #endregion
    }
}
