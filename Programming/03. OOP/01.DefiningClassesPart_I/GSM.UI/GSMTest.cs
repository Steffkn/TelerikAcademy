/*
 * 7 Write a class GSMTest to test the GSM class:
 *       Create an array of few instances of the GSM class.
 *       Display the information about the GSMs in the array.
 *       Display the information about the static property IPhone4S.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilePhone.Common;

namespace MobilePhone.GSMTest
{
    class UI
    {
        // there are 2 main functions !!
        static void Main()
        {
            // make a list of GSM's
            List<IGSM> GSMs = new List<IGSM>();
            GSMs.Add(new GSM("Samsung", "Galaxy Ace II"));
            GSMs.Add(new GSM("Samsung", "Galaxy Ace II", 350.0d, "Petrov", 3.8f, 16000000, (BatteryType)1, 400, 16));
            GSMs.Add(new GSM("Samsung", "Galaxy Ace II", (BatteryType)1, 400, 16));
            GSMs.Add(new GSM("Samsung", "Galaxy Ace II", 3.8f, 16000000));
            GSMs.Add(new GSM("SonyErricson", "k800i", 2.1f, 252000));
            GSMs.Add(new GSM("Samsung", "Galaxy Ace II", null, "Petrov", null, 16000000, (BatteryType)1, null, null));

            foreach (var gsm in GSMs)
            {
                // i want 1 empty line
                Console.WriteLine("<------------------------------------------------->{0}", Environment.NewLine);
                Console.WriteLine(gsm.ToString());
            }

            Console.WriteLine("IPhone 4S");
            Console.WriteLine(GSM.IPhone4S.ToString());

            // some more GSM options
            //IGSM myGSM = new GSM();
            //myGSM.Model = "Galaxy Ace II";
            //myGSM.Manufacturer = "Samsung";
            //myGSM.GSMBattery.HoursIdle = 400;
            //myGSM.GSMBattery.HoursTalk = 16;
            //myGSM.GSMBattery.ModelBattery = (BatteryType)1;
            //myGSM.GSMDisplay.DisplayColors = 16000000;
            //myGSM.GSMDisplay.DisplaySize = 3.8f;

            //IGSM myGalaxyWithBattery = new GSM("Samsung", "Galaxy Ace II", (BatteryType)1, 400, 16);
            //IGSM myGalaxyWithDisplay = new GSM("Samsung", "Galaxy Ace II", 3.8f, 16000000);
            //IGSM mySonyErricson = new GSM("SonyErricson", "k800i", 2.1f, 252000);
            //IGSM myOtherGSM = new GSM("BestManufacturer", "SuperModel");
            

            //Console.WriteLine(myGSM.ToString());
            //Console.WriteLine(myGalaxyWithBattery.ToString());
            //Console.WriteLine(myGalaxyWithDisplay.ToString());
            //Console.WriteLine(mySonyErricson.ToString());
            //Console.WriteLine(myOtherGSM.ToString());

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Call history test!");
            Console.ResetColor();

            GSM myGSM = new GSM();
            myGSM.AddCall("0889999999", 246);
            myGSM.AddCall("0880000000", 1234);
            myGSM.AddCall("0881111111", 123);
            myGSM.AddCall("0892222222", 23);
            myGSM.AddCall("0993333333", 3);

            // shows all calls in the history
            myGSM.ShowCallHistory();

            // show the price of the calls in the history (price 0.37 per minute)
            Console.WriteLine("Price of all calls: {0}", myGSM.AllCallsPrice(0.37M));

            // delete a call from the history
            Console.WriteLine("Delete call tests!");
            myGSM.DeleteCall();
            // shows all calls in the history
            myGSM.ShowCallHistory();

            // show the price of the calls in the history (price 0.37 per minute)
            Console.WriteLine("Price of all calls: {0}", myGSM.AllCallsPrice(0.37M));


            Console.WriteLine("Delete all calls tests!");
            // deletes all calls in the history
            myGSM.DeleteAllCalls();
            // shows the empty calls history
            myGSM.ShowCallHistory();
        }
    }
}
