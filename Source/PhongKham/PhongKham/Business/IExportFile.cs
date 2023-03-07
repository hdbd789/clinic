using Clinic.Models;
using System.Collections.Generic;

namespace Clinic.Business
{
    interface IExportFile
    {
        void ExportAction(List<InfoPatient> infoPatients);
    }
}
