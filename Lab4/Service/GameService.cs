using Lab4.Entity;
using Lab4.Entity.GameEntities;
using Lab4.GameAccounts;
using Lab4.Repository.IRepository;

namespace Lab4.Service;

public class GameService: IGameService
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IGameRepository _gameRepository;

    public GameService(IPlayerRepository playerRepository, IGameRepository gameRepository)
    {
        _playerRepository = playerRepository;
        _gameRepository = gameRepository;
    }

    public void CreateGame(GameModel game)
    {
        _gameRepository.CreateGame(game);
    }

    public IEnumerable<GameModel> ReadPlayerGamesByPlayerId(int playerId)
    {
        return _gameRepository.ReadAllGames().Where(g => g.PlayerId == playerId);
    }

    public IEnumerable<GameModel> ReadGames()
    {
        return _gameRepository.ReadAllGames();
    }
    
    public void CreateAccount(PlayerModel player)
    {
        _playerRepository.CreatePlayer(player);
    }

    public IEnumerable<PlayerModel> ReadAccounts()
    {
        return _playerRepository.ReadAccounts();
    }
    
    public bool IsPlayerWinner(int playerId, int gameId)
    {
        GameModel game = _gameRepository.ReadGameById(gameId);
        PlayerModel player = _playerRepository.ReadAccountById(playerId);
        Random random = new Random();
        bool isWinner = random.Next(2) == 0;
        
        decimal changeOfRating = game.ChangeOfRating;
        
        if (isWinner)
        {
            player.CurrentRating += CalculateWinPoints(player, changeOfRating);
        }
        else 
        {
            player.CurrentRating -= CalculateLosePoints(player, changeOfRating);
            
            if (player.CurrentRating < 1)
            {
                player.CurrentRating = 1;
            }
        }

        _playerRepository.UpdateRating(player.Id, player.CurrentRating);

        return isWinner;
    }
    
    private int _consecutiveWins;
    
    public decimal CalculateWinPoints(PlayerModel player, decimal changeOfRating)
    {
        if (player.GameAccount is not WinningStreakGameAccount) return changeOfRating;
        
        _consecutiveWins++;
        if (_consecutiveWins >= 3)
        {
            return changeOfRating + 100;
        }
        
        return changeOfRating;
    }
    
    public decimal CalculateLosePoints(PlayerModel player, decimal changeOfRating)
    {
        switch (player.GameAccount)
        {
            case ReducedLossGameAccount:
                return changeOfRating / 2;
            
            case WinningStreakGameAccount:
                _consecutiveWins = 0;
                break;
        }

        return changeOfRating;
    }

    public decimal GetPlayerRating(int playerId)
    {
        PlayerModel player = _playerRepository.ReadAccountById(playerId);
        return player.CurrentRating;
    }
    
    public string GetGameTypeName(GameModel game)
    {
        return game switch
        {
            StandardGameModel => "Standard Game",
            TrainingGameModel => "Training Game",
            RandomRatingGameModel => "Random Rating Game",
            _ => "Unknown Game Type"
        };
    }
}