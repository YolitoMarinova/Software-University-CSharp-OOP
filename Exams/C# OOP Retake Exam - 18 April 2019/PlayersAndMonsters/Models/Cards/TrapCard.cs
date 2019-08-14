namespace PlayersAndMonsters.Models.Cards
{
    public class TrapCard : Card
    {
        private const int DAMAGE_POINTS = 120;
        private const int INITIAL_HEALTH_POINTS = 5;

        public TrapCard(string name)
            : base(name, DAMAGE_POINTS, INITIAL_HEALTH_POINTS)
        {
        }
    }
}
