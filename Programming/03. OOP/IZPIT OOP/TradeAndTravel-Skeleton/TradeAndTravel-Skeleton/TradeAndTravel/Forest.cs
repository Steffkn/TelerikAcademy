using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    public class Forest : Location
    {
        public Forest(string name)
            : base(name, LocationType.Mine)
        {
        }

        public ItemType GatheredType
        {
            get { return ItemType.Wood; }
        }

        public ItemType RequiredItem
        {
            get { return ItemType.Weapon; }
        }

        public Item ProduceItem(string name)
        {
            return new WoodItem(name);
        }
    }
}
