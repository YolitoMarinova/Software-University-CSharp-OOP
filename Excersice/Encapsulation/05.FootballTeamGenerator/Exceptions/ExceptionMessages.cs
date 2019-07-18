namespace _05.FootballTeamGenerator.Exceptions
{
   public static class ExceptionMessages
    {
        public static string EmptyName =
            "A name should not be empty.";

        public static string InvalidStat =
            "{0} should be between 0 and 100.";

        public static string IvalidRemovePlayerOperation =
            "Player {0} is not in {1} team.";

        public static string NoneExcistentTeam =
            "Team {0} does not exist.";
    }
}
