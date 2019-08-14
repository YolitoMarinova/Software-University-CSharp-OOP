using PlayersAndMonsters.Core.Contracts;
using System;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private IManagerController managerController;

        public Engine(IManagerController managerController)
        {
            this.managerController = managerController;
        }

        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "Exit")
            {
                string[] commandArgs = command.Split();

                string managerCommand = commandArgs[0];
                string username;
                string cardName;

                string result = null;
                try
                {
                    switch (managerCommand)
                    {
                        case "AddPlayer":
                            string playerType = commandArgs[1];
                            username = commandArgs[2];

                            result = this.managerController.AddPlayer(playerType, username);
                            break;
                        case "AddCard":
                            string cardType = commandArgs[1];
                            cardName = commandArgs[2];

                            result = this.managerController.AddCard(cardType, cardName);
                            break;
                        case "AddPlayerCard":
                            username = commandArgs[1];
                            cardName = commandArgs[2];

                            result = this.managerController.AddPlayerCard(username, cardName);
                            break;
                        case "Fight":
                            string attackUser = commandArgs[1];
                            string enemyUser = commandArgs[2];

                            result = this.managerController.Fight(attackUser, enemyUser);
                            break;
                        case "Report":

                            result = this.managerController.Report();
                            break;
                    }

                    Console.WriteLine(result);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                command = Console.ReadLine();
            }

        }
    }
}
