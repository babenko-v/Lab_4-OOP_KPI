using Lab4.GameAccounts;

namespace Lab4.Entity;

public class PlayerModel
{
    public int Id { get; set; }
    public string? UserName { get; }
    public decimal CurrentRating { get; set; }
    public GameAccount GameAccount { get; }
    
    public PlayerModel(GameAccount gameAccount)
    {
        UserName = gameAccount.UserName;
        CurrentRating = gameAccount.CurrentRating;
        GameAccount = gameAccount;
    }
}