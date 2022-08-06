using Akka.Actor;

namespace AkkaSample.WebApi.Services.CalculatorService;

public class CalculatorActor : ReceiveActor
{
    public CalculatorActor()
    {
        Receive<AddMessage>(add =>
        {
            Sender.Tell((new AnswerMessage(add.Term1 + add.Term2)));
        });
    }
}

public class AddMessage
{
    public AddMessage(int term1, int term2)
    {
        Term1 = term1;
        Term2 = term2;
    }

    public int Term1 { get; }
    public int Term2 { get; }
}

public class AnswerMessage
{
    public int Value { get; }

    public AnswerMessage(int value)
    {
        Value = value;
    }
}