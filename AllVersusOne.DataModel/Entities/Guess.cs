namespace AllVersusOne.DataModel.Entities;

public class Guess : IEntity
{
    public int Id { get; }

    public int GameRoundId { get; set; }

    public GameRound GameRound { get; set; }

    public int UserId { get; set; }

    public User User { get; set; }

    public int Value { get; set; }
}