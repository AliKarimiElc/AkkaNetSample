using Akka.Actor;

namespace AkkaSample.Console.Domain.TypedActors;

internal class GreetingActor : ReceiveActor
{
    public GreetingActor()
    {
        Receive<Greet>(greet =>
        {
            Thread.Sleep(2000);
            System.Console.WriteLine($"[Thread {Thread.CurrentThread.ManagedThreadId}] Greeting {greet.Who}");
        });
    }
}