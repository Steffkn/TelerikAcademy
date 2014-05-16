using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.Common
{
    public class Battery
    {
        // data fields for thebattery
        private BatteryType modelBattery;
        //private string modelBattery = null;
        private uint? hoursIdle = 0;
        private uint? hoursTalk = 0;

        // 5 properties to encapsulate the data fields
        public BatteryType ModelBattery
        {
            get { return modelBattery; }
            set { modelBattery = value; }
        }
        public uint? HoursIdle
        {
            get { return hoursIdle; }
            set { hoursIdle = value; }
        }
        public uint? HoursTalk
        {
            get { return hoursTalk; }
            set { hoursTalk = value; }
        }

        /// <summary>
        /// Constructor for battery with all properties.
        /// </summary>
        /// <param name="model">Model of the battery</param>
        /// <param name="hoursIdle">Hours idle time</param>
        /// <param name="hoursTalk">Hours talking time</param>
        public Battery(BatteryType model, uint? hoursIdle, uint? hoursTalk)
        {
            this.modelBattery = model;
            this.HoursTalk = hoursTalk;
            this.HoursIdle = hoursIdle;
        }

        /// <summary>
        /// Constructor for battery with model and hours idle time.
        /// </summary>
        /// <param name="model">Model of the battery</param>
        /// <param name="hoursIdle">Hours idle time</param>
        public Battery(BatteryType model, uint? hoursIdle)
        {
            this.modelBattery = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = null;
        }
        /// <summary>
        /// Constructor for battery with model only.
        /// </summary>
        /// <param name="model">Model of the battery</param>
        public Battery(BatteryType model)
        {
            this.modelBattery = model;
            this.HoursTalk = null;
            this.HoursIdle = null;
        }
        /// <summary>
        /// Empty constructor.
        /// </summary>
        public Battery()
        {
            this.modelBattery = 0;
            this.HoursTalk = null;
            this.HoursIdle = null;
        }
    }
}
