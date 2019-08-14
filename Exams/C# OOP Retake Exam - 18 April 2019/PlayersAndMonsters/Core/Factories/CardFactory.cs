using System;
using System.Linq;
using System.Reflection;
using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Cards.Contracts;

namespace PlayersAndMonsters.Core.Factories
{
    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            type += "Card";

            Type currentType = Assembly.GetCallingAssembly().GetTypes().First(x => x.Name == type);

            ICard card = (ICard)Activator.CreateInstance(currentType, name);

            return card;
        }
    }
}
