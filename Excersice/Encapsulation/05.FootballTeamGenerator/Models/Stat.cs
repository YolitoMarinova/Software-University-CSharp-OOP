using _05.FootballTeamGenerator.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05.FootballTeamGenerator.Models
{
    public class Stat
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stat(int endurance,
           int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance
        {
            get => this.endurance;
            private set
            {
                if (!IsValidStat(value))
                {
                    throw new ArgumentException
                        (String.Format(ExceptionMessages.InvalidStat, "Endurance"));
                }

                this.endurance = value;
            }
        }
        public int Sprint
        {
            get => this.sprint;

            private set
            {
                if (!IsValidStat(value))
                {
                    throw new ArgumentException
                        (String.Format(ExceptionMessages.InvalidStat, "Sprint"));
                }

                this.sprint = value;
            }
        }
        public int Dribble
        {
            get => this.dribble;

            private set
            {
                if (!IsValidStat(value))
                {
                    throw new ArgumentException
                        (String.Format(ExceptionMessages.InvalidStat, "Dribble"));
                }

                this.dribble = value;
            }
        }
        public int Passing
        {
            get => this.passing;

            private set
            {
                if (!IsValidStat(value))
                {
                    throw new ArgumentException
                        (String.Format(ExceptionMessages.InvalidStat, "Passing"));
                }

                this.passing = value;
            }
        }
        public int Shooting
        {
            get => this.shooting;

            private set
            {
                if (!IsValidStat(value))
                {
                    throw new ArgumentException
                        (String.Format(ExceptionMessages.InvalidStat, "Shooting"));
                }

                this.shooting = value;
            }
        }

        public double SkillLevel
            => (this.Endurance+this.Sprint
            +this.Dribble+this.Passing
            +this.Shooting)/5.0;

        private bool IsValidStat(int stat)
        {
            return stat >= 0 && stat <= 100;
        }
    }
}
