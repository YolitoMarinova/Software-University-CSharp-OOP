using PlayersAndMonsters.Models.Players.Contracts;
using System;

namespace PlayersAndMonsters.Common
{
    public static class Validator
    {
        public static void ValidateStringIsNotNullOrEmpty(string str, string message)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException(message);
            }
        }

        public static void ValidateNumberIsNotBelowZero(int number,string message)
        {
            if (number < 0)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ValidatePlayerIsAlive(IPlayer player,string message)
        {
            if (player.IsDead)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ValidateObjectIsNotNull(object obj, string message)
        {
            if (obj == null)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
