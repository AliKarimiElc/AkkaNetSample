using Akka.Actor;

namespace AkkaSample.EventBus;

public class BookSubscriber : ReceiveActor
{
    public BookSubscriber()
    {
        Receive<NewBookMessage>(message => Handle(message));
    }

    private void Handle(NewBookMessage message)
    {
        Console.WriteLine($"Book: {message.BookName} got published - message received by {Self.Path.Name}");
    }
}