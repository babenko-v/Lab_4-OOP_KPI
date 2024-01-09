using Lab4.Entity.GameEntities;

namespace Lab4.Repository.IRepository;

public interface IGameRepository
{
    void CreateGame(GameModel game);
    GameModel ReadGameById(int gameId);
    IEnumerable<GameModel> ReadAllGames();
}