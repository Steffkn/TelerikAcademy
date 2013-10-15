using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MobilePhone.Common
{
    public class GSM : IGSM
    {
        // Fields for GSM data
        private string model = null;
        private string manufacturer = null;

        private double? price = null;
        private string owner = null;


        private Battery battery = new Battery();
        private Display display = new Display();
        private List<Call> callHistory = new List<Call>();

        // 5 properties to encapsulate the data fields
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
            set {
                if (value <= 0)
                {
                    Console.WriteLine("The price must be positive number!");
                }
                else
                {
                    price = value;
                }        
            }
        }
        public string Owner
        {
            get { return owner; }
            set { owner = value; }
        }
        public Battery GSMBattery
        {
            get { return battery; }
            set { battery = value; }
        }

        public Display GSMDisplay
        {
            get { return display; }
            set { display = value; }
        }

        // start 6 Static field and a property IPhone4S in the GSM class to hold the information about iPhone 4S.

        private static GSM iPhone4S = new GSM("Apple", "iPhone4S", 300.0d, "Stefan", 4.2f, 16000000, (BatteryType)2, 300, 30);
        /// <summary>
        /// start 6 Static field and a property IPhone4S in the GSM class to hold the information about iPhone 4S.
        /// </summary>
        public static GSM IPhone4S
        {
            get { return GSM.iPhone4S; }
            // set { GSM.iPhone4S = value; }
        }
        // end 6

        // 2 Constructors for the defined classes that take different sets of arguments
        /// <summary>
        /// Constructors for the defined classes that take 0 arguments.
        /// </summary>
        public GSM()
        {

        }
        /// <summary>
        /// Constructors for the defined classes that take model and manufacturer.
        /// </summary>
        public GSM(string model, string manufacturer)
        {
            this.model = model;
            this.manufacturer = manufacturer;
        }

        /// <summary>
        /// Constructors for the defined classes that take model, manufacturer, price and owner.
        /// </summary>
        public GSM(string model, string manufacturer, double? price, string owner)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
            this.owner = owner;
        }
        /// <summary>
        /// Constructors for the defined classes that take model, manufacturer, displaySize and displayColors.
        /// </summary>
        public GSM(string manufacturer, string model, float displaySize, ulong displayColors)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.GSMDisplay.DisplaySize = displaySize;
            this.GSMDisplay.DisplayColors = displayColors;

        }

        public GSM(string manufacturer, string model, BatteryType modelBattery, uint? hoursIdle, uint? hoursTalk)
        {
            this.model = model;
            this.manufacturer = manufacturer;

            this.GSMBattery.ModelBattery = modelBattery;
            this.GSMBattery.HoursIdle = hoursIdle;
            this.GSMBattery.HoursTalk = hoursTalk;
        }

        public GSM(string manufacturer, string model, double? price, string owner, float? displaySize, ulong? displayColors, BatteryType modelBattery, uint? hoursIdle, uint? hoursTalk)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
            this.owner = owner;
            this.GSMDisplay.DisplaySize = displaySize;
            this.GSMDisplay.DisplayColors = displayColors;

            this.GSMBattery.ModelBattery = modelBattery;
            this.GSMBattery.HoursIdle = hoursIdle;
            this.GSMBattery.HoursTalk = hoursTalk;
        }

        // task4: Add a method in the GSM class for displaying all information about it. Try to override ToString().
        public override string ToString()
        {
            StringBuilder properties = new StringBuilder();
            string notSet = " - ";
            properties.Append(string.Format("GSM properties:{0}", Environment.NewLine));
            properties.Append(string.Format("Manufacturer: {0}{1}", manufacturer, Environment.NewLine));
            properties.Append(string.Format("Model: {0}{1}", model, Environment.NewLine));
            properties.Append(string.Format("Price: {0}lv.{1}", price.ToString() ?? notSet, Environment.NewLine));
            properties.Append(string.Format("Owner: {0}{1}", owner ?? notSet, Environment.NewLine));
            // if the display's size is not sed the string " - " will be displayed instead
            properties.Append(string.Format("\tSize: {0}{1}", (GSMDisplay.DisplaySize > 0 ? GSMDisplay.DisplaySize.ToString() + " inches." : notSet), Environment.NewLine));
            // if the display's colors is not sed the string " - " will be displayed instead
            properties.Append(string.Format("\tColors: {0}{1}", (GSMDisplay.DisplayColors > 0 ? GSMDisplay.DisplayColors.ToString() : notSet), Environment.NewLine));
            properties.Append(string.Format("Battery: {0}", Environment.NewLine));
            properties.Append(string.Format("\tModel: {0}{1}", GSMBattery.ModelBattery.ToString() ?? notSet, Environment.NewLine));
            properties.Append(string.Format("\tHours idle: {0}{1}", (GSMBattery.HoursIdle > 0 ? GSMBattery.HoursIdle.ToString() + " h." : notSet), Environment.NewLine));
            properties.Append(string.Format("\tHours talk: {0}{1}", (GSMBattery.HoursTalk > 0 ? GSMBattery.HoursTalk.ToString() + " h." : notSet), Environment.NewLine));

            return properties.ToString();
        }

        // 9 property CallHistory in the GSM class to hold a list of the performed calls. 
        public List<Call> CallHistory
        {
            get { return callHistory; }
        }

        // 10 methods in the GSM class for adding and deleting calls from the calls history and method to clear the call history.
        /// <summary>
        /// Add a call to the call history.
        /// </summary>
        /// <param name="dialedPhone">The phone that was dialed</param>
        /// <param name="callDuration">The time duration of the call</param>
        public void AddCall(string dialedPhone, int callDuration)
        {
            Call newCall = new Call(dialedPhone, callDuration);
            this.CallHistory.Add(newCall);
        }

        /// <summary>
        /// Asks the user to pick a phone call to be deleted.
        /// </summary>
        public void DeleteCall()
        {
            int callNumber = 0;
            int choise;
            Console.WriteLine("======== Calls =========");
            foreach (var call in callHistory)
            {
                Console.WriteLine(string.Format("{0} - Call at {1} in {2} with {3} elapsed time {4} seconds!",callNumber , call.Date , call.Time , call.DialedPhone , call.CallDuration));
                callNumber++;
            }
            Console.WriteLine("\nWhich call you wanna delete?");

            string s = Console.ReadLine();
            if (int.TryParse(s, out choise))
            {
                choise = int.Parse(s);
                callHistory.RemoveAt(choise);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Call at position {0} deleted!", choise);
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }
        }

        /// <summary>
        /// Delete all calls in call history
        /// </summary>
        public void DeleteAllCalls()
        {
            for (int i = callHistory.Count - 1; i >= 0; i--)
            {
                callHistory.RemoveAt(i);
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("All calls deleted!");
            Console.ResetColor();
        }

        /// <summary>
        /// Method for displaying the history of the calls in a GSM
        /// </summary>
        public void ShowCallHistory()
        {
            if (this.CallHistory.Count > 0)
            {
                Console.WriteLine("<---------------- Call list ---------------->");
                foreach (var call in this.CallHistory)
                {
                    Console.WriteLine(string.Format("Call at {0} in {1} with {2} elapsed time {3} seconds!", call.Date, call.Time, call.DialedPhone, call.CallDuration));
                }
                Console.WriteLine("<------------ End of calls list ------------>");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Call history is empty!");
                Console.ResetColor();
            }
        }

        // 11 method that calculates the total price of the calls in the call history. 
        public decimal AllCallsPrice(decimal pricePerMin)
        {
            decimal price = 0M;
            foreach (var call in this.CallHistory)
            {
                price = price + (Math.Ceiling((decimal)call.CallDuration / 60)) * pricePerMin;
            }
            return price;
        }
    }

}
