namespace WarMachines.Engine
{
    using WarMachines.Interfaces;
    using WarMachines.Machines;

    public class MachineFactory : IMachineFactory
    {
        public IPilot HirePilot(string name)
        {
            var pilot = new Pilot(name);
            return pilot;
        }

        public ITank ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            var tank = new Tank(name, attackPoints, defensePoints);
            return tank;
        }

        public IFighter ManufactureFighter(string name, double attackPoints, double defensePoints, bool stealthMode)
        {
            var fighter = new Fighter(name, attackPoints, defensePoints, stealthMode);
            return fighter;
        }
    }
}
