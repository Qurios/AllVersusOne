using AllVersusOne.DataModel.Entities;
using AllVersusOne.Services.Dto;

namespace AllVersusOne.Services.GameService;

public interface IGameService
{
    Task<GameRound> CreateGameRound(QuestionDto question);

    Task<IEnumerable<GameRound>> GetAllGameRounds();

    Task<IEnumerable<Question>> GetAllQuestions();

    Task<bool> StartGameRound(int gameRoundId);

    Task<bool> EndGameRound(int gameRoundId);

    Task<GameRound?> GetCurrentGameRoundQuestion();

    Task<GameRound?> GetGameRound(int gameRoundId);
}