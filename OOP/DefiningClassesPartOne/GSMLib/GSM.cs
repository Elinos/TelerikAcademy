using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMLib
{
    public class GSM
    {
        private Battery battery;
        private Display display;
        private string model;
        private string manufacturer;
        private double? price;
        private string owner;
        private static GSM iPhone4S = new GSM("IPhone", "Apple", 1099, "Pesho", new Battery(), new Display());
        private List<Call> callHistory = new List<Call>();

        public List<Call> CallHistory
        {
            get { return callHistory; }
        }

        public GSM(string model, string manufacturer)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = null;
            this.Owner = null;
            this.Battery = null;
            this.Display = null;
        }

        public static GSM IPhone4S
        {
            get { return iPhone4S; }
        }
        
        public GSM(string model, string manufacturer, double? price, string owner, Battery battery, Display display)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.Battery = battery;
            this.Display = display;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public string Manufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; }
        }

        public double? Price
        {
            get { return price; }
            set 
            {
                if (price < 0 || price > double.MaxValue)
                    throw new ArgumentOutOfRangeException(price.ToString(), "Price must be a positive number!");
                else
                    price = value;
            }
        }

        public string Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        public Display Display
        {
            get { return display; }
            set { display = value ?? new Display(); }
        }

        public Battery Battery
        {
            get { return battery; }
            set { battery = value ?? new Battery(); }
        }

        public void AddCall(Call call)
        {
            CallHistory.Add(call);
        }
  
        public void DeleteCall(Call call)
        {
            if (CallHistory.Contains(call))
            {
                CallHistory.Remove(call);
            }
            else
            {
                throw new ArgumentOutOfRangeException("The call doesn't exist in the call history!");
            }
        }
  
        public void ClearCallHistory()
        {
            CallHistory.Clear();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Model: " + model);
            sb.AppendLine("Manufacturer: " + manufacturer);
            sb.AppendLine("Price: " + price);
            sb.AppendLine("Owner: " + owner);
            sb.Append(battery.ToString());
            sb.Append(display.ToString());

            return sb.ToString();
        }

        public double TotalCallCosts(float pricePerMinute)
        {
            double totalCallCosts = 0;
            foreach (var call in callHistory)
            {
                totalCallCosts += call.Duration / 60 * pricePerMinute;
            }
            return totalCallCosts;
        }
    }
}
