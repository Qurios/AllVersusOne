using AllVersusOne.DataModel.Entities;
using AllVersusOne.DataModel.Enums;
using AllVersusOne.Infrastructure.DataAccess;
using AllVersusOne.Services.Dto;
using Microsoft.EntityFrameworkCore;

namespace AllVersusOne.Services.GameService;

public class GameService(
        IUnitOfWorkManager uowManager,
        IRepository<GameRound> gameRoundRepository,
        IAnswerService answerService)
    : IGameService
{
    public async Task<GameRound> CreateGameRound(QuestionDto question)
    {
        using var uow = uowManager.Begin();

        var gameRound = new GameRound()
        {
            Question = new Question()
            {
                Title = question.Title,
                Description = question.Description,
                LowerLimit = question.LowerLimit,
                UpperLimit = question.UpperLimit,
                CorrectAnswer = question.CorrectAnswer,
            },
            RoundState = RoundState.New,
        };

        await gameRoundRepository.AddAsync(gameRound);
        await uow.SaveAsync();
        return gameRound;
    }

    public async Task<bool> EndGameRound(int gameRoundId)
    {
        var ended = await SetRoundState(gameRoundId, RoundState.Finished);

        if(!ended)
        {
            return false;
        }

        return await CalculateResultsForRound(gameRoundId);
    }

    public async Task<IEnumerable<GameRound>> GetAllGameRounds()
    {
        return await gameRoundRepository
            .Many()
            .Include(g => g.Question)
            .Take(100)
            .ToListAsync();
    }


    public async Task<IEnumerable<Question>> GetAllQuestions()
    {
        return await gameRoundRepository
            .Many()
            .Select(g => g.Question)
            .Take(100)
            .ToListAsync();
    }

    public async Task<GameRound?> GetCurrentGameRoundQuestion()
    {
        return await gameRoundRepository
            .Many()
            .Where(g => g.RoundState == RoundState.Ongoing)
            .Include(g => g.Question)
            .FirstOrDefaultAsync();
    }

    public async Task<GameRound?> GetGameRound(int gameRoundId)
    {
        return await GetGameRoundById(gameRoundId);
    }

    public async Task<bool> StartGameRound(int gameRoundId)
    {
        using var uow = uowManager.Begin();
        var started = await SetRoundState(gameRoundId, RoundState.Ongoing);
        await uow.SaveAsync();
        return started;
    }

    private async Task<bool> SetRoundState(int gameRoundId, RoundState roundState)
    {
        var gameRound = await GetGameRoundById(gameRoundId);

        if (gameRound == null)
        {
            return false;
        }

        gameRound.RoundState = roundState;

        return true;
    }

    private async Task<bool> CalculateResultsForRound(int gameRoundId)
    {
        using var uow = uowManager.Begin();
        
        var gameRound = await GetGameRoundById(gameRoundId);
        if (gameRound == null)
        { 
            return false;
        }

        gameRound.AverageAll = await answerService.CalculateAverageOfGameRound(gameRoundId);

        gameRound.ResponseOne = await answerService.GetResponseFromScene(gameRoundId);

        await uow.SaveAsync();
        return true;
    }

    private async Task<GameRound?> GetGameRoundById(int gameRoundId)
    {
        return await gameRoundRepository.Many()
            .Where(g => g.Id == gameRoundId)
            .FirstOrDefaultAsync();
    }

}