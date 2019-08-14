using System;
using System.Linq;
using System.Reflection;
using PlayersAndMonsters.Repositories;
using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;

namespace PlayersAndMonsters.Core.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            CardRepository currentCardRepository = new CardRepository();

            Type currentType = Assembly.GetCallingAssembly().GetTypes().First(x => x.Name == type);

            IPlayer player = (IPlayer)Activator.CreateInstance(currentType, currentCardRepository, username);

            return player;
        }
    }
}
