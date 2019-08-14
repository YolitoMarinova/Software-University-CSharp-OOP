using System;
using System.Collections.Generic;
using System.Linq;
using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        private List<ICard> cards;

        public CardRepository()
        {
            this.cards = new List<ICard>();
        }

        public int Count => this.cards.Count;

        public IReadOnlyCollection<ICard> Cards => 
            this.cards.AsReadOnly();

        public void Add(ICard card)
        {
            Validator.ValidateObjectIsNotNull(card,ExceptionsMessages.NullCard);

            string cardName = card.Name;

            if (this.cards.Any(x => x.Name == cardName))
            {
                throw new ArgumentException( String.Format(
                    ExceptionsMessages.CardAlreadyExist,
                    cardName));
            }

            this.cards.Add(card);
        }

        public ICard Find(string name)
        {
            ICard card = this.cards.FirstOrDefault(x=>x.Name==name);

            return card;
        }

        public bool Remove(ICard card)
        {
            Validator.ValidateObjectIsNotNull(card,ExceptionsMessages.NullCard);

            return this.cards.Remove(card);
        }
    }
}
