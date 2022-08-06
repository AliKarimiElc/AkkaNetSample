namespace AkkaSample.WebApi.Services.CalculatorService;

public interface ICalculatorActorInstance
{
    Task<AnswerMessage> Sum(AddMessage message);
}