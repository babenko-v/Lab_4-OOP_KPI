using Lab4.Entity;
using Lab4.Repository.IRepository;

namespace Lab4.Repository;

public class PlayerRepository: IPlayerRepository
{
    private readonly List<PlayerModel> _players;

    public PlayerRepository(List<PlayerModel> players)
    {
        _players = players;
    }

    public void CreatePlayer(PlayerModel player)
    {
        player.Id = _players.Count + 1;
        _players.Add(player);
    }

    public PlayerModel ReadPlayerById(int playerId)
    {
        return _players.FirstOrDefault(p => p.Id == playerId) ?? throw new InvalidOperationException();
    }

    public IEnumerable<PlayerModel> ReadAllPlayers()
    {
        return _players;
    }
    
    public void CreateAccount(PlayerModel player)
    {
        player.Id = _players.Count + 1;
        _players.Add(player);
    }

    public IEnumerable<PlayerModel> ReadAccounts()
    {
        return _players;
    }
    
    public PlayerModel ReadAccountById(int playerId)
    {
        return _players.FirstOrDefault(p => p.Id == playerId) ?? throw new InvalidOperationException();
    }
    
    public void UpdateRating(int playerId, decimal newRating)
    {
        var player = _players.FirstOrDefault(p => p.Id == playerId);
        if (player != null)
        {
            player.CurrentRating = newRating;
        }
    }
}