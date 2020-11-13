using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Clinic.Models
{
    public class ADate
    {
        public DateTime StartTime;
        public DateTime EndTime;
        public string Text;
        public int color;
        public int Id;
        //HatchStyle pattern;
        //Color patternColor;

        public ADate()
        { }

        public ADate(DateTime startTime, DateTime endTime, string text, int color)
        {
            StartTime = startTime;
            EndTime = endTime;
            Text = text;
            this.color = color;

        }
    }
}
