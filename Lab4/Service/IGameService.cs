using Lab4.Entity;
using Lab4.Entity.GameEntities;

namespace Lab4.Service;

public interface IGameService
{
    void CreateAccount(PlayerModel player);
    IEnumerable<PlayerModel> ReadAccounts();
    void CreateGame(GameModel game);
    IEnumerable<GameModel> ReadPlayerGamesByPlayerId(int playerId);
    IEnumerable<GameModel> ReadGames();
    bool IsPlayerWinner(int playerId, int gameId);
    decimal GetPlayerRating(int playerId);
    string GetGameTypeName(GameModel game);
    decimal CalculateWinPoints(PlayerModel player, decimal changeOfRating);
    decimal CalculateLosePoints(PlayerModel player, decimal changeOfRating);
}