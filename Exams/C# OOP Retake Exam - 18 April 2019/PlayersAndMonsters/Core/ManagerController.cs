namespace PlayersAndMonsters.Core
{
    using System;
    using Contracts;
    using System.Text;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Core.Factories;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories;

    public class ManagerController : IManagerController
    {
        private PlayerRepository playerRepository;
        private PlayerFactory playerFactory;
        private CardRepository cardRepository;
        private CardFactory cardFactory;

        public ManagerController(PlayerRepository playerRepository, CardRepository cardRepository,CardFactory cardFactory, PlayerFactory playerFactory)
        {
            this.playerRepository = playerRepository;
            this.cardRepository = cardRepository;
            this.playerFactory = playerFactory;
            this.cardFactory = cardFactory;
        }

        public string AddPlayer(string type, string username)
        {
            IPlayer player = this.playerFactory.CreatePlayer(type,username);

            this.playerRepository.Add(player);

            return String.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);
        }

        public string AddCard(string type, string name)
        {
            ICard card = this.cardFactory.CreateCard(type,name);

            this.cardRepository.Add(card);

            return String.Format(ConstantMessages.SuccessfullyAddedCard, type, name);
        }

        public string AddPlayerCard(string username, string cardName)
        {
            IPlayer player = this.playerRepository.Find(username);
            ICard card = this.cardRepository.Find(cardName);

            player.CardRepository.Add(card);

            return String.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attacker = this.playerRepository.Find(attackUser);
            IPlayer enemy = this.playerRepository.Find(enemyUser);

            BattleField battleField = new BattleField();

            battleField.Fight(attacker, enemy);

            return String.Format(
                ConstantMessages.FightInfo,
                attacker.Health,
                enemy.Health);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var player in this.playerRepository.Players)
            {
                sb.AppendLine(String.Format(
                    ConstantMessages.PlayerReportInfo,
                    player.Username,
                    player.Health,
                    player.CardRepository.Cards.Count));

                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine(String.Format(
                        ConstantMessages.CardReportInfo,
                        card.Name,
                        card.DamagePoints));
                }

                sb.AppendLine(ConstantMessages.DefaultReportSeparator);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
