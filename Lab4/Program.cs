using System.Text;
using Lab4.Commands;
using Lab4.Repository;
using Lab4.Service;

namespace Lab4
{
    public abstract class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            DbContext dbContext = new DbContext();
            PlayerRepository playerRepository = new PlayerRepository(dbContext.Players);
            GameRepository gameRepository = new GameRepository(dbContext.Games);
            GameService gameService = new GameService(playerRepository, gameRepository);
            
            ICommand addPlayerCommand = new AddPlayerCommand(gameService);
            addPlayerCommand.Execute();

            ICommand createGameCommand = new CreateGameCommand(gameService);
            createGameCommand.Execute();

            ICommand playerStatisticsCommand = new PlayerStatisticsCommand(gameService);
            playerStatisticsCommand.Execute();
            
            ICommand displayPlayersCommand = new DisplayPlayersCommand(gameService);
            displayPlayersCommand.Execute();
            
            ICommand allGamesCommand = new AllGamesCommand(gameService);
            allGamesCommand.Execute();
        }
    }
}