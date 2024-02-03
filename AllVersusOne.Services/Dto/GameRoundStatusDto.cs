using AllVersusOne.DataModel.Enums;

namespace AllVersusOne.Services.Dto;

public class GameRoundStatusDto
{
    public int? ResponseOne { get; set; }

    public int? ResponseAll { get; set; }
    public RoundState Status { get; set; }
}