using System;

namespace Clinic.Models
{
    public class InfoPatient : Patient
    {
        public string Phone { get; set; }
        public DateTime NgayKham { get; set; }
        public string Diagnose { get; set; }
        public string Temperature { get; set; }
        public string HuyenAp { get; set; }
        public string Medicines { get; set; }
        public string NameOfDoctor { get; set; }
        public string Reason { get; set; }
        public string Benh { get; set; }
        public DateTime? NgayTaiKham { get; set; }
        public string Status { get; set; }
    }
}
