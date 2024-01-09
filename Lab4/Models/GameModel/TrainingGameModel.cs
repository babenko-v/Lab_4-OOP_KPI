namespace Lab4.Entity.GameEntities;

public class TrainingGameModel : GameModel
{
    public TrainingGameModel(int playerId)
    {
        ChangeOfRating = 0;
        PlayerId = playerId;
    }
}