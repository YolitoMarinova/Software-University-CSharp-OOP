using System.Collections.Generic;
using System.Text;
using MortalEngines.Common;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities
{
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;

        protected BaseMachine(string name,double attackPoints,double defencePoints,double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defencePoints;
            this.HealthPoints = healthPoints;

            this.Targets = new List<string>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ValidateStringNotNullOrWhitespace(value,ExceptionMessages.InvalidMachineName);

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get => this.pilot;
            set
            {
                Validator.ValidateObjectIsNotNull(value,ExceptionMessages.PilotNull);

                this.pilot = value;
            }
        }
        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets { get; private set; }

        public void Attack(IMachine target)
        {
            Validator.ValidateObjectIsNotNull(target, ExceptionMessages.TargetNull);

            var pointsToDecrease = this.AttackPoints - target.DefensePoints;
            var targetHealth = target.HealthPoints - pointsToDecrease;

            if (targetHealth < 0)
            {
                target.HealthPoints = 0;
            }
            else
            {
                target.HealthPoints = targetHealth;
            }

            this.Targets.Add(target.Name);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Health: {this.HealthPoints:F2}");
            sb.AppendLine($" *Attack: {this.AttackPoints:F2}");
            sb.AppendLine($" *Defense: {this.DefensePoints:F2}");
            sb.Append($" *Targets: ");

            if (this.Targets.Count > 0)
            {
                sb.Append(string.Join(",", this.Targets));
            }
            else
            {
                sb.Append("None");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
