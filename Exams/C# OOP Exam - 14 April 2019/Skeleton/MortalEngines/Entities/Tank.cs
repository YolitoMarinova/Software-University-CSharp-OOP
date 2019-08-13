using MortalEngines.Entities.Contracts;
using System;

namespace MortalEngines.Entities
{
    public class Tank : BaseMachine, ITank
    {
        private const double INITIAL_HEALTH_POINTS = 100;
        private const double ATTACK_BONUS = 40;
        private const double DEFENCE_BONUS = 30;

        public Tank(string name, double attackPoints, double defencePoints) 
            : base(name,
                  attackPoints - ATTACK_BONUS, 
                  defencePoints + DEFENCE_BONUS, 
                  INITIAL_HEALTH_POINTS)
        {
            this.DefenseMode = true;
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode == true)
            {
                this.AttackPoints += ATTACK_BONUS;
                this.DefensePoints -= DEFENCE_BONUS;

                this.DefenseMode = false;
            }
            else if (this.DefenseMode == false)
            {
                this.AttackPoints -= ATTACK_BONUS;
                this.DefensePoints += DEFENCE_BONUS;

                this.DefenseMode = true;
            }
        }

        public override string ToString()
        {
            string defenseModeCondition = this.DefenseMode == true ? "ON" : "OFF";

            return base.ToString() + Environment.NewLine + $" *Defense: {defenseModeCondition}";
        }
    }
}
