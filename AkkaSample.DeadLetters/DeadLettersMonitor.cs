using Akka.Actor;
using Akka.Event;

namespace AkkaSample.DeadLetters;

public class DeadLettersMonitor : ReceiveActor
{
    public DeadLettersMonitor()
    {
        Receive<DeadLetter>(d => Handle(d));
    }

    private void Handle(DeadLetter deadLetter)
    {
        var msg = $"Message: {deadLetter.Message},\n" +
                  $"Sender: {deadLetter.Sender},\n" +
                  $"Recipient: {deadLetter.Recipient}\n";

        Console.WriteLine(msg);
    }
}