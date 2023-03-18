using System;
using System.Linq;
using System.Text;

namespace Clinic.Data.Helpers
{
    public static class DataHelper
    {
        internal static string BuildStringMedicines(string medicineStr)
        {
            StringBuilder result = new StringBuilder();
            string[] serviceArray = medicineStr.Split(new string[] { ClinicConstant.StringBetweenOfMedicine }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < serviceArray.Count(); i++)
            {
                string nameMedicine = serviceArray[i].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();
                result.Append(nameMedicine);
                if (i != serviceArray.Count() - 1)
                {
                    result.Append(ClinicConstant.StringBetweenOfMedicine);
                }
            }

            return result.ToString();
        }
    }
}
