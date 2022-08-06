using Akka.Actor;

namespace AkkaSample.Console.Domain.UnTypedActors
{
    internal class UnTypedGreeter:UntypedActor
    {
        protected override void OnReceive(object message)
        {
            Thread.Sleep(2000);
            if (message is IGreetType greet)
                System.Console.WriteLine(greet.GreetText);

            else
                System.Console.WriteLine("Unknown message");


            System.Console.WriteLine("Sender :");
            System.Console.WriteLine(Context.Sender.Path);
        }
    }
}
