using Lab4.Entity.GameEntities;
using Lab4.Repository.IRepository;

namespace Lab4.Repository;

public class GameRepository: IGameRepository
{
    private readonly List<GameModel> _games;

    public GameRepository(List<GameModel> games)
    {
        _games = games;
    }

    public void CreateGame(GameModel game)
    {
        game.Id = _games.Count + 1;
        _games.Add(game);
    }

    public GameModel ReadGameById(int gameId)
    {
        return _games.FirstOrDefault(g => g.Id == gameId) ?? throw new InvalidOperationException();
    }

    public IEnumerable<GameModel> ReadAllGames()
    {
        return _games;
    }
}