using Akka.Actor;

namespace AkkaSample.EventBus;

public class BookPublisher : ReceiveActor
{
    public BookPublisher()
    {
        Receive<NewBookMessage>(message => Handle(message));
    }

    private void Handle(NewBookMessage newBookMessage)
    {
        Context.System.EventStream.Publish(newBookMessage);
    }
}