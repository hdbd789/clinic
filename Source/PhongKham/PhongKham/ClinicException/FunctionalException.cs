using System;

namespace Clinic.ClinicException
{
    public class FunctionalException : Exception
    {
        public FunctionalException(string message) : base(message) { }

        public FunctionalException(string message, Exception ex) : base(message, ex) { }
    }
}
