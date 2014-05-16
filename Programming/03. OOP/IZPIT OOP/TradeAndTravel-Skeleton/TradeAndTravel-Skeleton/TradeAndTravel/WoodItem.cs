using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    public class WoodItem : Item
    {
        private static int GeneralItemValue = 2;

        public WoodItem(string name, Location location = null)
            : base(name, WoodItem.GeneralItemValue, ItemType.Wood, location)
        {
        }

        public virtual void UpdateWithInteraction(string interaction)
        {
            switch (interaction)
            {
                case "drop":
                    if (GeneralItemValue > 0)
                    {
                        GeneralItemValue -= 1;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
