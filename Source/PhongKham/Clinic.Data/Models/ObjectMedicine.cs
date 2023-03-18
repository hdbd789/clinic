using System;

namespace Clinic.Data.Models
{
    public class ObjectMedicine : IMedicine
    {
        private string name;
        private string hDSD;
        private string activity;

        public string Activity
        {
            get { return activity; }
            set { activity = value; }
        }
        private int number;

        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        public string HDSD
        {
            get { return hDSD; }
            set { hDSD = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int count;

        /// <summary>
        /// So luong thuoc trong kho.
        /// </summary>
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        private int costOut;

        public int CostOut
        {
            get { return costOut; }
            set { costOut = value; }
        }
        private int costIn;

        public int CostIn
        {
            get { return costIn; }
            set { costIn = value; }
        }
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private DateTime inputDay;

        public DateTime InputDay
        {
            get { return inputDay; }
            set { inputDay = value; }
        }

        private string admin;

        public string Admin
        {
            get { return admin; }
            set { admin = value; }
        }
    }
}
