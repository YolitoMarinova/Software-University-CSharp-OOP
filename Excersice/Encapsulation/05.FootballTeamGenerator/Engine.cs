using _05.FootballTeamGenerator.Exceptions;
using _05.FootballTeamGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Engine
    {
        private readonly List<Team> teams;

        public Engine()
        {
            this.teams = new List<Team>();
        }

        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "END")
            {
                try
                {
                    string[] commandTokens = command.Split(";");

                    string commandType = commandTokens[0];
                    string teamName = commandTokens[1];

                    if (commandType == "Team")
                    {
                        Team team = new Team(teamName);

                        this.teams.Add(team);
                    }
                    else if (commandType == "Add")
                    {
                        ValidateTeamName(teamName);

                        string playerName = commandTokens[2];
                        Stat stat = CreateStat(commandTokens);

                        Player player = new Player(playerName, stat);
                        Team team = this.teams.First(t => t.Name == teamName);

                        team.AddPlayer(player);
                    }
                    else if (commandType == "Remove")
                    {
                        ValidateTeamName(teamName);

                        string playerName = commandTokens[2];

                        Team team = this.teams.First(t => t.Name == teamName);

                        team.RemovePlayer(playerName);
                    }
                    else if (commandType == "Rating")
                    {
                        ValidateTeamName(teamName);

                        Team team = this.teams.First(t => t.Name == teamName);
                        Console.WriteLine(team);
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }

                command = Console.ReadLine();
            }
        }

        private Stat CreateStat(string[] commandTokens)
        {
            int endurance = int.Parse(commandTokens[3]);
            int sprint = int.Parse(commandTokens[4]);
            int dribble = int.Parse(commandTokens[5]);
            int passing = int.Parse(commandTokens[6]);
            int shooting = int.Parse(commandTokens[7]);

            return new Stat(endurance, sprint, dribble, passing, shooting);
        }

        private void ValidateTeamName(string name)
        {
            Team team = this.teams.FirstOrDefault(t => t.Name == name);

            if (team == null)
            {
                throw new ArgumentException
                    (String.Format(ExceptionMessages.NoneExcistentTeam, name));
            }
        }
    }
}
