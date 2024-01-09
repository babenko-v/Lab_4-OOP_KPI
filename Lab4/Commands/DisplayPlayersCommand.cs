using Lab4.Entity;
using Lab4.Service;

namespace Lab4.Commands;

public class DisplayPlayersCommand: ICommand
{
    private readonly GameService _gameService;

    public DisplayPlayersCommand(GameService gameService)
    {
        _gameService = gameService;
    }

    public void Execute()
    {
        Console.WriteLine("Список гравців:");
        foreach (PlayerModel player in _gameService.ReadAccounts())
        {
            Console.WriteLine($"{player.Id}. {player.UserName} - Rating: {player.CurrentRating}");
        }
    }
}