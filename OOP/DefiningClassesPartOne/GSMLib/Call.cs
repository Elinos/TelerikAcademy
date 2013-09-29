using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GSMLib
{
    public class Call
    {
        private DateTime date;
        private TimeSpan time;
        private string dialedPhoneNumber;
        private int duration;

        public int Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        public string DialedPhoneNumber
        {
            get { return dialedPhoneNumber; }
            set { dialedPhoneNumber = value; }
        }
        
        public TimeSpan Time
        {
            get { return time; }
            set { time = value; }
        }
        
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }


        public Call(DateTime dt, string phoneNumber, int duration)
        {
            this.date = dt.Date;
            this.time = dt.TimeOfDay;

            this.dialedPhoneNumber = phoneNumber;
            this.duration = duration;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Time of call: " + date.ToShortDateString());
            sb.AppendLine(" " + time.ToString(@"hh\:mm\:ss"));
            sb.AppendLine("Phone number: " + dialedPhoneNumber);
            sb.AppendLine("Call duration: " + TimeSpan.FromSeconds(duration));
            
            return sb.ToString();
        }
    }
}
