using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    public class Merchant : Person, IShopkeeper, ITraveller
    {
        public Merchant(string name, Location location) :
            base(name, location)
        {
        }

        public int CalculateSellingPrice(Item item)
        {
            return item.Value;
        }

        public int CalculateBuyingPrice(Item item)
        {
            return item.Value / 2;
        }

        public void TravelTo(Location location)
        {
            this.Location = location;
        }
    }
}
