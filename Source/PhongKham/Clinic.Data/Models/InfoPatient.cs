﻿using System;
using Clinic.Data.Helpers;
using CsvHelper.Configuration.Attributes;

namespace Clinic.Data.Models
{
    public class InfoPatient : Patient
    {
        [Ignore]
        public string IdHistory { get; set; }
        private string service;
        private string status;
        [Name("Ngày khám")]
        [Index(0)]
        public DateTime NgayKham { get; set; }
        
        [Name("Chẩn đoán")]
        [Index(8)]
        public string Diagnose { get; set; }
        [Name("Nhiệt độ")]
        [Index(9)]
        public string Temperature { get; set; }
        [Name("Huyết áp")]
        [Index(10)]
        public string HuyenAp { get; set; }
        [Name("Tên bác sĩ")]
        [Index(11)]
        public string NameOfDoctor { get; set; }
        [Name("Lí do")]
        [Index(12)]
        public string Reason { get; set; }
        [Name("Bệnh")]
        [Index(13)]
        public string Benh { get; set; }
        [Name("Ngày tái khám")]
        [Index(14)]
        public string NgayTaiKham { get; set; }
        [Ignore()]
        public DateTime NgayTaiKhamDate { get; set; }
        [Name("Trạng thái")]
        [Index(15)]
        public string Status 
        {
            get
            {
                return status;
            }
            set
            {
                if(value == "1")
                {
                    status = "Đã khám";
                }
                else
                {
                    status = "Chưa khám";
                }
            }
        }
        [Name("Thuốc/Dịch vụ")]
        [Index(16)]
        public string Medicines
        {
            get
            {
                return service;
            }
            set
            {
                service = DataHelper.BuildStringMedicines(value);
            }
        }
        [Ignore()]
        public string LoaiKham { get; set; }
        [Ignore]
        public string Age { get; set; }
    }
}
