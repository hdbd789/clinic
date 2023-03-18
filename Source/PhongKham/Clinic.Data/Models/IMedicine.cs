using System;

namespace Clinic.Data.Models
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
