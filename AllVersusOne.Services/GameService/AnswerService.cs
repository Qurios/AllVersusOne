using AllVersusOne.DataModel.Entities;
using AllVersusOne.DataModel.Enums;
using AllVersusOne.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AllVersusOne.Services.GameService;

public class AnswerService(IRepository<Guess> guessRepository, IUnitOfWorkManager uowManager)
    : IAnswerService
{
    public async Task AnswerQuestion(int gameRoundId, int userId, int value)
    {
        using var uow = uowManager.Begin();
        var answer = new Guess
        {
            GameRoundId = gameRoundId,
            UserId = userId,
            Value = value,
        };

        await guessRepository.AddAsync(answer);
        await uow.SaveAsync();
    }

    public async Task<int> CalculateAverageOfGameRound(int gameRoundId)
    {
        var average = await guessRepository.Many()
            .Where(g => g.GameRoundId == gameRoundId && g.User.Type == UserType.User )
            .Select(g => g.Value)
            .AverageAsync();

        return (int) average;
    } 

    public async Task<int> GetResponseFromScene(int gameRoundId)
    {
        return await guessRepository.Many()
            .Where(g => g.GameRoundId == gameRoundId && g.User.Type == UserType.Scene)
            .Select(g => g.Value)
            .FirstOrDefaultAsync();
    }
}