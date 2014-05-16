using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public class Pilot : IPilot
    {
        private string name;
        public List<IMachine> listOfMachines = new List<IMachine>();

        public Pilot(string name)
        {
            this.Name = name;
        }
        public string Name
        {
            get { return name; }
            private set { name = value;}
        }

        public void AddMachine(IMachine machine)
        {
            listOfMachines.Add(machine);
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();
            if (this.listOfMachines.Count == 0)
            {
                report.AppendFormat("{0} - no machines", this.Name);
            }
            else if (this.listOfMachines.Count == 1)
            {
                report.AppendLine(string.Format("{0} - 1 machine", this.Name));
            }
            else
            {
                report.AppendLine(string.Format("{0} - {1} machines", this.Name, this.listOfMachines.Count));
            }

            foreach (var machine in listOfMachines)
            {
                report.Append(machine.ToString());
            }
            return report.ToString();
        }
    }
}
