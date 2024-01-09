namespace Lab4.Entity.GameEntities;

public class RandomRatingGameModel : GameModel
{
    public RandomRatingGameModel(int playerId)
    {
        Random random = new Random();
        ChangeOfRating = random.Next(5, 11);
        PlayerId = playerId;
    }
}