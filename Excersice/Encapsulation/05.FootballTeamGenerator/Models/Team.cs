using _05.FootballTeamGenerator.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FootballTeamGenerator.Models
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.EmptyName);
                }

                this.name = value;
            }
        }
        public int Rating
        {
            get
            {
                if (this.players.Count == 0)
                {
                    return 0;
                }

                return (int)(Math.Round(this.players.Average(x => x.OverallSkill)));
            }
        }
        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string name)
        {
            Player playerToRemove = this.players.FirstOrDefault(p => p.Name == name);

            if (playerToRemove == null)
            {
                throw new InvalidOperationException
                    (String.Format(ExceptionMessages.IvalidRemovePlayerOperation, name, this.Name));
            }

            this.players.Remove(playerToRemove);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}
