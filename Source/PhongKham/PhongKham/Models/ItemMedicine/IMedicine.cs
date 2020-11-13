using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinic.Models.ItemMedicine
{
    public interface IMedicine
    {
        string Activity { get; set; }
        int Number { get; set; }
        string HDSD { get; set; }
        string Name { get; set; }
        int Count { get; set; }
        int CostOut { get; set; }
        int CostIn { get; set; }
        string Id { get; set; }
        DateTime InputDay { get; set; }
        string Admin { get; set; }
    }
}
