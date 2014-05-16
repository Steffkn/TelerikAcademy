using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public class Machine : IMachine
    {
        private string name;
        private double attackPoints;
        private double defensePoints;
        private double healthPoints;
        private IPilot pilot;
        private IList<string> targets = new List<string>();

        public Machine(string name, double attackPoints, double defensePoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double HealthPoints
        {
            get { return this.healthPoints; }
            set { this.healthPoints = value; }
        }

        public double AttackPoints
        {
            get { return this.attackPoints; }
            protected set { this.attackPoints = value; }
        }

        public double DefensePoints
        {
            get { return this.defensePoints; }
            protected set { this.defensePoints = value; }
        }

        public IPilot Pilot
        {
            get { return this.pilot; }
            set { this.pilot = value; }
        }

        public IList<string> Targets
        {
            get { return this.targets; }
        }

        public void Attack(string target)
        {
        }

        public void AddTarget(string target)
        {
            this.Targets.Add(target);
        }
        public override string ToString()
        {
            StringBuilder report = new StringBuilder();

            report.AppendLine(string.Format(" *Health: {0}", this.HealthPoints));
            report.AppendLine(string.Format(" *Attack: {0}", this.AttackPoints));
            report.AppendLine(string.Format(" *Defense: {0}", this.DefensePoints));

            if (this.Targets.Count > 0)
            {
                string targetsToString = string.Join(", ", Targets.ToArray<string>());
                report.AppendLine(string.Format(" *Targets: {0}", targetsToString));
            }
            else
            {
                report.AppendLine(" *Targets: None");
            }

            return report.ToString();
        }
    }
}
