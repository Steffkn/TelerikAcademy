using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    public class IronItem : Item
    {
        const int GeneralIronValue = 3;

        public IronItem(string name, Location location = null)
            : base(name, IronItem.GeneralIronValue, ItemType.Armor, location)
        {
        }
    }
}
