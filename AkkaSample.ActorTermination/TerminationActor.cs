using Akka.Actor;

namespace AkkaSample.ActorTermination;

public class TerminationActor : ReceiveActor
{
    public TerminationActor()
    {
        Receive<string>(src =>
        {
            Thread.Sleep(2000);
            Console.WriteLine($"Message received : {src}");
        });
        Receive<StopMessage>(_ =>
        {
            Thread.Sleep(2000);
            Context.Stop(Self);
        });
    }

    protected override void PreStart()
    {
        Console.WriteLine("Actor starting ...");
        base.PreStart();
    }

    protected override void PostStop()
    {
        Console.WriteLine("Actor stopped");
        base.PostStop();
    }
}

public class StopMessage
{

}