using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.Common
{
    // 8 Class Call holding the calls performed through a GSM
    public class Call
    {

        private string date;
        private string time;
        private string dialedPhone;
        private int callDuration;

        public string Date
        {
            get { return date; }
        }
        public string Time
        {
            get { return time; }
        }
        public string DialedPhone
        {
            get { return dialedPhone; }
        }
        public int CallDuration
        {
            get { return callDuration; }
        }
        // Call constructor: addes current time and date as parameters, phone dialed and call's duration
        public Call(string dialedPhone, int callDuration)
        {
            this.date = (DateTime.Now.Year).ToString() + "/" + (DateTime.Now.Month).ToString() + "/" + (DateTime.Now.Day).ToString();
            this.time = (DateTime.Now.Hour).ToString() + ":" + (DateTime.Now.Minute).ToString() + ":" + (DateTime.Now.Second).ToString();
            this.dialedPhone = dialedPhone;
            this.callDuration = callDuration;
        }
    }
}
