using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    public class Weapon : Item
    {
        const int GeneralArmorValue = 10;

        public Weapon(string name, Location location = null)
            : base(name, Weapon.GeneralArmorValue, ItemType.Weapon, location)
        {
        }

        public static List<ItemType> GetComposingItems()
        {
            return new List<ItemType>() { ItemType.Iron, ItemType.Wood};
        }
    }
}
