using Lab4.Entity;
using Lab4.Entity.GameEntities;
using Lab4.Service;

namespace Lab4.Commands;

public class CreateGameCommand: ICommand
{
    private readonly GameService _gameService;

    public CreateGameCommand(GameService gameService)
    {
        _gameService = gameService;
    }
    
    public void Execute()
    {
        do
        {
            Console.Write("\nВведіть ім'я гравця для гри: ");
            string? playerName = Console.ReadLine();
            PlayerModel player = _gameService.ReadAccounts().FirstOrDefault(p => p.UserName != null && 
                p.UserName.Equals(playerName, StringComparison.OrdinalIgnoreCase)) ?? 
                                  throw new InvalidOperationException();

            Console.WriteLine("Виберіть тип гри:");
            Console.WriteLine("1. Standard Game");
            Console.WriteLine("2. Training Game");
            Console.WriteLine("3. Random Rating Game");

            if (int.TryParse(Console.ReadLine(), out int gameTypeChoice))
            {
                GameModel game;

                switch (gameTypeChoice)
                {
                    case 1:
                        Console.Write("Введіть рейтинг для стандартної гри: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal standardGameRating))
                        {
                            game = new StandardGameModel(standardGameRating, player.Id);
                        }
                        else
                        {
                            Console.WriteLine("Невірний ввід для рейтингу.");
                            return;
                        }
                        break;
                    case 2:
                        game = new TrainingGameModel(player.Id);
                        break;
                    case 3:
                        game = new RandomRatingGameModel(player.Id);
                        break;
                    default:
                        Console.WriteLine("Невірний вибір типу гри.");
                        return;
                }

                _gameService.CreateGame(game);
                Console.WriteLine($"Гра створена! ID гри: {game.Id}");
            }
            else
            {
                Console.WriteLine("Невірний ввід.");
            }

            Console.Write("Хочете створити ще одну гру? (y/n): ");
        } while (Console.ReadLine() == "y");
    }
}