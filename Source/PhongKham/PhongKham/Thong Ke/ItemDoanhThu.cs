using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinic
{
    public class ItemDoanhThu
    {
        private string diagnose;

        public string Diagnose
        {
            get { return diagnose; }
            set { diagnose = value; }
        }

        private string loaiKham;

        public string LoaiKham
        {
            get { return loaiKham; }
            set { loaiKham = value; }
        }


        private string services;
        public string Services
        {
          get { return services; }
          set { services = value; }
        }
        string nameOfDoctor;

        public string NameOfDoctor
        {
            get { return nameOfDoctor; }
            set { nameOfDoctor = value; }
        }
        int money;

        public int Money
        {
            get { return money; }
            set { money = value; }
        }
        string date;

        public string Date
        {
            get { return date; }
            set { date = value; }
        }


        private string idPatient;

        public string IdPatient
        {
            get { return idPatient; }
            set { idPatient = value; }
        }
        private string namePatient;

        public string NamePatient
        {
            get { return namePatient; }
            set { namePatient = value; }
        }

        public ItemDoanhThu()
        { }
        public ItemDoanhThu(string date, string nameOfDoctor, int money)
        {
            this.date = date;
            this.nameOfDoctor = nameOfDoctor;
            this.money = money;
        }



    }
}
