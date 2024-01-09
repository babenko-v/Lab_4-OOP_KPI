using Lab4.Entity;
using Lab4.Entity.GameEntities;
using Lab4.Service;

namespace Lab4.Commands;

public class PlayerStatisticsCommand : ICommand
{
    private readonly GameService _gameService;

    public PlayerStatisticsCommand(GameService gameService)
    {
        _gameService = gameService;
    }

    public void Execute()
    {
        Console.Write("\nВведіть ім'я гравця для перегляду статистики: ");
        string? playerName = Console.ReadLine();

        PlayerModel player = _gameService.ReadAccounts().
            FirstOrDefault(p => p.UserName != null && p.UserName.
                Equals(playerName, StringComparison.OrdinalIgnoreCase)) ?? throw new InvalidOperationException();

        PrintPlayerGamesInfo(player);
        Console.Write("\nЧи хочете переглянути інформацію про іншого гравця? (y/n): ");
        string? response = Console.ReadLine();
        if (response != null && response.Equals("y", StringComparison.OrdinalIgnoreCase))
        {
            Execute();
        }
    }

    private void PrintPlayerGamesInfo(PlayerModel player)
    {
        Console.WriteLine($"\nСписок ігор для {player.UserName}:");
        foreach (GameModel game in _gameService.ReadPlayerGamesByPlayerId(player.Id))
        {
            PrintGameInfo(game);
        }
    }

    private void PrintGameInfo(GameModel game)
    {
        var result = _gameService.IsPlayerWinner(game.PlayerId, game.Id) ? "Win" : "Lose";
        Console.WriteLine($"Гра #{game.Id} - Result: {result}, Rating Change: {game.ChangeOfRating}, " +
                          $"New Rating: {_gameService.GetPlayerRating(game.PlayerId)}, Game Type: " +
                          $"{_gameService.GetGameTypeName(game)}");
    }
}