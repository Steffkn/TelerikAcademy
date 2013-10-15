using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.Common
{
    // interface for GSM 
    public interface IGSM
    {
        string Model { get; set; }
        string Manufacturer { get; set; }
        Battery GSMBattery { get; set; }
        Display GSMDisplay { get; set; }
    }
}
