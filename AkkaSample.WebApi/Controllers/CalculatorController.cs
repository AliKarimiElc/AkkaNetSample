using Akka.Actor;
using AkkaSample.WebApi.Services.CalculatorService;
using Microsoft.AspNetCore.Mvc;

namespace AkkaSample.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CalculatorController : ControllerBase
{
    private readonly ActorSystem _actorSystem;
    private readonly ICalculatorActorInstance _calculatorActor;
    public CalculatorController(ActorSystem actorSystem, ICalculatorActorInstance calculatorActor)
    {
        _actorSystem = actorSystem;
        _calculatorActor = calculatorActor;
    }

    [HttpGet("Sum")]
    public async Task<int> Sum(int x, int y)
    {
        var calculatorActorProps = Props.Create<CalculatorActor>();
        var calculatorActorRef = _actorSystem.ActorOf(calculatorActorProps);
        var addMessage = new AddMessage(x, y);
        var answer = await calculatorActorRef.Ask<AnswerMessage>(addMessage);
        return answer.Value;
    }

    [HttpGet("Sum2")]
    public async Task<int> Sum2(int x, int y)
    {
        IActorRef? calculatorRef=null;
        try
        {
            calculatorRef = await _actorSystem
                .ActorSelection("/user/calculatorActor")
                .ResolveOne(TimeSpan.FromMilliseconds(100));
        }
        catch (ActorNotFoundException e)
        {
            var calculatorActorProps = Props.Create<CalculatorActor>();
            calculatorRef = _actorSystem.ActorOf(calculatorActorProps, "calculatorActor");
        }

        var addMessage = new AddMessage(x, y);
        var answer = await calculatorRef.Ask<AnswerMessage>(addMessage);

        return answer.Value;
    }


    [HttpGet("sum3")]
    public async Task<int> Sum3(int x, int y)
    {
        var answer = await _calculatorActor.Sum(new AddMessage(x, y));
        return answer.Value;
    }
}