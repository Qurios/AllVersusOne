namespace AllVersusOne.Services.Dto;

public class QuestionDto
{
    public string Title { get; set; }

    public string Description { get; set; }

    public int UpperLimit { get; set; }

    public int LowerLimit { get; set; }

    public int CorrectAnswer { get; set; }
}