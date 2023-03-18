using System;

namespace Clinic.Data.Models
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
