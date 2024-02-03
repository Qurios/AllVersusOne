using AllVersusOne.DataModel.Enums;

namespace AllVersusOne.DataModel.Entities;

public class GameRound : IEntity
{
    public int Id { get; }

    public Question Question { get; set; }

    public int ResponseOne { get; set; }

    public int AverageAll { get; set; }

    public RoundState RoundState { get; set; }
}