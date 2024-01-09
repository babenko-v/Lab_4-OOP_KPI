namespace Lab4.Entity.GameEntities;

public class GameModel
{
    public int Id { get; set; }
    public decimal ChangeOfRating { get; protected init; }
    public int PlayerId { get; protected init; }
}