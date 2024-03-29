﻿using MortalEngines.Common;
using MortalEngines.Entities.Contracts;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Pilot : IPilot
    {
        private string name;
        private ICollection<IMachine> machines;

        public Pilot(string name)
        {
            this.Name = name;
            this.machines = new List<IMachine>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ValidateStringNotNullOrWhitespace(value,ExceptionMessages.InvalidPilotName);

                this.name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            Validator.ValidateObjectIsNotNull(machine,ExceptionMessages.MachineNull);

            this.machines.Add(machine);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.name} - {this.machines.Count} machines");

            foreach (var machine in this.machines)
            {
                machine.ToString();
            }

            return sb.ToString().TrimEnd();
        }
    }
}
