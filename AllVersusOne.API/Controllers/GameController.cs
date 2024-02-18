using AllVersusOne.Services.Dto;
using AllVersusOne.Services.GameService;
using Microsoft.AspNetCore.Mvc;

namespace AllVersusOne.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController(
        IGameService gameService,
        IAnswerService answerService)
        : ControllerBase
    {
        [HttpGet("get-current-question")]
        public async Task<GameRoundDto> GetCurrentGameRoundQuestion()
        {
            var gameRound = await gameService.GetCurrentGameRoundQuestion();

            if(gameRound == null)
            {
                return new GameRoundDto();
            }
            
            return new GameRoundDto
            {
                GameRoundId = gameRound.Id,
                Question = new QuestionDto()
                {
                    Title = gameRound.Question.Title,
                    Description = gameRound.Question.Description,
                    LowerLimit = gameRound.Question.LowerLimit,
                    UpperLimit = gameRound.Question.UpperLimit,
                }
                
            };
        }

        [HttpPost("answer-question")]
        public async Task PostAnswerToQuestion(int gameRoundId, int userId, int value)
        {
            await answerService.AnswerQuestion(gameRoundId, userId, value);
        }

        [HttpGet("get-round-status/{gameRoundId}")]
        public async Task<GameRoundStatusDto> GetGameRoundStatus(int gameRoundId)
        {
            var gameRound = await gameService.GetGameRound(gameRoundId);

            if(gameRound == null)
            {
                return new GameRoundStatusDto();
            }

            return new GameRoundStatusDto
            {
                ResponseOne = gameRound.ResponseOne,
                ResponseAll = gameRound.AverageAll,
                Status = gameRound.RoundState
            };
        }

        [HttpGet("list-all-questions")]
        public async Task<IEnumerable<QuestionDto>> GetAllQuestions()
        {
            var questions = await gameService.GetAllQuestions();
            return questions
                .Select(q => new QuestionDto()
                {
                    Title = q.Title,
                    Description = q.Description,
                    LowerLimit = q.LowerLimit,
                    UpperLimit = q.UpperLimit,
                    CorrectAnswer = q.CorrectAnswer,
                });
        }


        [HttpGet("list-all-game-rounds")]
        public async Task<IEnumerable<GameRoundDto>> GetAllGameRounds()
        {
            var gameRounds = await gameService.GetAllGameRounds();
               
            return gameRounds.Select(q =>
                new GameRoundDto
                {
                    Question = new QuestionDto()
                    {
                        Title = q.Question.Title,
                        Description = q.Question.Description,
                        LowerLimit = q.Question.LowerLimit,
                        UpperLimit = q.Question.UpperLimit,
                        CorrectAnswer = q.Question.CorrectAnswer
                    },
                    GameRoundId = q.Id
                }
            );
        }


        [HttpPost("create-game-round")]
        public async Task<int> CreateGameRound(QuestionDto question)
        {
            var gameRound = await gameService.CreateGameRound(question);
            return gameRound.Id;
        }

        /*[HttpPost("create-game-round-from-question")]
        public int CreateGameRound(int questionId)
        {
            throw new NotImplementedException();
        }
        */
        [HttpPost("start-game-round")]
        public int StartGameRound(int gameRoundId)
        {
            gameService.StartGameRound(gameRoundId);
            return gameRoundId;
        }

        [HttpPost("end-game-round")]
        public int EndGameRound(int gameRoundId)
        {
            gameService.EndGameRound(gameRoundId);
            return gameRoundId;
        }

        /*[HttpPost("get-game-status")]
        public List<GameRoundStatusDto> GetGameStatus(List<int> gameRoundIds)
        {
            // hvad skal 
            throw new NotImplementedException();
        }*/
    }
}
