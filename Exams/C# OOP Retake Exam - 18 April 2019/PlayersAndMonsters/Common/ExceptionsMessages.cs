namespace PlayersAndMonsters.Common
{
    public static class ExceptionsMessages
    {
        public static string InvalidPlayerName = "Player's username cannot be null or an empty string.";

        public static string InvalidPlayerHealth = "Player's health bonus cannot be less than zero.";

        public static string InvalidDamagePoints = "Damage points cannot be less than zero.";

        public static string InvalidCardName = "Card's name cannot be null or an empty string.";

        public static string InvalidCardDamagePoints = "Card's damage points cannot be less than zero.";

        public static string InvalidCardHealthPoints = "Card's HP cannot be less than zero.";

        public static string DeadPlayer = "Player is dead!";

        public static string NullPlayer= "Player cannot be null";

        public static string PlayerAlreadyExist = "Player {0} already exists!";

        public static string NullCard = "Card cannot be null";

        public static string CardAlreadyExist = "Card {0} already exists!";
    }
}
