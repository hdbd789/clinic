using System.Collections.Generic;
using Clinic.Data.Models;
using Clinic.Models;

namespace Clinic.Business
{
    interface ISavePatientCommand
    {
        string ButtonInputText { get; }
        string MessageNotifyFinishWithoutAppointment { get;}
        string MessageNotifyFinishWithAppointment { get;}
        LoadDataType LoadDataType { get;}
        void DoAction(InfoPatient infoPatient, bool isAppointment, List<Medicine> listMedicines, int tongTien, ref string errorMessage);

        void CreatePDFPrescription(
            InfoPatient infoPatient,
            InfoClinic infoClinic,
            bool isAppointment,
            List<Medicine> listMedicines);
    }
}
