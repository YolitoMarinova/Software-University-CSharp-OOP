using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;

        protected Player(ICardRepository cardRepository,string username,int health)
        {
            this.CardRepository = cardRepository;
            this.Username = username;
            this.Health = health;
        }

        public ICardRepository CardRepository { get; private set; }

        public string Username
        {
            get => this.username;
            private set
            {
                Validator.ValidateStringIsNotNullOrEmpty(value,ExceptionsMessages.InvalidPlayerName);

                this.username = value;
            }
        }

        public int Health
        {
            get => this.health;
            set
            {
                Validator.ValidateNumberIsNotBelowZero(value, ExceptionsMessages.InvalidPlayerHealth);

                this.health = value;
            }
        }

        public bool IsDead => this.Health <= 0;

        public void TakeDamage(int damagePoints)
        {
            Validator.ValidateNumberIsNotBelowZero(damagePoints,ExceptionsMessages.InvalidDamagePoints);

            int playertHealth = this.Health - damagePoints;

            if (playertHealth < 0)
            {
                this.Health = 0;
            }
            else
            {
                this.Health = playertHealth;
            }
        }
    }
}
