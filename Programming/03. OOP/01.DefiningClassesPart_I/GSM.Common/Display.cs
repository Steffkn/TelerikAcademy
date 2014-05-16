using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.Common
{
    public class Display
    {
        // data fields for the display
        private float? displaySize; // inches
        private ulong? displayColors;

        // 5 properties to encapsulate the data fields
        public float? DisplaySize
        {
            get { return displaySize; }
            set { displaySize = value; }
        }
        public ulong? DisplayColors
        {
            get { return displayColors; }
            set { displayColors = value; }
        }


    }
}
