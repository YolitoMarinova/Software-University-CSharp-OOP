using System;
using System.Collections.Generic;
using System.Linq;
using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private List<IPlayer> players;

        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }


        public int Count => this.players.Count;

        public IReadOnlyCollection<IPlayer> Players =>
            this.players.AsReadOnly();

        public void Add(IPlayer player)
        {
            Validator.ValidateObjectIsNotNull(player,ExceptionsMessages.NullPlayer);

            string playerUsername = player.Username;

            if (this.players.Any(x => x.Username == playerUsername))
            {
                throw new ArgumentException(String.Format(
                    ExceptionsMessages.PlayerAlreadyExist,
                    playerUsername));
            }

            this.players.Add(player);
        }

        public IPlayer Find(string username)
        {
            IPlayer player = this.players.FirstOrDefault(x=>x.Username==username);

            return player;
        }

        public bool Remove(IPlayer player)
        {
            Validator.ValidateObjectIsNotNull(player,ExceptionsMessages.NullPlayer);

            return this.players.Remove(player);
        }
    }
}
