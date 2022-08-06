using Akka.Actor;

namespace AkkaSample.WebApi.Services.CalculatorService;

public class CalculatorActorInstance : ICalculatorActorInstance
{
    private readonly IActorRef _actor;

    public CalculatorActorInstance(ActorSystem actorSystem)
    {
        _actor = actorSystem.ActorOf(Props.Create<CalculatorActor>(),
            "calculator");
    }

    public async Task<AnswerMessage> Sum(AddMessage message)
    {
        return await _actor.Ask<AnswerMessage>(message);
    }
}