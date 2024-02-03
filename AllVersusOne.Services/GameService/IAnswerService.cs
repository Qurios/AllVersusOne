namespace AllVersusOne.Services.GameService;

public interface IAnswerService
{
    Task AnswerQuestion(int gameRoundId, int userId, int value);

    Task<int> CalculateAverageOfGameRound(int gameRoundId);

    Task<int> GetResponseFromScene(int gameRoundId);
}