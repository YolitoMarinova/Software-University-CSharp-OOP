namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Common;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;
    using System;
    using System.Collections.Generic;

    public class MachinesManager : IMachinesManager
    {
        private IDictionary<string, IPilot> pilots;
        private IDictionary<string, IMachine> machines;

        public MachinesManager(IDictionary<string, IPilot> pilots, 
            IDictionary<string, IMachine> machines)
        {
            this.pilots = pilots;
            this.machines = machines;
        }

        public string HirePilot(string name)
        {
            if (IsThatPilotExist(name))
            {
                return String.Format(
                    OutputMessages.PilotExists,
                    name);
            }

            IPilot pilot = new Pilot(name);

            this.pilots.Add(name, pilot);

            return String.Format(OutputMessages.PilotHired, name);
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (IsThatMachineExist(name))
            {
                return String.Format(
                    OutputMessages.MachineExists,
                    name);
            }

            IMachine tank = new Tank(name, attackPoints, defensePoints);

            this.machines.Add(name, tank);

            return String.Format(OutputMessages.TankManufactured, name, tank.AttackPoints, tank.DefensePoints);
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (IsThatMachineExist(name))
            {
                return String.Format(
                    OutputMessages.MachineExists,
                    name);
            }

            IMachine fighter = new Fighter(name, attackPoints, defensePoints);

            this.machines.Add(name, fighter);

            return String.Format(OutputMessages.FighterManufactured, name, fighter.AttackPoints, fighter.DefensePoints, "ON");
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            if (!IsThatPilotExist(selectedPilotName))
            {
                return String.Format(
                    OutputMessages.PilotNotFound,
                    selectedPilotName);
            }

            if (!IsThatMachineExist(selectedMachineName))
            {
                return String.Format(
                    OutputMessages.MachineNotFound,
                    selectedPilotName);
            }

            IPilot pilot = this.pilots[selectedPilotName];
            IMachine machine = this.machines[selectedMachineName];

            if (machine.Pilot != null)
            {
                return String.Format(
                    OutputMessages.MachineHasPilotAlready,
                    selectedMachineName);
            }

            pilot.AddMachine(machine);
            machine.Pilot = pilot;

            return String.Format(OutputMessages.MachineEngaged, selectedPilotName, selectedMachineName);
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            if (!IsThatMachineExist(attackingMachineName))
            {
                return String.Format(
                    OutputMessages.MachineNotFound,
                    attackingMachineName);
            }

            if (!IsThatMachineExist(defendingMachineName))
            {
                return String.Format(
                    OutputMessages.MachineNotFound,
                    defendingMachineName);
            }

            IMachine attackingMachine = this.machines[attackingMachineName];
            IMachine defendingMachine = this.machines[defendingMachineName];

            if (attackingMachine.HealthPoints <= 0)
            {
                return String.Format(
                    OutputMessages.DeadMachineCannotAttack,
                    attackingMachineName);
            }

            if (defendingMachine.HealthPoints <= 0)
            {
                return String.Format(
                    OutputMessages.DeadMachineCannotAttack,
                    defendingMachineName);
            }

            attackingMachine.Attack(defendingMachine);

            return String.Format(OutputMessages.AttackSuccessful,defendingMachineName,attackingMachineName,defendingMachine.HealthPoints);
        }

        public string PilotReport(string pilotReporting)
        {
            if (!IsThatPilotExist(pilotReporting))
            {
                return null;
            }

            IPilot pilotToReport = this.pilots[pilotReporting];

            return pilotToReport.Report();
        }

        public string MachineReport(string machineName)
        {
            if (!IsThatMachineExist(machineName))
            {
                return null;
            }

            IMachine machineToReport = this.machines[machineName];

            return machineToReport.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            if (!IsThatMachineExist(fighterName))
            {
                return String.Format(
                    OutputMessages.MachineNotFound,
                    fighterName);
            }

            Fighter fighter = (Fighter)this.machines[fighterName];

            fighter.ToggleAggressiveMode();

            return String.Format(OutputMessages.FighterOperationSuccessful, fighterName);
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            if (!IsThatMachineExist(tankName))
            {
                return String.Format(
                    OutputMessages.MachineNotFound,
                    tankName);
            }

            Tank tank = (Tank)this.machines[tankName];

            tank.ToggleDefenseMode();

            return String.Format(OutputMessages.TankOperationSuccessful, tankName);
        }

        private bool IsThatMachineExist(string name)
        {
            if (!this.machines.ContainsKey(name))
            {
                return false;
            }

            return true;
        }

        private bool IsThatPilotExist(string name)
        {
            if (!this.pilots.ContainsKey(name))
            {
                return false;
            }

            return true;
        }
    }
}