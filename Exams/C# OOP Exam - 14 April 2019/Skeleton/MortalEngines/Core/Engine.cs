using MortalEngines.Core.Contracts;
using System;

namespace MortalEngines.Core
{
    public class Engine : IEngine
    {
        private IMachinesManager machinesManager;

        public Engine(IMachinesManager machinesManager)
        {
            this.machinesManager = machinesManager;
        }

        public void Run()
        {
            try
            {
                string command = Console.ReadLine();

                while (command != "Quit")
                {
                    string[] commandArgs = command.Split();

                    string commandName = commandArgs[0];
                    string name = commandArgs[1];

                    string result = string.Empty;

                    double attackPoints;
                    double defensePoints;

                    switch (commandName)
                    {
                        case "HirePilot":
                            result = this.machinesManager.HirePilot(name);
                            break;
                        case "PilotReport":
                            result = this.machinesManager.PilotReport(name);
                            break;
                        case "ManufactureTank":
                            attackPoints = double.Parse(commandArgs[2]);
                            defensePoints = double.Parse(commandArgs[3]);

                            result = this.machinesManager.ManufactureTank(name, attackPoints, defensePoints);
                            break;
                        case "ManufactureFighter":
                            attackPoints = double.Parse(commandArgs[2]);
                            defensePoints = double.Parse(commandArgs[3]);

                            result = this.machinesManager.ManufactureFighter(name, attackPoints, defensePoints);
                            break;
                        case "MachineReport":
                            result = this.machinesManager.MachineReport(name);
                            break;
                        case "AggressiveMode":
                            result = this.machinesManager.ToggleFighterAggressiveMode(name);
                            break;
                        case "DefenseMode":
                            result = this.machinesManager.ToggleTankDefenseMode(name);
                            break;
                        case "Engage":
                            string pilotName = commandArgs[1];
                            string machineName = commandArgs[2];

                            result = this.machinesManager.EngageMachine(pilotName, machineName);
                            break;
                        case "Attack":
                            string attackingMachineName = commandArgs[1];
                            string defendingMachineName = commandArgs[2];

                            result = this.machinesManager.AttackMachines(attackingMachineName, defendingMachineName);
                            break;
                    }

                    Console.WriteLine(result);

                    command = Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }
    }
}
