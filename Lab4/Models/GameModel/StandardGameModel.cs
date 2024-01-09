namespace Lab4.Entity.GameEntities;

public class StandardGameModel: GameModel
{
    public StandardGameModel(decimal changeOfRating, int playerId)
    {
        ChangeOfRating = changeOfRating;
        PlayerId = playerId;
    }
}