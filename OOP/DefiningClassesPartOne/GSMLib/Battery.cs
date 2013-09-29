using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMLib
{
    public class Battery
    {
        private string model;
        private float? hoursIdle;
        private float? hoursTalk;
        private BatteryType batteryType;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public float? HoursIdle
        {
            get { return hoursIdle; }
            set
            {
                if (hoursIdle < 0 || hoursIdle > float.MaxValue)
                    throw new ArgumentOutOfRangeException(hoursIdle.ToString(), "Size must be a positive number!");
                else
                    hoursIdle = value;
            }
        }

        public float? HoursTalk
        {
            get { return hoursTalk; }
            set
            {
                if (hoursTalk < 0 || hoursTalk > float.MaxValue)
                    throw new ArgumentOutOfRangeException(hoursIdle.ToString(), "Size must be a positive number!");
                else
                    hoursTalk = value;
            }
        }

        public BatteryType BatteryType
        {
            get { return batteryType; }
            set { batteryType = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Battery model: " + model);
            sb.AppendLine("Hours idle: " + hoursIdle);
            sb.AppendLine("Hours talked: " + hoursTalk);
            sb.AppendLine("Battery type: " + batteryType);

            return sb.ToString();
        }
    }
}
