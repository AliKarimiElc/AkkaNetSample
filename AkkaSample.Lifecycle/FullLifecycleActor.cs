using Akka.Actor;

namespace AkkaSample.Lifecycle;

public class FullLifecycleActor : ReceiveActor
{
    public FullLifecycleActor()
    {
        Receive<FullLifecycleMessage>(message =>
        {
            Console.WriteLine("Message received and processed");
        });

        Receive<string>(src => throw new Exception("Unhandled exception"));
    }

    protected override void PreStart()
    {
        Console.WriteLine($"{nameof(FullLifecycleMessage)} is starting - Pre start");
        // base.PreStart();
    }

    protected override void PreRestart(Exception reason, object message)
    {
        Console.WriteLine($"{nameof(FullLifecycleMessage)} is restarting - Pre restart");
        // base.PreRestart(reason, message);
    }

    protected override void PostRestart(Exception reason)
    {
        Console.WriteLine($"{nameof(FullLifecycleMessage)} is restarted - Post restart");
        // base.PostRestart(reason);
    }

    protected override void PostStop()
    {
        Console.WriteLine($"{nameof(FullLifecycleMessage)} is stopped - Post stop");
        // base.PostStop();
    }
}

public class FullLifecycleMessage
{

}