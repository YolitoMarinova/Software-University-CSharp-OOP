using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.Cards.Contracts;

namespace PlayersAndMonsters.Models.Cards
{
    public abstract class Card : ICard
    {
        private string name;
        private int damagePoints;
        private int healthPoints;

        protected Card(string name,int damagePoints,int healthPoints)
        {
            this.Name = name;
            this.DamagePoints = damagePoints;
            this.HealthPoints = healthPoints;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ValidateStringIsNotNullOrEmpty(value,ExceptionsMessages.InvalidCardName);

                this.name = value;
            }
        }

        public int DamagePoints
        {
            get => this.damagePoints;
            set
            {
                Validator.ValidateNumberIsNotBelowZero(value,ExceptionsMessages.InvalidCardDamagePoints);

                this.damagePoints = value;
            }
        }

        public int HealthPoints
        {
            get => this.healthPoints;
            private set
            {
                Validator.ValidateNumberIsNotBelowZero(value,ExceptionsMessages.InvalidCardHealthPoints);

                this.healthPoints = value;
            }
        }
    }
}
