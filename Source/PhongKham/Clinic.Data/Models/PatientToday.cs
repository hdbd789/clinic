namespace Clinic.Data.Models
{
    public class PatientToday
    {
        public string IdPatient { get; set; }
        public string NamePatient { get; set; }
        public string State { get; set; }
        public RecordType Type { get; set; }
    }
}
