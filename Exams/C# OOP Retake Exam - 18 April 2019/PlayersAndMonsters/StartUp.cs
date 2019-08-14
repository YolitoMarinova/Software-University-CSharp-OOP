namespace PlayersAndMonsters
{
    using Core;
    using Core.Contracts;
    using Core.Factories;
    using Core.Factories.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using IO;
    using IO.Contracts;
    using Models.BattleFields;
    using Models.BattleFields.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            PlayerRepository playerRepository = new PlayerRepository();
            CardRepository cardRepository = new CardRepository();
            PlayerFactory playerFactory=new PlayerFactory();
            CardFactory cardFactory = new CardFactory();

            IManagerController managerController = new ManagerController(playerRepository,cardRepository,cardFactory, playerFactory);

            Engine engine = new Engine(managerController);
            engine.Run();
        }
    }
}