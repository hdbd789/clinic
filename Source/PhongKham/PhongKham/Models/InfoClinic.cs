using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinic.Models
{
    public class InfoClinic
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private string sdt;

        public string Sdt
        {
            get { return sdt; }
            set { sdt = value; }
        }
        private string advice;

        public string Advice
        {
            get { return advice; }
            set { advice = value; }
        }

        private string pathData;

        public string PathData
        {
            get { return pathData; }
            set { pathData = value; }
        }
        private string pathTargetBackup;

        public string PathTargetBackup
        {
            get { return pathTargetBackup; }
            set { pathTargetBackup = value; }
        }

        private string CheckedBackup;

        public string CheckedBackup1
        {
            get { return CheckedBackup; }
            set { CheckedBackup = value; }
        }

        private string timeBackup;

        public string TimeBackup
        {
            get { return timeBackup; }
            set { timeBackup = value; }
        }

    }
}
