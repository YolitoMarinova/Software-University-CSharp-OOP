using MortalEngines.Core;
using MortalEngines.Entities.Contracts;
using System.Collections.Generic;

namespace MortalEngines
{
    public class StartUp
    {
        public static void Main()
        {
           Dictionary<string, IPilot> pilots = new Dictionary<string, IPilot>();
           Dictionary<string, IMachine> machines = new Dictionary<string, IMachine>();

           MachinesManager machinesManager = new MachinesManager(pilots,machines);

            Engine engine = new Engine(machinesManager);
            engine.Run();
        }
    }
}