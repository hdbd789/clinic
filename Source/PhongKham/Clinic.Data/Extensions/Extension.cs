namespace Clinic.Data.Extensions
{
    public static class Extension
    {
        public static int ToInt(this object number)
        {
            if(number == null)
            {
                return 0;
            }

            return int.TryParse(number.ToString(), out int result) ? result : 0;
        }

        public static string ToStringOrDefault(this object a)
        {
            if (a != null)
            {
                return a.ToString();
            }
            return "";
        }
    }
}
