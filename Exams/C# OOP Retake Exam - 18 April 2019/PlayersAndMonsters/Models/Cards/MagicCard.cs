namespace PlayersAndMonsters.Models.Cards
{
    public class MagicCard : Card
    {
        private const int DAMAGE_POINTS = 5;
        private const int INITIAL_HEALTH_POINTS = 80;

        public MagicCard(string name) 
            : base(name, DAMAGE_POINTS, INITIAL_HEALTH_POINTS)
        {
        }
    }
}
