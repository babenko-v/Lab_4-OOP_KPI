namespace Lab4.GameAccounts;

public abstract class GameAccount
{
    public string? UserName { get; }
    public decimal CurrentRating { get; }

    protected GameAccount(string? name, decimal rating)
    {
        if (rating < 1)
        {
            rating = 1;
        }

        UserName = name;
        CurrentRating = rating;
    }
}