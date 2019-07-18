using _05.FootballTeamGenerator.Exceptions;
using System;
namespace _05.FootballTeamGenerator.Models
{
    public class Player
    {
        private string name;
        
        public Player(string name,Stat stat)
        {
            this.Name = name;
            this.Stat = stat;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.EmptyName);
                }

                this.name = value;
            }
        }
        public double OverallSkill
            => this.Stat.SkillLevel;
        public Stat Stat { get; private set; }
    }
}
