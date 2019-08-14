using System;
using System.Linq;
using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            IsPLayersAlive(attackPlayer, enemyPlayer);

            if (attackPlayer is Beginner)
            {
                BoostBeginnerPlayer(attackPlayer);
            }

            if (enemyPlayer is Beginner)
            {
                BoostBeginnerPlayer(enemyPlayer);
            }

            BoostPlayer(attackPlayer);

            BoostPlayer(enemyPlayer);

            int attackPlayerCardDamagePoints = attackPlayer.CardRepository.Cards.Sum(x=>x.DamagePoints);
            int enemyPlayerCardDamagePoints = enemyPlayer.CardRepository.Cards.Sum(x=>x.DamagePoints);

            while (true)
            {
                enemyPlayer.TakeDamage(attackPlayerCardDamagePoints);

                if (enemyPlayer.Health==0)
                {
                    break;
                }

                attackPlayer.TakeDamage(enemyPlayerCardDamagePoints);

                if (attackPlayer.Health==0)
                {
                    break;
                }
            }
        }

        private void BoostPlayer(IPlayer player)
        {
            int healthToIncrease = player.CardRepository.Cards.Sum(x => x.HealthPoints);

            player.Health += healthToIncrease;
        }

        private void BoostBeginnerPlayer(IPlayer player)
        {
            player.Health += 40;

            foreach (ICard card in player.CardRepository.Cards)
            {
                card.DamagePoints += 30;
            }
        }

        private void IsPLayersAlive(params IPlayer[] players)
        {
            foreach (var player in players)
            {
                Validator.ValidatePlayerIsAlive(player, ExceptionsMessages.DeadPlayer);
            }
        }
    }
}
