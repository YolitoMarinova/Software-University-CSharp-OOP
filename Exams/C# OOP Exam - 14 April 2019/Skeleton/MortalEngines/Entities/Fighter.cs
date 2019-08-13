using System;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities
{
    public class Fighter : BaseMachine, IFighter
    {
        private const double INITIAL_HEALTH_POINTS = 200;
        private const double ATTACK_BONUS = 50;
        private const double DEFENCE_BONUS = 25;



        public Fighter(string name, double attackPoints, double defencePoints)
            : base(name, 
                  attackPoints + ATTACK_BONUS,
                  defencePoints - DEFENCE_BONUS, 
                  INITIAL_HEALTH_POINTS)
        {
            this.AggressiveMode = true;
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode == true)
            {
                this.AttackPoints -= ATTACK_BONUS;
                this.DefensePoints += DEFENCE_BONUS;

                this.AggressiveMode = false;
            }
            else if (this.AggressiveMode == false)
            {
                this.AttackPoints += ATTACK_BONUS;
                this.DefensePoints -= DEFENCE_BONUS;

                this.AggressiveMode = true;
            }
        }

        public override string ToString()
        {
            string aggressiveModeCondition = this.AggressiveMode == true ? "ON" : "OFF";

            return base.ToString() + Environment.NewLine + $" *Aggressive: {aggressiveModeCondition}";
        }
    }
}
