using Lab4.Entity.GameEntities;
using Lab4.Service;

namespace Lab4.Commands;

public class AllGamesCommand: ICommand
{
    private readonly GameService _gameService;

    public AllGamesCommand(GameService gameService)
    {
        _gameService = gameService;
    }
    
    public void Execute()
    {
        Console.WriteLine("\nСписок всіх ігор:");
        foreach (GameModel game in _gameService.ReadGames())
        {
            PrintGameInfo(game);
        }
    }
    
    private void PrintGameInfo(GameModel game)
    {
        String result = _gameService.IsPlayerWinner(game.PlayerId, game.Id) ? "Win" : "Lose";
        Console.WriteLine($"Гра #{game.Id} - Result: {result}, Rating Change: {game.ChangeOfRating}, Game Type: " +
                          $"{_gameService.GetGameTypeName(game)}");
    }
}