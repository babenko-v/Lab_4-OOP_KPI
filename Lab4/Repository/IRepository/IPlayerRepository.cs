using Lab4.Entity;

namespace Lab4.Repository.IRepository;

public interface IPlayerRepository
{
    void CreatePlayer(PlayerModel player);
    PlayerModel ReadPlayerById(int playerId);
    IEnumerable<PlayerModel> ReadAllPlayers();
    
    void CreateAccount(PlayerModel player);
    IEnumerable<PlayerModel> ReadAccounts();
    PlayerModel ReadAccountById(int playerId);
    void UpdateRating(int playerId, decimal newRating);
}