using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public class Tank : Machine, ITank
    {
        private bool defenseMode;
        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints)
	    {
            this.HealthPoints = 100;
            this.DefenseMode = true;
            CalculateAttDef();
	    }
        public bool DefenseMode
        {
            get { return this.defenseMode; }
            private set { this.defenseMode = value; }
        }

        public void ToggleDefenseMode()
        {
            this.DefenseMode = !this.DefenseMode;
            CalculateAttDef();
        }

        private void CalculateAttDef()
        {
            if (this.DefenseMode)
            {
                this.AttackPoints -= 40;
                this.DefensePoints += 30;
            }
            else
            {
                this.AttackPoints += 40;
                this.DefensePoints -= 30;
            }
        }

        public override string ToString()
        {
            StringBuilder report = new StringBuilder();

            report.AppendLine(string.Format("- {0}", this.Name));
            report.AppendLine(string.Format(" *Type: {0}", this.GetType().Name));
            report.Append(base.ToString());
            if (this.DefenseMode)
            {
                report.AppendLine(" *Defense: ON");
            }
            else
	        {
                report.AppendLine(" *Defense: OFF");
	        }
            return report.ToString();
        }
    }
}
