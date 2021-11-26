﻿//-----------------------------------------------------------------------
// <copyright file="Patient.cs" company="emotive GmbH">
//     Copyright (c) emotive GmbH. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Clinic.Models
{
    using CsvHelper.Configuration.Attributes;
    using System;

    /// <summary>
    /// Comment for the class
    /// </summary>
    public class Patient
    {
        #region Fields
        private string id;
        private string phone;
        [Ignore()]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        [Name("Tên bệnh nhân")]
        [Index(1)]
        public string Name { get; set; }
        [Name("Ngày sinh")]
        [Index(2)]
        public DateTime Birthday { get; set; }
        [Ignore()]
        public int Old { get; set; }
        [Name("Số điện thoại")]
        [Index(3)]
        public string Phone 
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
                if(long.TryParse(phone, out long phoneNumber))
                {
                    phone = string.Format("{0:0### ### ###}", phoneNumber);
                }
            }
        }
        [Name("Địa chỉ")]
        [Index(4)]
        public string Address { get; set; }
        [Name("Chiều cao")]
        [Index(5)]
        public string Height { get; set; }
        [Name("Cân nặng")]
        [Index(6)]
        public string Weight { get; set; }
        [Name("Triệu chứng")]
        [Index(7)]
        public string Symptom { get; set; }
        #endregion

        #region ctors
        public Patient(string id, string name, string weight, string height, string address, DateTime birthday)
        {
            this.id = id;
            Name = name;
            Weight = weight;
            Height = height;
            Address = address;
            Birthday = birthday;
        }
        public Patient() { }
        #endregion

        #region Properties

        #endregion

        #region Methods

        #endregion
    }
}
