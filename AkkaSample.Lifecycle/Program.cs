
using Akka.Actor;
using AkkaSample.Lifecycle;

Console.WriteLine("AkkaSample - Full lifecycle started");

var system = ActorSystem.Create("FullLifecycleSystem");

var actor = system.ActorOf<FullLifecycleActor>();
actor.Tell(new FullLifecycleMessage());

actor.Tell("Force exception");

Thread.Sleep(2000);

system.Terminate();

Console.ReadLine();