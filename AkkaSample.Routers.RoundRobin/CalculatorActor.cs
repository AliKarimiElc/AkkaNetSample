using Akka.Actor;

namespace AkkaSample.Routers.RoundRobin;

public class CalculatorActor : ReceiveActor
{
    public CalculatorActor()
    {
        Receive<AddMessage>(HandleAddition);
    }

    private void HandleAddition(AddMessage add)
    {
        Console.WriteLine($"{Self.Path} Receive the request: {add.Term1} + {add.Term2}");
        Sender.Tell(new Answer(add.Term1 + add.Term2));
    }
}