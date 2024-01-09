using Lab4.Entity;
using Lab4.GameAccounts;
using Lab4.Service;

namespace Lab4.Commands;

public class AddPlayerCommand: ICommand
{
    private readonly GameService _gameService;

    public AddPlayerCommand(GameService gameService)
    {
        _gameService = gameService;
    }
    
    public void Execute()
    {
        bool addAnotherPlayer = true;

        while (addAnotherPlayer)
        {
            Console.Write("Введіть ім'я гравця: ");
            string? playerName = Console.ReadLine();

            Console.Write("Введіть початковий рейтинг: ");
            if (int.TryParse(Console.ReadLine(), out int initialRating))
            {
                Console.WriteLine("\nВиберіть тип акаунту:\n1. Standard\n2. ReducedLoss\n3. WinningStreak");
                if (int.TryParse(Console.ReadLine(), out int accountTypeChoice) && accountTypeChoice is >= 1 and <= 3)
                {
                    AccountType accountType = (AccountType)accountTypeChoice;
                    PlayerModel newPlayer = CreatePlayer(playerName, initialRating, accountType);
                    _gameService.CreateAccount(newPlayer);
                    Console.WriteLine($"Гравець {newPlayer.UserName} доданий успішно.");
                    
                    Console.Write("Бажаєте додати ще одного гравця? (y/n): ");
                    string? addAnotherPlayerInput = Console.ReadLine();
                    if (addAnotherPlayerInput != null)
                        addAnotherPlayer = addAnotherPlayerInput.Equals("y", StringComparison.OrdinalIgnoreCase);
                }
                else
                {
                    Console.WriteLine("Неправильний вибір типу акаунту. Додавання гравця відмінено.");
                    addAnotherPlayer = false;
                }
            }
            else
            {
                Console.WriteLine("Неправильний формат рейтингу. Додавання гравця відмінено.");
                addAnotherPlayer = false;
            }
        }
    }
    
    private PlayerModel CreatePlayer(string? playerName, int initialRating, AccountType accountType)
    {
        return accountType switch
        {
            AccountType.Standard => new PlayerModel(new StandardGameAccount(playerName, initialRating)),
            AccountType.ReducedLoss => new PlayerModel(new ReducedLossGameAccount(playerName, initialRating)),
            AccountType.WinningStreak => new PlayerModel(new WinningStreakGameAccount(playerName, initialRating)),
            _ => throw new InvalidOperationException("Непідтримуваний тип акаунту.")
        };
    }
}

public enum AccountType
{
    Standard = 1,
    ReducedLoss = 2,
    WinningStreak = 3
}