using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public class Fighter : Machine, IFighter
    {
        private bool stealthMode;
        public Fighter(string name, double attackPoints, double defensePoints, bool stealthMode)
            : base(name, attackPoints, defensePoints)
        {
            this.HealthPoints = 200;
            this.StealthMode = stealthMode;
        }

        public bool StealthMode
        {
            get { return this.stealthMode; }
            private set { this.stealthMode = value; }
        }

        public void ToggleStealthMode()
        {
            this.StealthMode = !this.StealthMode;
        }
        public override string ToString()
        {
            StringBuilder report = new StringBuilder();

            report.AppendLine(string.Format("- {0}", this.Name));
            report.AppendLine(string.Format(" *Type: {0}", this.GetType().Name));
            report.Append(base.ToString());

            if (this.StealthMode)
            {
                report.Append(" *Stealth: ON");
            }
            else
            {
                report.Append(" *Stealth: OFF");
            }
            return report.ToString();
        }
    }
}
