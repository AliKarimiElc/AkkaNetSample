
using Akka.Actor;
using Akka.Event;
using AkkaSample.DeadLetters;

Console.WriteLine("AkkaSample Console started - DeadLetters");

var system = ActorSystem.Create("DeadLetterSystem");

var subscriber = system.ActorOf<DeadLettersMonitor>(nameof(DeadLettersMonitor));
var echoActor = system.ActorOf<EchoActor>("EchoActor");

system.EventStream.Subscribe(subscriber,typeof(DeadLetter));

echoActor.Tell("Hi");
echoActor.Tell("Bye");
echoActor.Tell(PoisonPill.Instance);
echoActor.Tell("Hi");
echoActor.Tell("Bye");

Console.ReadLine();

system.Terminate();