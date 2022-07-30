using System.Globalization;

namespace Clinic.Helpers
{
    public static class ExtensionMethod
    {
        public static string ToMoney(this int money)
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            return money.ToString("C0", cul);
        }
    }
}
