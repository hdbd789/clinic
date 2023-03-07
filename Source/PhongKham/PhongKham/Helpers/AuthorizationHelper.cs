namespace Clinic.Helpers
{
    public static class AuthorizationHelper
    {
        public static bool IsRolePrescribe(int authorize)
        {
            return authorize == 1 || authorize == 2 || authorize == 4;
        }

        public static bool IsRolePrescribeInputMedicine(int authorize)
        {
            return authorize == 1 || authorize == 3 || authorize == 4;
        }
    }
}
