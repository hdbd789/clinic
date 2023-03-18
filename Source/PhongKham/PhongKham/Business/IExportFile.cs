using System.Collections.Generic;
using Clinic.Data.Models;

namespace Clinic.Business
{
    interface IExportFile
    {
        void ExportAction(List<InfoPatient> infoPatients);
    }
}
