using Lab4.Entity;
using Lab4.Entity.GameEntities;

namespace Lab4;

public class DbContext
{
    public List<PlayerModel> Players { get; } = new();
    public List<GameModel> Games { get; } = new();
}